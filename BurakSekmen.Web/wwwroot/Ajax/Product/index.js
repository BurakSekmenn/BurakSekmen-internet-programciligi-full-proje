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
        var tokenuser = localStorage.getItem("username");
        var categoryDto = {
            name : $('#name').val(),
            description : $('#description').val(),
            createdDate : $('#createdDate').val(),
            recordingName : tokenuser
            
        };
        $.ajax({
            type: "Post",
            url: "https://localhost:7175/api/Category/SaveCategory/",
            contentType: "application/json",
            data: JSON.stringify(categoryDto),
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
            url: baseurl + "/api/product/"+id, 
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },
            async: true,
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
            url: baseurl+"/api/Category/"+id,
            contentType: "application/json",
            headers: {
                "Authorization": "Bearer " + token
            },

            success: function (response) {
                if (response.statusCode == 200) {
                    console.log(response.data);
                    $('#editId').val(response.data.id);
                    $('#editname').val(response.data.name);                    
                    $('#editdescription').val(response.data.description);
            
                    // Aynı işlemi diğer tarih alanı için yap
                    var joinFullDate = response.data.createdDate;
                    var joinDateOnly = joinFullDate.split('T')[0];
                    
                    $('#editcreateDate').val(joinDateOnly);
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
        var tokenuser = localStorage.getItem("username");
        var categoryDto = {
            id: $('#editId').val(),
            name: $('#editname').val(),
            description: $('#editdescription').val(),
            createdDate: $('#editcreateDate').val(),
            recordingName : tokenuser
        };
        $.ajax({
            type: "Put",
            url: baseurl+"/api/Category/",
            data: JSON.stringify(categoryDto),
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
        url: baseurl+"/api/Product/GetCategoryAndFeatures", // Bu URL'yi kendi controller'ınızın URL'siyle değiştirin
        contentType: "application/json",
        headers: {
         
            "Authorization": "Bearer " + token
        },
        success: function (response) {
            if (response) {
                console.log(response);
                var sırano = 1;
                 $.each(response, function(index, item) {
                     $('#veri').append(
                         '<tr>' +
                             '<td>' + sırano + '</td>' +
                             '<td>' + item.name + '</td>' +
                             '<td>' + item.description + '</td>' +
                             '<td>' + item.price + '</td>' +
                             '<td>' + item.createdDate + '</td>' +
                             '<td>' + item.category.name + '</td>' +
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