const title = document.querySelector(".title")
const changeDetails = document.querySelector(".changeDetails")

const user = sessionStorage.getItem("currentUser")
const userName = JSON.parse(user).name
const userLastName = JSON.parse(user).lastName
const userEmail = JSON.parse(user).email
const userPassword = JSON.parse(user).password
const userId = JSON.parse(user).id
title.textContent = "Hi " + userName

const change = async () => {
   
    changeDetails.style.display = "block"
    const name = document.querySelector("#name")
    const lastName = document.querySelector("#lastName")
    const email = document.querySelector("#email")
    const password = document.querySelector("#password")

    name.value = userName
    lastName.value = userLastName
    email.value = userEmail
    password.value = userPassword

    
}

const put = async () => {
    const name = document.querySelector("#name").value
    const user = {
        id:userId,
        name,
        lastName: lastName.value,
        email: email.value,
        password: password.value
    };

    try {
        const response = await fetch(`/api/Users/${userId}`,
            {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)

            }

        );
        
    }
    catch (e) {
        alert(e.message)
    }

}




