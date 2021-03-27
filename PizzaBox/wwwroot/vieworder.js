﻿var outputFeild = document.getElementById("output");

function displayOrders(orders) {
    console.log(orders);
    var display = "";

     fetch('api/AorderDetail/' + orders.orderId)
         .then(response => response.json())
         .then(data => { displayItems(orders, data);});

    

}

function displayItems(order, items) {
    outputFeild.innerHTML += "<br>Order " + order.orderId;

    for (i = 0; i < items.length; i++) {
        console.log(items[i]);
        outputFeild.innerHTML += "<br>       Item #" + items[i].itemId;
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
