function displayStatus(isOk, text) {
    const statusDiv = document.getElementById("statusMessages");
    const statusText = document.createElement("h1");
    statusDiv.style.color = isOk ? "03d3b2" : "red";
    statusText.innerHTML = text;
    statusDiv.append(statusText);
  }
document.getElementById("addressInput").addEventListener("click", (e) => {
  e.preventDefault();
  const city = document.getElementById("city").value;
  const street = document.getElementById("street").value;
  const house = document.getElementById("house").value;
  const flat = document.getElementById("flat").value;

  const addresses = {
    city: city,
    street: street,
    houseNumber: house,
    flatNumber: flat,
  };
  document.getElementById("statusMessages").innerHTML = "";
  fetch("https://localhost:7185/Addresses", {
    method: "POST",
    body: JSON.stringify(addresses),
    headers: {
      Accept: "text/json",
      "Content-Type": "application/json",
    },
     })
  .then((res) => {
           if (res.ok) {
             displayStatus(res.ok, "Address successfully added.");
           } else {
            throw new Error(res.statusText);
           }
         })
         .catch((error) => {
           displayStatus(false, `Something went wrong. Server returned: ${error}.`);
         });
});

document.getElementById("loginInput").addEventListener("click", (e) => {
    e.preventDefault();
    const userName = document.getElementById("UserName").value;
    const pass = document.getElementById("Password").value;    
  
    const logins = {
      userName: userName,
      password: pass,           
    };
    
    document.getElementById("statusMessages").innerHTML = "";
    fetch("https://localhost:7185/Logins", {
      method: "POST",
      body: JSON.stringify(logins),
      headers: {
        Accept: "text/json",
        "Content-Type": "application/json",
      },
       })
    .then((res) => {
             if (res.ok) {
               displayStatus(res.ok, "Login successfully added.");
             } else {
              throw new Error(res.statusText);
             }
           })
           .catch((error) => {
             displayStatus(false, `Something went wrong. Server returned: ${error}.`);
           });
  });

  document.getElementById("userInput").addEventListener("click", (e) => {
    e.preventDefault();
    const name = document.getElementById("Name").value;
    const surname = document.getElementById("Surname").value; 
    const idNo = document.getElementById("IdNumber").value; 
    const phone = document.getElementById("Phone").value; 
    const mail = document.getElementById("Mail").value; 
    const photo = document.getElementById("Photo").value;
    const loginId = logins.loginId;
    const addrId = addresses.addressId;
  
    const user = {
      loginId: loginId,
      addressId: addrId,
      name: name,
      surName: surname,
      idNumber: idNo,
      phone: phone,
      mail: mail,
      photo: photo,      
    };
    document.getElementById("statusMessages").innerHTML = "";
    fetch("https://localhost:7185/Users", {
      method: "POST",
      body: JSON.stringify(user),
      headers: {
        Accept: "text/json",
        "Content-Type": "application/json",
      },
       })
    .then((res) => {
             if (res.ok) {
               displayStatus(res.ok, "User successfully added.");
             } else {
              throw new Error(res.statusText);
             }
           })
           .catch((error) => {
             displayStatus(false, `Something went wrong. Server returned: ${error}.`);
           });
  });
  