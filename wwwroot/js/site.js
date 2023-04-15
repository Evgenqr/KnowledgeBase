
$(document).ready(function (e) {
    let arr_of_id = [];

    $(".del-file").click(function (e) {
        arr_of_id.push($(this).data("pg"))
        let elem = 'document-' + $(this).data('bk') + '-' + $(this).data('pg');
        document.getElementById(elem).remove();
        console.log('arr_of_id ', arr_of_id);
        $("#arr_of_id").val(arr_of_id.join(','));
    });
    
    //$('#document-form').on('submit', function (e) {
    //    $.post(this.action, { arr_of_id: arr_of_id }, function (data) {
    //        console.log('ok ', arr_of_id);
    //    });
    //});
})


