

const post = async () => {
    const name = document.querySelector("#name").value
    const lastName = document.querySelector("#lastName").value
    const email = document.querySelector("#email").value
    const password = document.querySelector("#password").value


    const user = {
        name,
        lastName,
        email,
        password
    };
   
    try {
        const response = await fetch('api/Users',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)

            }

        );
        if (response.ok)
        {
            const data = await response.json();
            alert("your sign was successed");
           
        }
        else {
            throw Error("your sign was failed");
            
        }
    }
    catch (e) {
        alert(e.message)
    }
    
};


const get = async () => {


    const Email = document.querySelector("#email1").value
    const Password = document.querySelector("#password1").value

    const UserLogin = {

        Email,
        Password
    };
    try {
    const response = await fetch('api/Users/login',
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(UserLogin)

        }

        );
     if (response.ok) {
         const currentUser = await response.json();
         sessionStorage.setItem("currentUser", JSON.stringify(currentUser))
         window.location.href="UserDetails.html"
             
         
 
    }
        else {

        throw Error("your details arent found");
        console.log("")
    }
       }
        catch (e) {
        alert(e.message)
    }


}
