var outputFeild = document.getElementById("output");
var storeInput = document.getElementById("stores");

createStoreOptions();
async function displayOrders(orders) {
    console.log(orders);
    var display = "";
    outputFeild.innerHTML = "";
    await fetch('api/AorderDetail/' + orders.orderId)
         .then(response => response.json())
         .then(data => { displayItems(orders, data); console.log(orders); console.log(data);});

    

}

function displayItems(order, items) {
    outputFeild.innerHTML += "<br><b>Order #" + order.orderId + "order date:  " + order.orderTime + "</b> ";
    
    for (i = 0; i < items.length; i++) {
        console.log(items[i]);
        outputFeild.innerHTML += "<br>----Item #" + items[i].itemId + " amount " + items[i].total;
    }

}

function viewstoreorders(id) {
    fetch('api/Aorder/'+id+'/store')
        .then(response => response.json())
        .then(data => { for (i = 0; i < data.length; i++) { displayOrders(data[i]); }});
}

function viewcustomerorders(id) {
    fetch('api/Aorder/' + id + '/customer')
        .then(response => response.json())
        .then(data => { for (i = 0; i < data.length; i++) { displayOrders(data[i]); } });
}


function createStoreOptions() {
    fetch('api/Astore')
        .then(response => response.json())
        .then(data => { data.forEach(store => storeInput.add(new Option(store.storeName,store.id))); });
           
}

function findCustomer(FirstName, LastName) {
    fetch('api/Acustomer/' + FirstName + '/' + LastName)
        .then(response => response.json())
        .then(data => {
            if (data.id == 0) {
                alert("Customer Not");
            }
            else {
                viewcustomerorders(data.id);
            }
        });
}
            

