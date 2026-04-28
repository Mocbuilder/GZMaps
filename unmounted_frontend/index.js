const full_map = document.getElementById("full_map");
const full_map_maxheight = full_map.clientHeight;
const full_map_70height = full_map_maxheight - (full_map_maxheight / 100) * 30;

correct_resize();

window.addEventListener("resize", (e) => {
  correct_resize();
});

function correct_resize() {
  if ((window.innerWidth < full_map.clientHeight) & ((window.innerWidth < full_map_maxheight) |
    (window.innerWidth < full_map_70height))) {
    full_map.style.height = "auto";
    full_map.style.width = "100%";
  }
  if (
    (window.innerWidth > full_map_maxheight) |
    (window.innerWidth > full_map_70height)
  ) {
    full_map.style.height = "100%";
    full_map.style.width = "auto";
  }
}
