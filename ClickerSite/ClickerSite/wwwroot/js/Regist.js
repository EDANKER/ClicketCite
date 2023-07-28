let activeRegist = document.getElementById("Regist_Active");
let activeLogin = document.getElementById("Login_Active");
function ClickRegist() {
    activeRegist.style.display = "flex";
    activeLogin.style.display = "none";
}
function ClickLogin() {
    activeLogin.style.display = "flex";
    activeRegist.style.display = "none";
}

function ClickBox(){
    activeRegist.style.display = "flex";
    activeLogin.style.display = "none";
}