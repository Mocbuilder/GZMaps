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
const houses_maps_ids = [
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

let edit_button = document.getElementById("edit-button");
let save_button = document.getElementById("save-button");

const houses_inputs = [10, 10, 15, 5, 4, 3, 6, 2];
let input_list = [];
let value_list = [];

for (let i = 1; i < houses_maps_ids.length; i++) {
  let map = document.getElementById(houses_maps_ids[i]);
  for (let x = 1; x <= houses_inputs[i - 1]; x++) {
    let input = document.createElement("input");
    input.type = "Text";
    input.id = `h${i}-${x}`;
    input.placeholder = `${x}`;
    input.readOnly = true;
    input_list.push(input);
    map.appendChild(input);
  }
}

load();
function load() {
  for (let i = 0; i < input_list.length; i++) {
    if (value_list[i] !== undefined) {
      input_list[i].value = value_list[i];
    }
  }
}

edit_button.addEventListener("click", edit_switch);

save_button.addEventListener("click", save);

function save() {
  value_list = [];
  input_list.forEach((e) => {
    value_list.push(e.value);
  });
  edit_switch();
  let send = JSON.stringify({
    values: value_list,
  });
  console.log(send);
}

let password = "1234";

let edit_mode = 0;
function edit_switch() {
  if (edit_mode == 0) {
    let getpassword = prompt("Password");
    if (getpassword === password) {
      input_list.forEach((e) => {
        e.readOnly = false;
      });
      save_button.classList.remove("hidden");
      edit_button.textContent = "abbrechen";
      edit_mode = 1;
    }
  } else {
    input_list.forEach((e) => {
      e.readOnly = true;
    });
    save_button.classList.add("hidden");
    edit_button.textContent = "bearbeiten";
    edit_mode = 0;
    load();
  }
}

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

const edit_bar = document.getElementById("edit-bar");

repage();

function repage() {
  for (let i = 0; i < routes.length; i++) {
    if (routes[i] === window.location.pathname) {
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
  for (let i = 0; i < houses_maps_ids.length; i++) {
    if (i === map) {
      const activ_map = document.getElementById(houses_maps_ids[i]);
      activ_map.classList.remove("not-displayed");
      if (map === 0) {
        edit_bar.classList.add("hidden");
      } else {
        edit_bar.classList.remove("hidden");
      }
    } else {
      const inactiv_map = document.getElementById(houses_maps_ids[i]);
      inactiv_map.classList.add("not-displayed");
    }
  }
}

//date for copyright
const copyright = document.getElementById("copyright");
let date_now = new Date();
copyright.textContent = `©${date_now.getUTCFullYear()}\u00A0`;
