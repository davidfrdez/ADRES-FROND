
const Login = () => {
    let UserDTO = new Object;
    UserDTO.Usuario = document.getElementById("Usuario").value;
    UserDTO.PASS = document.getElementById("Contraseña").value;
    $.ajax({
        url: "/Home/Authentication",
        type: "POST",
        data: UserDTO,
        success: (e) => {
            if (e == 200) {
                location.href = "/Home/Contenidos";
            } else {
                alert("Contraseña y usuario " )
            }
        },
        error:(e) => {
            console.log(e);
        }
    });

}