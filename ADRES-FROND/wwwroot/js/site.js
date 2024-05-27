
document.getElementById('loginForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const UserDTO = {
        Usuario: document.getElementById("Usuario").value,
        PASS: document.getElementById("Contraseña").value
    };
    $.ajax({
        url: "/Home/Authentication",
        type: "POST",
        data: UserDTO,
        success: (response) => {
            if (response == 200) {
                console.log(response);
                location.href = "/Home/Contenidos";
            } else {
                alert("Usuario o contraseña incorrectos");
            }
        },
        error: (error) => {
            console.log(error);
        }
    });
});