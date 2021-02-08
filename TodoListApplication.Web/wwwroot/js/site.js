// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#category_table').DataTable();
});

$(document).ready(function () {
    $('#category_details_table').DataTable();
});

$(function () {
    $(".datepicker").datetimepicker({
        dateFormat: 'yy-mm-dd',
        timeFormat: 'HH:mm',
        showButton: true,
        minDate: new Date(),
        maxDate: '1y',
        onSelect: function (date) {
            let dateNow = new Date();
            let dateSelect = new Date(date);
            dateNow.setHours(0, 0, 0, 0);

            //NOT COMPLETED
            if (dateNow > dateSelect) {
                $('#warning').show().text("End date can not be older than start date.")
            }
            else {
                $('#warning').hide()
            }
        }
    });
});