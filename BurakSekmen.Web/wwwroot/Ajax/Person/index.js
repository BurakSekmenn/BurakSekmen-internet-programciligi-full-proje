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
        // Silme işlemi için gerekli kodları buraya ekleyebilirsiniz
        console.log('Sil butonuna tıklandı, id:', id);
        console.log(baseurl);
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
            console.log(response.data.length); // Veri dizisinin uzunluğunu kontrol et
            if (response.statusCode = 200) {
                console.log(response.data); // Tüm veriyi konsola yazdır
            
               
                $.each(response.data, function(index, item) {
                    console.log("Item:", item); // Her bir öğenin içeriğini konsola yazdır
                    console.log("Item:", index); // Her bir öğenin içeriğini konsola yazdır
                    // Tabloya satır ekleme
                    console.log(response.data.length); // Veri dizisinin uzunluğunu kontrol et
                    $('#veri').append(
                        '<tr>' +
                            '<td>' + item.id + '</td>' +
                            '<td>' + item.name + '</td>' +
                            '<td>' + item.surname + '</td>' +
                            '<td>' + item.email + '</td>' +
                            '<td>' + item.createdDate + '</td>' +
                            '<td>' +
                                '<button type="button" class="btn btn-primary" id="edit" data-id="' + item.id + '">Düzenle</button>' +
                                '<button type="button" class="btn btn-danger" id="delete" data-id="' + item.id + '">Sil</button>' +
                            '</td>' +
                        '</tr>'
                    );
                });
            } 
        },
        error: function(xhr, status, error) {
            console.error('Sunucu hatası:', error);
        }
    });

};

$('.btn-edit').click(function() {
    var id = $(this).data('id');
    // Düzenleme işlemi için gerekli kodları buraya ekleyebilirsiniz
    console.log('Düzenle butonuna tıklandı, id:', id);
});