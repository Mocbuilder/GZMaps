let ts = document.getElementById("ts");
ts.addEventListener("click", async (e) => {
  const response = await fetch("/POSTMapData", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      test: "test",
      test2: {
        test3: ["test4", "test5"],
      },
    }),
  });
});

let tp = document.getElementById("tp");
tp.addEventListener("click", async (e) => {
  const response = await fetch("/GETPassword");
  console.log(await response.json());
});

let tm = document.getElementById("tm");
tm.addEventListener("click", async (e) => {
  const response = await fetch("/t/GETMapData");
  console.log(await response.json());
});
