# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GZMaps.csproj", "."]
RUN dotnet restore "./GZMaps.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./GZMaps.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GZMaps.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ----------------------------------------------------
# Fix for Issue #1: Create folder and grant permissions to the app user
# ----------------------------------------------------
USER root
RUN mkdir -p /app/MapData && chown -R $APP_UID:$APP_UID /app/MapData

# Switch back to the safe, non-root user for execution
USER $APP_UID
# ----------------------------------------------------

ENTRYPOINT ["dotnet", "GZMaps.dll"]