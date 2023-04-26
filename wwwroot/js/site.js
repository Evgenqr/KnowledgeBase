$(document).ready(function (e) {
    let arr_of_id = [];
    $(".del-file").click(function (e) {
        arr_of_id.push($(this).data("pg"))
        let elem = 'document-' + $(this).data('bk') + '-' + $(this).data('pg');
        document.getElementById(elem).remove();
        let goarr = (arr_of_id.join(','));
        $("#arr_of_id").val(arr_of_id.join(','));
    });
})


