
const register = async () => {
    if (checkPassword()) {
        var user = {
            email: document.getElementById("email").value,
            password: document.getElementById("password").value,
            firstName: document.getElementById("firstName").value,
            lastName: document.getElementById("lastName").value,
        }
        try {
            const responsePost = await fetch('api/Users', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });    
            if (!responsePost.ok) {
                alert(`${user.firstName} not register`)
            }
            else {
                const newUser = await responsePost.json();
                alert(`${newUser.firstName} register`)
            }
        }
        catch (error) {
            alert(error, "error")
        }

    }

}


const login = async () => {
  
    let userLogin = {
        email: document.getElementById("emailLog").value,
        password : document.getElementById("passwordLog").value
    }

    try {
        const responsePost = await fetch('api/Users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userLogin)
        });
        if (!responsePost.ok) {
            alert(`not login`)
        }
        else {
            const User = await responsePost.json();
            sessionStorage.setItem("user", JSON.stringify(User))
            window.location.href = "./Products.html"

        }
    }
    catch (error) {
        alert(`not login`)
    }
}



const update = async () => {
    var user = {
        
        firstName: document.getElementById("firstNameUp").value,
        lastName: document.getElementById("lastNameUp").value,       
        password: document.getElementById("passwordUp").value,
        email: document.getElementById("emailUp").value,
       
    }
    var id = JSON.parse(sessionStorage.getItem("user")).userId
  //  alert(id)
    try {
        const responsePut = await fetch(`api/Users/${id}`,
            {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
        if (!responsePut.ok) {
            alert("not update")
        }
        else {
            const updateUser = await responsePut.json()
            window.location.href = "./Products.html"
        }
    }
    catch (error) {
        alert(error)
    }

}
const checkPassword = async () => {


    var password = document.getElementById("password").value;
    var meter = document.getElementById('level');

    try {
        const response = await fetch('api/Users/check', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        });
        if (!response.ok)
            alert('enter password')
        else {
            const strengthLevel = await response.json();
            if (strengthLevel <= 2) {
                meter.value = strengthLevel;
                alert('your password is weak try again')

            }
            meter.value = strengthLevel;
            return true;
        }


    }
    catch (error) {
        alert(error, "error")
    }
}
//const getById = async (id) => {


//    try {
//        const responseGet = await fetch(`api/Users/${id}`);
//        if (!responseGet.ok) {
//            alert("no user")
//        }
//        else {
//            const dataGet = await responseGet.json();
//            console.log(dataGet)
//        }

//    }
//    catch (error) {
//        alert(error)
//    }
//}


