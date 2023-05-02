function Login() {

    $.ajax({
        URL: "/Api/Login",
        succuss: function (result, e, f) {
            alert(result);
        }
        else {
            alert("bir hata meydana geldi");
        }




    })



}