const container = document.getElementById('container');
const regiterBtn = document.getElementById('register');
const loginBtn = document.getElementById('login');


regiterBtn.addEventListener(
    'click', () => {
        container.classList.add("active");
    })

loginBtn.addEventListener(
    'click', () => {
        container.classList.remove("active");
    })