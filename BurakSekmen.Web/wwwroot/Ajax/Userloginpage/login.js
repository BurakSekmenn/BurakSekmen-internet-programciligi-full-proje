


    $(document).ready(function () {
        baseurl = "https://localhost:7175/";
        $("#register").click(function (e) { 
            e.preventDefault();
            var register = {
                Firstname: $("#firstname").val(),
                Lastname: $("#lastname").val(),
                UserName: $("#username").val(),
                Email: $("#email").val(),
                Password: $("#password").val(),
            };         
            console.log(baseurl);   
            $.ajax({
                type: "POST",
                url: baseurl + "api/user/register",
                contentType: "application/json",
                data: JSON.stringify(register),
                success: function (response) {
                    iziToast.success({
                        title: 'Success',
                        message: 'Kayıt işlemi başarılı bir şekilde gerçekleşti. Giriş sayfasına yönlendiriliyorsunuz.',
                        position: 'topRight',
                        setTimeout: 3000
                    });
                    setTimeout(function() {
                        window.location.href = "/login";
                    }, 2000); 
                },
                error: function (xhr, status, error) {
                    var errorMessages;
                    if (xhr.responseJSON && xhr.responseJSON.errors) {
                        errorMessages = xhr.responseJSON.errors.join("<br>");
                    } else {
                        errorMessages = "Bilinmeyen bir hata oluştu.";
                    }
                    iziToast.error({
                        title: 'Hata',
                        message: errorMessages,
                    });
                }
            });
        });
        $("#login").click(function (e) { 
            e.preventDefault();
            var model = {
                email: $("#email").val(),
                password: $("#password").val(),
            };
            console.log(model);
            $.ajax({
                type: "Post",
                url:  baseurl + "api/user/Token",
                data: JSON.stringify(model),
                contentType: "application/json",
                success: function (response) {
                    console.log(response.data);
                    iziToast.success({
                        title: 'Success',
                        message: 'Kayıt işlemi başarılı bir şekilde gerçekleşti. Giriş sayfasına yönlendiriliyorsunuz.',
                        position: 'topRight',
                        setTimeout: 3000
                    });
                    setTimeout(function() {
                        window.location.href = "/Admin";
                    }, 2000);
                    localStorage.setItem("token", response.data.token);
                    localStorage.setItem("email", response.data.email);
                    localStorage.setItem("username", response.data.userName);
                },
                error: function (xhr, status, error) {
                    var errorMessages;
                    if (xhr.responseJSON && xhr.responseJSON.errors) {
                        errorMessages = xhr.responseJSON.errors.join("<br>");
                    } else {
                        errorMessages = "Kullanıcı Adı Veya Parola Hatalı.";
                    }
                    iziToast.error({
                        title: 'Hata',
                        message: errorMessages,
                    });
                }
            });
        });
   

});


