# GZMaps
GZMaps is a simple, minimalistic map tool made for our organisation. It is designed to be easy to change, specifically for fast-changing environments, but at the same time to not be prone to accidental changes.

## Technology Stack
GZMaps is built with ASP.Net as the backend and HTML/CSS/JS integrated into Razor Pages as the frontend. 
No external libraries are used, except for the .Net framework (v9.0) itself and the 
```
Microsoft.VisualStudio.Azure.Containers.Tools.Targets
```
Package, which is used for containerization and deployment to Environments like Docker and Azure.

## How to Use
GZMaps was built with Containerisation in mind, therefore the easiest way to use it is to build the Docker image and run it in a container. However, it can also be run locally using the exe.
### Running with Docker
The Docker Image can be downloaded from the latest release on Github , or built locally using the provided Dockerfile.
The image requires the following environment variables to be set:
- `EditorPassword` -> The password needed to access the editor interface.

The image also accepts the following arguments to be appended to the exec command:
- `--forceDev` -> This argument is needed to start the image in Development mode. See more on that in the <a href="#startup-arguments">Startup Arguments</a> section below.

### Running Locally
1. Download the latest release from Github and extract the zip file.
2. Open Powershell and navigate to the extracted folder.
3. If HTTPS is needed, run the following commandto set needed environment variables:
```
$env:ASPNETCORE_URLS="https://*:7274;http://*:5104"
```
4. Run the exe with the following command:
```
.\GZMaps.exe
```
5. Open a web browser and navigate to http://localhost:5104 or https://localhost:7274, depending on whether HTTPS is activated.

### Startup Arguments
GZMaps can be started with the following arguments:
#### forceDev
When starting with this argument, GZMaps will ignore the current environment and start in Development mode. The Editor Password is then fixed as "1234", to make testing easier.

# Known Issues
- Currently there is no way to change the port the application runs on, except for setting the `ASPNETCORE_URLS` environment variable.
- There is no handling for two people trying to edit the map at the same time, which can lead to data loss. This is going to be added in the future, but for now its best to just not edit at the same time.