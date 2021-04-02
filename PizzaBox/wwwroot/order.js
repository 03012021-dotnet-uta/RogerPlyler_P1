var customerID;
var storenum;
var total = 0.00;
var itemPrice = [0.00];
var itemID = [0];
var pendingItem = 0;
var pendingRemoveItem = 0;
var orderID;

var FirstName = "";
var LastName = "";

//item that will persist the Cart;
var fullCart = [];

class Cart {
    constructor(itemId, amount, storeId) {
        this.itemId = itemId;
        this.amount = amount;
        this.storeId = storeId;
    }
}



//Inputs feilds
var storeInput = document.getElementById("stores");
var itemInput = document.getElementById("items");
var amountInput = document.getElementById("amount");
var cartInput = document.getElementById("cart");
var removeInput = document.getElementById("remove");

var totalText = document.getElementById("TotalText");

//Documents Sections

var customerView = document.getElementById("CustomerSection");
var storeView = document.getElementById("StoreSection");
var itemView = document.getElementById("ItemSection");
var cartView = document.getElementById("CartSection");

//Displays For Stores and Items
var storeInfo = document.getElementById("storeDisplay");
var itemInfo = document.getElementById("itemDisplay");



function viewCustomers() {
    
    customerView.style.display = "block";
    storeView.style.display = "none";
    itemView.style.display = "none";
    cartView.style.display = "none";
}
viewCustomers();
function viewStores() {
    customerView.style.display = "none";
    storeView.style.display = "block";
    itemView.style.display = "none";
    cartView.style.display = "none";
}

function viewItems() {
    customerView.style.display = "none";
    storeView.style.display = "none";
    itemView.style.display = "block";
    cartView.style.display = "none";
}

function viewCart() {
    customerView.style.display = "none";
    storeView.style.display = "none";
    itemView.style.display = "none";
    cartView.style.display = "block";
}



function createStoreOptions() {
    fetch('api/Astore')
        .then(response => response.json())
        .then(data => { data.forEach(store => storeInput.add(new Option(store.storeName, store.id))); });

}
createStoreOptions();

async function findCustomer(FirstName, LastName) {
    if (FirstName != "" && LastName != "") {
        await fetch('api/Acustomer/' + FirstName + '/' + LastName)
            .then(response => response.json() )
            .then(data => {
                if (data.id == 0) {
                    alert("Customer Not Found");
                } else {
                    console.log(data);
                    customerID = data.id;
                }

            });
    }
        console.log(customerID);

}



function viewstores(id) {
    storenum = id;
    itemInput.innerHTML = "";
    fullCart = [];
    cartInput.innerHTML = "";
    fetch('api/Ainventorydetail/' + id)
        .then(response => response.json())
        .then(data => { addToInventory(data); })
}

function addToInventory(stock) {
    stock.forEach(item => {
        if (item.amount > 0) {
            console.log(item.itemId);
            var input = parseInt(item.itemId);
            fetch('api/Anitem/' + input)
                .then(Response => Response.json())
                .then(data => { itemInput.add(new Option(data.itemName +" " + data.price, data.id)); });
        }
    });
}

function pendingCart(itemNum) {
    pendingItem = itemNum;
    var alreadyInCart = 0;
    for (i = 0; i < fullCart.length; i++) {
        console.log("cartID " + fullCart[i].itemId);
        if (itemNum == fullCart[i].itemId) {
            alreadyInCart = fullCart[i].amount;
        }
    }
    console.log("already in cart" + alreadyInCart);
    itemAmount = 0;
    fetch('api/Ainventorydetail/' + itemNum + '/' + storenum)
        .then(response => response.json())
        .then(data => {
            itemAmount = data.amount;
            for (i = 1; i <= (itemAmount - alreadyInCart); i++) {
                amountInput.add(new Option(i, i));
            }
        });


}

