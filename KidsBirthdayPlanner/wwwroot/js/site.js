// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Please see documentation ...
// Write your JavaScript code.


const colors = ["pink", "cyan", "purple"];

function createBalloon() {

    const balloon = document.createElement("div");

    balloon.classList.add("ultra-balloon");

    const color = colors[Math.floor(Math.random() * colors.length)];
    balloon.classList.add(color);

    balloon.style.left = Math.random() * 100 + "%";

    const size = 40 + Math.random() * 40;
    balloon.style.width = size + "px";
    balloon.style.height = size * 1.4 + "px";

    balloon.style.animationDuration = (10 + Math.random() * 10) + "s";

    document.body.appendChild(balloon);

    setTimeout(() => balloon.remove(), 20000);
}

setInterval(createBalloon, 800);

