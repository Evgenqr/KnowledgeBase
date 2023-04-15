// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function (e) {
    let arr_of_id = [];
    $(".del-file").click(function (e) {
        arr_of_id.push($(this).data("pg"))
        let elem = 'document-' + $(this).data('bk') + '-' + $(this).data('pg');
        document.getElementById(elem).remove();
        console.log('arr_of_id ', arr_of_id);
        return arr_of_id;
    });



    $('#document-form').on('submit', function (e) {
        e.preventDefault();
        var arr_of_id = $(".del-file").map(function () {
            return $(this).data("pg");
        }).get();
        $.post({
            url: this.action,
            data: {
                arr_of_id: JSON.stringify(arr_of_id)
            },
            success: function (result) {
                console.log(result);
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });
    });

    //$('#document-form').on('submit', function (e) {
    //    e.preventDefault();
    //    $.post(this.action, { arr_of_id: arr_of_id }, function () {
    //        console.log('ok ', arr_of_id);
    //    });
    //});
})

