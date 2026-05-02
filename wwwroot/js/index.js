//resize fullmap
const full_map = document.getElementById("full-map");
const height_70p = (window.innerHeight / 100) * 70;

correct_resize();

window.addEventListener("resize", (e) => {
  correct_resize();
});

function correct_resize() {
  if (window.innerWidth < height_70p) {
    full_map.classList.add("full-map-scale-width");
    full_map.classList.remove("full-map-scale-hight");
  } else {
    full_map.classList.add("full-map-scale-hight");
    full_map.classList.remove("full-map-scale-width");
  }
}

//all about inputs

//switch maps
const routes = [
  "/full-map",
  "/house-1",
  "/house-2",
  "/house-3",
  "/house-4",
  "/house-5",
  "/house-6",
  "/house-8",
  "/house-11",
];

const houses_ids = [
  "back-to-full-map",
  "house-1",
  "house-2",
  "house-3",
  "house-4",
  "house-5",
  "house-6",
  "house-8",
  "house-11",
];

const houses_map_ids = [
  "full-map",
  "house-1-map",
  "house-2-map",
  "house-3-map",
  "house-4-map",
  "house-5-map",
  "house-6-map",
  "house-8-map",
  "house-11-map",
];

const edit_bar = document.getElementById("edit-bar");

repage();

function repage() {
  for (let i = 0; i < routes.length; i++) {
    if (routes[i] == window.location.pathname) {
      switchmap(i);
    }
  }
}

for (let i = 0; i < routes.length; i++) {
  const houses = document.getElementById(houses_ids[i]);
  let path = routes[i];
  houses.addEventListener("click", () => {
    history.pushState({}, "", path);
    switchmap(i);
  });
}

function switchmap(map) {
  for (let i = 0; i < houses_map_ids.length; i++) {
    if (i == map) {
      const activ_map = document.getElementById(houses_map_ids[i]);
      activ_map.classList.remove("not-displayed");
      if (map == 0) {
        edit_bar.classList.add("hidden");
      } else {
        edit_bar.classList.remove("hidden");
      }
    } else {
      const inactiv_map = document.getElementById(houses_map_ids[i]);
      inactiv_map.classList.add("not-displayed");
    }
  }
}

//date for copyright
const copyright = document.getElementById("copyright");
let date_now = new Date();
copyright.textContent = `©${date_now.getUTCFullYear()}\u00A0`;
