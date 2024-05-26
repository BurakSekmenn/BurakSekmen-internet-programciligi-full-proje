
    var token = localStorage.getItem("token");
    var email = localStorage.getItem("email");
    var username = localStorage.getItem("username");

   
    if (!token || !email || !username) {
        window.location.href = "/login"; // Login sayfasının URL'si
    }
  
   
  