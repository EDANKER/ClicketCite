let activeRegist = document.getElementById("Regist_Active");
let activeLogin = document.getElementById("Login_Active");

let nameInputRegist = document.getElementById("nameInput").value;

let isButton = true;

function KlickRegist() {
    activeRegist.style.display = "flex";
    activeLogin.style.display = "none";
}

function KlickLogin() {
    activeLogin.style.display = "flex";
    activeRegist.style.display = "none";
}