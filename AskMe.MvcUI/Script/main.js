$(document).on("click", ".modal-delete-open", function () {
    $("#modal-default-delete").modal("show");
    $("#user-modal-name").val($(this).data("name"));
    $("#user-modal-desc").val($(this).data("description"));
    $("#kullanici-sil-id").val($(this).data("id"));
});


$(document).on("click", ".user-modal-delete", function () {
    var id = $("#kullanici-sil-id").val();
    $.ajax({
        type: "POST",
        url: "/category/remove",
        data: ({ "id": id }),
        dataType: "html",
        success: function (response) {
            var result = $(response).find('.category-list').html();
            $('.category-list').html(result);
            toastr.success("Kategori başarılı bir şekilde silindi.", "Başarılı");
            $("#modal-default-delete").modal("hide");

        }, error: function (response) {
            toastr.error("Kategori silinemedi", "Hata")
            $("#modal-default-delete").modal("hide");
        }
    });
});