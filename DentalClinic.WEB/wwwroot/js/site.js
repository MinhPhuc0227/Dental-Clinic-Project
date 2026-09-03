function toggleUserMenu() {
    const dropdown = document.getElementById("userDropdown");

    if (!dropdown) return;

    dropdown.classList.toggle("show");
}

document.addEventListener("click", function (event) {
    const userMenu = document.querySelector(".user-menu");
    const dropdown = document.getElementById("userDropdown");

    if (!userMenu || !dropdown) return;

    if (!userMenu.contains(event.target)) {
        dropdown.classList.remove("show");
    }
});