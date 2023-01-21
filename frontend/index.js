function displayStatus(isOk, text) {
  const statusDiv = document.getElementById("statusMessages");
  const statusText = document.createElement("h4");
  statusDiv.style.color = isOk ? "03d3b2" : "red";
  statusText.innerHTML = text;
  statusDiv.append(statusText);
}
// function setCookie()
// {
//     var info="Name="+ document.getElementById("loginName").value;
//     document.cookie=info;
// }

// function getCookie()
// {
//     if(document.cookie.length!=0)
//     {
//    //Invoking key-value pair stored in a cookie
//     alert(document.cookie);
//     }
//     else
//     {
//     alert("Cookie not available")
//     }
// }

function validateform() {
  var name = document.form.username.value;
  var password = document.form.pass.value;

  if (name == null || name == "") {
    alert("Enter username");
    return false;
  } else if (password.length < 4) {
    alert("Password must be at least 4 characters long.");
    return false;
  }
}
// validateLogin();
// function validateLogin(){
//     var username = document.getElementById("loginName").value;
//     var password = document.getElementById("loginPass").value;
//     if ( username == "ieva" && password == "ieva"){
//     alert ("Login successfully");
//     window.location.href = "admin.html"; 
//     }     
// }

// function CheckUser(user) {
//   if (user.status == 404) {
//     document.getElementById("statusMessages").innerText = "Bad login or password";
//   } else {
//     console.log(users);
//     sessionStorage.setItem("userId", user.id);
//     sessionStorage.setItem("role", user.role);
//     window.location.href = "admin.html";
//   }
// }
document.getElementById("logIn").addEventListener("click", (e) => {
  e.preventDefault();
const state = {};
function renderLogins(users) {
  users.forEach((user) => {
    const pass = user.password;
    const name = user.userName;
    const id = user.id;
    const role = user.role;
    var username = document.getElementById("loginName").value;
    var password = document.getElementById("loginPass").value;

    if (user.status == 404) {
      document.getElementById("statusMessages").innerText =
        "Bad login or password";
    } else if (
      user.userName == username &&
      user.password == password &&
      user.role == "admin"
    ) {      
      sessionStorage.setItem("userId", user.id);
      sessionStorage.setItem("role", user.role);
      document.getElementById("statusMessages").innerText = "admin panel";
      window.location.href = "admin.html";
    } else {
      console.log(users);
      document.getElementById("statusMessages").innerText = "user panel";
      window.location.href = "user.html";
    }    
  });
}

getLogins();
function getLogins() {
  fetch("https://localhost:7185/Logins")
    .then((res) => {
      if (res.ok) {
        return res.json();
      } else {
        throw new Error(res.statusText);
      }
    })
    .then((data) => {
      state["logins"] = data;
      renderLogins(data);
    })
    .catch((error) => {
      console.error(error);
    });
}});