function addToCart(amount) {
    var newItem = new Cart(pendingItem, amount, storenum);
    var inCartAlready = -1;
    for (i = 0; i < fullCart.length; i++) {
        if (pendingItem == fullCart[i].itemId) {
            console.log("Found in cart");
            inCartAlready = i;
        }
    }
    if (inCartAlready == -1) {
        fullCart.push(newItem);
    } else {
        var tempAmount = parseInt(fullCart[inCartAlready].amount)
        fullCart[inCartAlready].amount = parseInt(amount) + tempAmount;
    }
    console.log(fullCart);
    updateCart();
    amountInput.innerHTML = "";

}
//old one just in case
//function updateCart() {
//    cartInput.innerHTML = "";
//    for (i = 0; i < fullCart.length; i++) {
//        cartInput.add(new Option(fullCart[i].itemId, i));
//    }

//}

async function updateCart() {
    cartInput.innerHTML = "";
    total = 0;
    for (i = 0; i < fullCart.length; i++) {
        await fetch('api/anitem/' + fullCart[i].itemId)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                total += fullCart[i].amount * data.price;
                cartInput.add(new Option(fullCart[i].amount + " " + data.itemName + " " + fullCart[i].amount * data.price, i));
            })
        
    }
    totalText.innerHTML = "$" + total;
}

function pendingRemove(cartID) {
    console.log("cart ID " + cartID);
    var tempItem = fullCart[cartID];
    pendingRemoveItem = cartID;
    for (i = 0; i <= tempItem.amount; i++) {
        removeInput.add(new Option(i, i));
    }

}

function removeFromCart(amountToRemove) {
    fullCart[pendingRemoveItem].amount -= amountToRemove;
    removeInput.innerHTML = "";
    updateCart();
}

function submitOrder() {
   
    if (customerID <= 0 || customerID == null) {
        alert("Please log in");
    } else if (fullCart.length == 0) {
        alert("Your Cart is empty");
    } else {
        alert("Order Has Been Submitted");
        fetch('api/aorder/' + customerID + '/' + storenum + '/' + total)
            .then(response => response.json())
            .then(data => { orderID = data.orderId; submitCart(); });
            //.then(data => { orderID = data.orderId; submitCart(data.orderId); });
    }

}
//had ordernumber in her before hand
function submitCart() {
    fetch('api/aorderdetail/max')
        .then(response => response.json())
        .then(data => awaitCart(data))
    
     
}
 function awaitCart(detailsNum){
     fullCart.forEach(item => {
         console.log(item);
         fetch('api/aorderDetail/submit/' + orderID + '/' + item.itemId + '/' + item.amount +"/" + detailsNum)
             .then(response => response.json())
             .then(data => { console.log(data); })
         detailsNum += 1;

     });
}

async function validateCart() {
    var isvalid = true
    for (i = 0; i < fullCart.length; i++) {
        
        await fetch('api/ainventorydetail/validate/' + fullCart[i].itemId + "/" + fullCart[i].storeId + "/" + fullCart[i].amount)
            .then(response => response.json())
            .then(data => { console.log(data); if (data == false) { isvalid = false; } })
    }
    console.log("is valid" + isvalid);
    if (isvalid) {
        submitOrder();
    } else {
        alert("order is no longer valid");
    }
    
}

displayStores(1);
function displayStores(displayingStore) {
    storeInfo.innerHTML = "";
    console.log("Displaying store " + displayingStore);
    fetch("api/astoredetail/" + displayingStore)
        .then(response => response.json())
        .then(data => {
            var img = document.createElement('img');
            img.src = data.srcImg;
            storeInfo.innerHTML += "<br>" + data.descript + "<br>";
            storeInfo.appendChild(img);
        });
}

function displayItems(displayingitem) {
    itemInfo.innerHTML = "";
    console.log("Displaying store " + displayingitem);
    fetch("api/anitemdetail/" + displayingitem)
        .then(response => response.json())
        .then(data => {
            var img = document.createElement('img');
            img.src = data.srcImg;
            itemInfo.innerHTML += "<br>" + data.descript + "<br>";
            itemInfo.appendChild(img);
        });
}