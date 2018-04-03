// Write your JavaScript code.

//SignIn loading
$(document).ready(function () {
    console.log("teste");
        $('#signInBttn').click(function () {
            $('#popUp').load('@Url.Action("SignIn", "HomeController")');
        });
    });
