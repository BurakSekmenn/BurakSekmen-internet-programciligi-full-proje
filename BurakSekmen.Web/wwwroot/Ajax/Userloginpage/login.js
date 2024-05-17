


    $(document).ready(function () {
        baseurl = "https://localhost:7175/";

        $("#register").click(function (e) { 
            e.preventDefault();
            var RegisterModel = {
                Firstname : $("#firstname").val(),
                Lastname : $("#lastname").val(),
                UserName : $("#username").val(),
                Email :     $("#email").val(),
                Password : $("#password").val(),
            };
            console.log(RegisterModel);
            console.log(baseurl);   

        $.ajax({
            type: "POST",
            url: baseurl+"api/user/register",
            data: RegisterModel,
            success: function (response) {
                console.log(response.errors);
            }
            
    
        })
    });
   

});


