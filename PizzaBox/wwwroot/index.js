var storeDisplay = document.getElementById("storeDisplay");

async function displayStores() {
    storeDisplay.innerHtml = "";
    await fetch("api/astoredetail")
        .then(Response => Response.json())
        .then(data => data.forEach(store => {
            console.log(store);
            var img = document.createElement('img');
            img.src = store.srcImg;
            storeDisplay.innerHTML += "<br>"+store.descript + "<br>";
            storeDisplay.appendChild(img);
        }));
}
displayStores();

