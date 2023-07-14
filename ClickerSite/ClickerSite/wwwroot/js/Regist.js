let activeRegist = document.getElementById("Regist_Active");
let activeLogin = document.getElementById("Login_Active");

let nameInputRegist = document.getElementById("nameInput").value;

let isButton = true;

function registButton() {
    if (nameInputRegist.length.value === 0) {
        console.log("efef")
        isButton = false;
    }
}

function KlickRegist() {
    activeRegist.style.display = "flex";
    activeLogin.style.display = "none";
}

function KlickLogin() {
    activeLogin.style.display = "flex";
    activeRegist.style.display = "none";
}