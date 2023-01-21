document.getElementById("logOut").addEventListener("click", (e) => {
    e.preventDefault();
    sessionStorage.clear();
    window.location.href = "index.html";
  });

  async function updateData(id) {
    let name = document.getElementById("name").value;
    let price = document.getElementById("price").value;
    fetch("https://localhost:7185/Users", {
      method: "PUT",
      body: JSON.stringify({
        id: id,
        name: name,
        price: price,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then(function (response) {
        return response.json();
      })
      //.then(GetData());
  }

  async function getData(id) {
    let name = document.getElementById("name").value;
    let price = document.getElementById("price").value;
    fetch("https://localhost:7185/Users", {
      method: "PUT",
      body: JSON.stringify({
        id: id,
        name: name,
        price: price,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then(function (response) {
        return response.json();
      })
      //.then(GetData());
  }