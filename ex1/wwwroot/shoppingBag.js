let myProduct;
let countProducts = 0;
let allPrice = 0;

const showProducts = () => {
   
     myProduct = JSON.parse( sessionStorage.getItem("products"));
    for (let i = 0; i < myProduct.length; i++) {
        countProducts++;
        allPrice += myProduct[i].price;
        drowProduct(myProduct[i]);
    }
    document.getElementById("itemCount").innerText = countProducts
    document.getElementById("totalAmount").innerText = allPrice
}

const drowProduct = (product) => {
    tempProduct = document.getElementById("temp-row");
    clon = tempProduct.content.cloneNode(true);
    clon.querySelector("img").src = "./Image/" + product.image;
    clon.querySelector(".price").innerText = product.price + "$";
   clon.querySelector(".descriptionColumn").innerText = product.description;
    clon.querySelector(".totalColumn").addEventListener('click', () => {deleteFromBag(product) });   
    document.getElementById("items").appendChild(clon);

   
}
const deleteFromBag = (product) => {
    countProducts = 0;
    allPrice = 0;
    myProduct=myProduct.filter(p=>p!==product);    
    sessionStorage.removeItem("products")
    sessionStorage.setItem("products", JSON.stringify(myProduct))
    document.getElementById("items").replaceChildren([])
    showProducts()
}


const placeOrder = async () => {
    let user = JSON.parse(sessionStorage.getItem("user"))
    if (user) {
        var order = {
            orderDate: new Date,
            orderSum: allPrice,
            userId: user.userId,
            OrderItemTbls: myProduct
        }
        try {
            const responsePost = await fetch('api/Orders', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            });
            if (!responsePost.ok) {
                alert(`the order didnt create`)
            }
            else {
                const newOrder = await responsePost.json();
                alert(`${newOrder.orderId} is created`)
                countProducts = 0;
                allPrice = 0;
                sessionStorage.removeItem("products")
                window.location.href = "./Payment.html"

            }
        }
        catch (error) {
            alert(`the order didnt create`)
        }

    }
    else {
        window.location.href = "./home.html"
    }
}

