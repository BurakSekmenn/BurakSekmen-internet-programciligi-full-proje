$(document).ready(function () {
    
  
    listele();
    
    $('#addBtn').click(function () {
        $('#addModal').show();
    });

    // Yeni personel ekleme formunu kapatma
    $('.close').click(function () {
        $('#addModal').hide();
    });

    // Yeni personel ekleme formunu submit etme
    $('#addForm').submit(function (e) {
        e.preventDefault();
        var personDto = {
            name: $('#name').val(),
            surname: $('#surname').val(),
            email: $('#email').val(),
            password: $('#password').val(),
            createdDate: $('#joinDate').val()
        };
        $.ajax({
            type: "Post",
            url: baseurl+"/api/Person",
            data: JSON.stringify(personDto),
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },
            success: function (response) {
                if (response.statusCode == 200) {
                    iziToast.success({
                        title: 'Success',
                        message: "Veri başarılı bir şekilde eklendi.",
                        position: 'topRight',
                        setTimeout: 3000
                    });
                    $('#veri').empty(); // Tabloyu temizle
                    listele();
                }
                else {
                    iziToast.error({
                        title: 'Hata',
                        message: response.message,
                    });
                }
                
            },
            error: function (xhr, status, error) {
                console.error('Sunucu hatası:', error);
            }
        });

    });

    $(document).on('click', '#delete', function() {
        var id = $(this).data('id');
   
        $.ajax({
            type: "DELETE",
            url: baseurl + "/api/person/"+id, 
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },
            success: function (response) {
                if (response.statusCode == 200) {
                    iziToast.success({
                        title: 'Success',
                        message: "Veri başarılı bir şekilde silindi.",
                        position: 'topRight',
                        setTimeout: 3000
                    });
                    $('#veri').empty(); // Tabloyu temizle
                    listele();
                }
                else {
                    iziToast.error({
                        title: 'Hata',
                        message: response.message,
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error('Sunucu hatası:', error);
            }
        });
       
    });
    $(document).on('click', '#edit', function() {
        var id = $(this).data('id');
        console.log('Düzenle butonuna tıklandı, id:', id);
        $('#editPersonModal').show();
        $.ajax({
            type: "Get",
            url: baseurl+"/api/person/"+id,
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },

            success: function (response) {
                if (response.statusCode == 200) {
                    $('#editId').val(response.data.id); 
                    $('#editName').val(response.data.name);
                    $('#editSurname').val(response.data.surname);
                    $('#editEmail').val(response.data.email);
                    $('#editpassword').val(response.data.password);
                    var createdDate = new Date(response.createdDate);
                    var year = createdDate.getFullYear();
                    var month = ('0' + (createdDate.getMonth() + 1)).slice(-2);
                    var day = ('0' + createdDate.getDate()).slice(-2);
                    var formattedDate = year + '-' + month + '-' + day;

                $('#editJoinDate').val(formattedDate);
                }              
                console.log(response);            
            },
            error: function (xhr, status, error) {
                console.error('Sunucu hatası:', error);
            }
        });       
    });

    $('.close').click(function() {
        $('#editPersonModal').hide();
    });

    $('#editPersonForm').submit(function(e) {
        e.preventDefault();
  
        var personDto = {
            id: $('#editId').val(),
            name: $('#editName').val(),
            surname: $('#editSurname').val(),
            email: $('#editEmail').val(),
            password: $('#editpassword').val(),
            createdDate: $('#editJoinDate').val()
        };
        $.ajax({
            type: "Put",
            url: baseurl+"/api/person/",
            data: JSON.stringify(personDto),
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },
            success: function (response) {
                if (response.statusCode == 200) {
                    iziToast.success({
                        title: 'Success',
                        message: "Veri başarılı bir şekilde güncellendi.",
                        position: 'topRight',
                        setTimeout: 3000
                    });
                    $('#veri').empty(); // Tabloyu temizle
                    listele();
                    $('#editPersonModal').hide();
                }
                else {
                    iziToast.error({
                        title: 'Hata',
                        message: response.message,
                    });
                }
            },
    });
});
var baseurl = "https://localhost:7175";
function listele () {
    var token = localStorage.getItem("token");
    var baseurl = "https://localhost:7175";
    console.log(token);
    console.log(baseurl);
    // AJAX isteği
    $.ajax({
        type: "GET",
        url: baseurl+"/api/person", // Bu URL'yi kendi controller'ınızın URL'siyle değiştirin
        contentType: "application/json",
        headers: {
         
            "Authorization": "Bearer " + token
        },
        success: function (response) {
            if (response.statusCode = 200) {
               var sırano = 1;
                $.each(response.data, function(index, item) {
                    $('#veri').append(
                        '<tr>' +
                            '<td>' + sırano + '</td>' +
                            '<td>' + item.name + '</td>' +
                            '<td>' + item.surname + '</td>' +
                            '<td>' + item.email + '</td>' +
                            '<td>' + item.createdDate + '</td>' +
                            '<td>' +
                                '<button type="button" class="btn btn-primary" id="edit" data-id="' + item.id + '">Düzenle</button>' +
                                '<button type="button" class="btn btn-danger ml-2" id="delete" data-id="' + item.id + '">Sil</button>' +
                            '</td>' +
                        '</tr>'
                    );
                    sırano++;
                });
            } 
        },
        error: function(xhr, status, error) {
            console.error('Sunucu hatası:', error);
        }
    });

};

});