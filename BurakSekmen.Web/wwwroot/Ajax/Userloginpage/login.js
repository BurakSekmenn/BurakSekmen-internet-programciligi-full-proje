


    $(document).ready(function () {
        baseurl = "https://localhost:7175/";

        $("#register").click(function (e) { 
            e.preventDefault();
            var register = {
                Firstname : $("#firstname").val(),
                Lastname : $("#lastname").val(),
                UserName : $("#username").val(),
                Email :     $("#email").val(),
                Password : $("#password").val(),
            };
            
            console.log(baseurl);   

        $.ajax({
            type: "POST",
            url: baseurl+"api/user/register",
            contentType: "application/json",
            data: JSON.stringify(register),
            success: function (response) {
                iziToast.success({
                    title: 'Success',
                    message: 'User Registered Successfully',
                    position: 'topRight',
                    setTimeout: 3000

                });


                  setTimeout(function() {
                    window.location.href = "/login";
                  }, 5000); // 3 saniye (3000 ms) bekleyip yönlendirme yapar
            },
            error: function (xhr, status, error) {
                var errorMessages = xhr.responseJSON.errors.join("<br>");
                iziToast.error({
                    title: 'Hata',
                    message: errorMessages,
                });
            }
            
    
        })
    });
   

});


