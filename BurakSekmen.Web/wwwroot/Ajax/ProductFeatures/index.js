$(document).ready(function () {
    
  
    listele();
    
    $('#addBtn').click(function () {
        $('#addModal').show();
    });

    $('.close').click(function () {
        $('#addModal').hide();
    });

    $('#addForm').submit(function (e) {
        e.preventDefault();
       
        var taxDto = {
            renk: $('#renk').val(),
            height : $('#height').val(),
            width : $('#width').val(),
            createddate : $('#createdDate').val(),
            
        };
        $.ajax({
            type: "Post",
            url: baseurl+"/api/Tax",
            data: JSON.stringify(taxDto),
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
            url: baseurl + "/api/Tax/"+id, 
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
            url: baseurl+"/api/tax/"+id,
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },

            success: function (response) {
                if (response.statusCode == 200) {
                    $('#editId').val(response.data.id);
                    $('#edittaxName').val(response.data.taxName);
                    $('#editrate').val(response.data.rate);
                    $('#editprice').val(response.data.price);
                    $('#editpaymetDate').val(response.data.paymetDate);
                    $('#editdescription').val(response.data.description);
                    var fullDate = response.data.paymetDate;
                    var dateOnly = fullDate.split('T')[0];
                    
                    $('#editpaymetDate').val(dateOnly);
                    $('#editdescription').val(response.data.description);
            
                    // Aynı işlemi diğer tarih alanı için yap
                    var joinFullDate = response.data.joinDate;
                    var joinDateOnly = joinFullDate.split('T')[0];
                    
                    $('#editJoinDate').val(joinDateOnly);
                   

                    
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
  
        var taxDto = {
           id: $('#editId').val(),
            taxName: $('#edittaxName').val(),
            rate: $('#editrate').val(),
            price: $('#editprice').val(),
            paymetDate: $('#editpaymetDate').val(),
            description: $('#editdescription').val(),
        };
        $.ajax({
            type: "Put",
            url: baseurl+"/api/Tax/",
            data: JSON.stringify(taxDto),
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
        url: baseurl+"/api/Tax", // Bu URL'yi kendi controller'ınızın URL'siyle değiştirin
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
                            '<td>' + item.taxName + '</td>' +
                            '<td>' + item.rate + '</td>' +
                            '<td>' + item.price + '</td>' +
                            '<td>' + item.paymetDate + '</td>' +
                            '<td>' + item.description + '</td>' +
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