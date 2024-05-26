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
        var customerDto = {
            contactName: $('#contactName').val(),
            companyName: $('#companyName').val(),
            address: $('#address').val(),
            city: $('#city').val(),
            country: $('#country').val(),
            phone: $('#phone').val(),
            nots: $('#nots').val(),
            createdDate: $('#createdDate').val()
        };
        $.ajax({
            type: "Post",
            url: baseurl+"/api/Customer",
            data: JSON.stringify(customerDto),
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
                    $('#addModal').hide();
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
            url: baseurl + "/api/Customer/"+id, 
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },
            success: function (response) {
                if (response.statusCode == 201) {
                    iziToast.success({
                        title: 'Success',
                        message: "Veri başarılı bir şekilde Silindi.",
                        position: 'topRight',
                        setTimeout: 3000
                    });
                    $('#veri').empty(); // Tabloyu temizle
                    listele();
                }
                else {
                    iziToast.error({
                        title: 'Hata',
                        message: "Veri silinirken bir hata oluştu.",
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
            url: baseurl+"/api/Customer/"+id,
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },

            success: function (response) {
                if (response.statusCode == 200) {
                   
                    $('#editId').val(response.data.id);
                    $('#editcontactName').val(response.data.contactName);
                    $('#editcompanyName').val(response.data.companyName);
                    $('#editaddress').val(response.data.address);
                    $('#editcity').val(response.data.city);
                    $('#editcountry').val(response.data.country);
                    $('#editphone').val(response.data.phone);
                    $('#editnots').val(response.data.nots);
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
  
        var customerDto = {
            id: $('#editId').val(),
            contactName: $('#editcontactName').val(),
            companyName: $('#editcompanyName').val(),
            address: $('#editaddress').val(),
            city: $('#editcity').val(),
            country: $('#editcountry').val(),
            phone: $('#editphone').val(),
            nots: $('#editnots').val(),
            createdDate: $('#editcreatedDate').val()

        };
        $.ajax({
            type: "Put",
            url: baseurl+"/api/Customer",
            data: JSON.stringify(customerDto),
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },
            success: function (response) {
                if (response.statusCode == 204) {
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
        url: baseurl+"/api/Customer", // Bu URL'yi kendi controller'ınızın URL'siyle değiştirin
        contentType: "application/json",
        headers: {
         
            "Authorization": "Bearer " + token
        },
        success: function (response) {
            if (response.statusCode = 200) {
                console.log(response);
                console.log(response.data);
               var sırano = 1;
                $.each(response.data, function(index, item) {
                    $('#veri').append(
                        '<tr>' +
                            '<td>' + sırano + '</td>' +
                            '<td>' + item.contactName + '</td>' +
                            '<td>' + item.companyName + '</td>' +
                            '<td>' + item.address + '</td>' +
                            '<td>' + item.city + '</td>' +
                            '<td>' + item.country + '</td>' +
                            '<td>' + item.phone + '</td>' +
                            '<td>' + item.nots + '</td>' +
                            '<td>' + item.createdDate + '</td>' +
                            '<td>' +
                                '<button type="button" class="btn btn-primary" id="edit" data-id="' + item.id + '">Düzenle</button>' +
                                '<button type="button" class="btn btn-danger ml-2 mt-2" id="delete" data-id="' + item.id + '">Sil</button>' +
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