// Material Select Initialization
// Initialize select list
$(document).ready(function () {
    //  getAllBooks();

    $('#viewBooksTable').DataTable({
        "processing": true,
        "serverSide": false,
        "ajax": { "url": "getBookList", "dataSrc": "" },
        "columns": [
            { "data": "bookId" },
            { "data": "title" },
            { "data": "type" },
            { "data": "publishingYear" },
            { "data": "isbn" }
        ]
    });
    $('.dataTables_wrapper').find('label').each(function () {
        $(this).parent().append($(this).children());
    });
    $('.dataTables_filter').find('input').each(function () {
        $('input').attr("placeholder", "Search");
        $('input').removeClass('form-control-sm');
    });
    $('.dataTables_length').addClass('d-flex flex-row');
    $('.dataTables_filter').addClass('md-form');
    $('select').addClass('mdb-select');
    $('.mdb-select').material_select();
    $('.mdb-select').removeClass('form-control form-control-sm');
    $('.dataTables_filter').find('label').remove();
});
