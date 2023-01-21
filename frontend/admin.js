function displayStatus(isOk, text) {
    const statusDiv = document.getElementById("statusMessages");
    const statusText = document.createElement("h4");
    statusDiv.style.color = isOk ? "03d3b2" : "red";
    statusText.innerHTML = text;
    statusDiv.append(statusText);
  }
  document.getElementById("logOut").addEventListener("click", (e) => {
    e.preventDefault();
    sessionStorage.clear();
    window.location.href = "index.html";
  });

document.getElementById("getAll").addEventListener("click", (e) => {
e.preventDefault();
const state = {};

function renderUsers(users) {
  const userContainer = document.getElementById("users-container");
  userContainer.innerHTML = "";

  users.forEach((user) => {
    const userImage = document.createElement("img");
    userImage.src = user.photo;  

    const userId = document.createElement("p");
    userId.innerText = `Id: ${user.id}`;  

    const userName = document.createElement("p");
    userName.innerText = user.name;

    const userSurname = document.createElement("p");
    userSurname.innerText = user.surName;

    const userIdNumber = document.createElement("p");
    userIdNumber.innerText = user.idNumber;

    const userPhone = document.createElement("p");
    userPhone.innerText = user.phone;

    const userMail = document.createElement("p");
    userMail.innerText = user.mail;

    const userCard = document.createElement("div");
    userCard.setAttribute("class", "user-card");
    userCard.append(      
      userImage,
      userId,
      userName,
      userSurname,
      userIdNumber,
      userPhone,
      userMail  
    );
    userContainer.append(userCard);
  });
}

fetchUsers();

function fetchUsers() {
  fetch("https://localhost:7185/Users")
    .then((res) => {
      if (res.ok) {
        return res.json();
      } else {
        throw new Error(res.statusText);
      }
    })
    .then((data) => {
      state["users"] = data;
      renderUsers(data);      
    })
    .catch((error) => {
      console.error(error);
    });
}
});

document.getElementById("deleteUser").addEventListener("click", (e) => {
    e.preventDefault();
    const id = document.getElementById("userId").value;
    DeleteUserById(id);
    function DeleteUserById(id) {
        fetch("https://localhost:7185/Users"+"?id="+id, {
            method: "DELETE",
        }).then((res) => {
            if (res.ok) {
              displayStatus(res.ok, "User successfully deleted.");
            } else {
             throw new Error(res.statusText);
            }
          })
          .catch((error) => {
            displayStatus(false, `Something went wrong. Server returned: ${error}.`);
          });
    }
});

