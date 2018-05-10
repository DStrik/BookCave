// Material Select Initialization
// Initialize and fill out the table.
var deleteRow;
$(document).ready(function () {

    var table = $('#viewBooksTable').DataTable({
        "processing": true,
        "serverSide": false,
        "ajax": { "url": "getBookList", "dataSrc": "" },
        "autoWidth": false,
        "autoHeight": true,
        "columns": [
            { "data": "bookId" },
            { "data": "title" },
            { "data": "type" },
            { "data": "publishingYear" },
            { "data": "isbn" },
            {
                "className": '',
                "data": null,
                "sortable": false,
                "searchable": false,
                "autoSize": true,
                "render": function (data, type, row, meta) {
                    var markup =
                        '<div><button type="button" class="btn btn-sm btn-danger px-2 mr-2" data-toggle="modal" data-target="#confirmDelete" '
                        + 'data-code="'+ data.bookId + '" data-name="' + data.title + '">Delete</button>'
                        + '<a class="btn btn-sm btn-warning px-2" href="/Manage/ModifyBookById/' + data.bookId + '">Modify</a> </div>';
                    return (markup);
                }
            }
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

    
    deleteRow = function(deletionRow) {
        table.row(deletionRow).remove().draw( false );
    }
});


$("#viewBooksTable").on("click", "button", function() {
    var parentTr = $(this).closest("tr");
    var title = $(this).attr("data-name");
    var id = $(this).attr("data-code");
    $(".modalBookTitle").text(title);
    $("#yesDelete").one("click", (function () {
        $("#confirmDelete").modal("hide");
        $("#waitingModal").modal("show");
        $.post("/Manage/RemoveBookById", { "id": id }, function (id) {
            {
                $("#waitingModal").modal("hide");
                $("#successModal").modal("show");
                deleteRow(parentTr);
            }
        }).fail(function () {
            $("#waitingModal").modal('hide');
            $("#errorModal").modal('show');

        });
    }));
});


