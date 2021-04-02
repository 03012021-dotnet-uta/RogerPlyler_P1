function myFunction() {
    var input, filter, ul, li, a, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    ul = document.getElementById("myUL");
    li = ul.getElementsByTagName("li");
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}

function populateCustomers() {
    ul = document.getElementById("myUL");

    fetch('api/acustomer')
        .then(response => response.json())
        .then(data => data.forEach(customer => {
            var li = document.createElement("li");
            var atag = document.createElement("a");
            atag.href = "#";
            atag.innerHTML = customer.fname + " " +customer.lname;
            
            li.appendChild(atag);
       
            ul.appendChild(li);
        }))
}
populateCustomers();