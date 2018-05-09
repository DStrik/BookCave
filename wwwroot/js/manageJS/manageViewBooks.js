// Material Select Initialization
// Initialize and fill out the table.
$(document).ready(function () {

    var table = $('#viewBooksTable').DataTable({
        "processing": true,
        "serverSide": false,
        "ajax": { "url": "getBookList", "dataSrc": "" },
        "scrollX": "100%",
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
                        '<div class="text-center"><button class="btn btn-sm btn-danger" onclick="giveModalBookData(\''
                        + data.title + '\', ' + data.bookId + ')" data-toggle="modal" data-target="#confirmDelete" value="'
                        + data.bookId + '">Delete</button>'
                        + '<a class="btn btn-sm btn-warning" href="/Manage/ModifyBookById/' + data.bookId + '">Modify</a> </div>';
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
});



function giveModalBookData(title, id) {
    $("#modalText span").text(title);
    $("#yesDelete").one("click", (function () {
        $("#confirmDelete").modal("hide");
        $("#waitingModal").modal("show");
        $.post("/Manage/RemoveBookById", { "id": id }, function (id) {
            {
                $("#waitingModal").modal("hide");

                /* $("").click(function(event) {
                     $(this).closest("tr").remove();
                 });*/
            }
        }).fail(function () {
            $("#waitingModal").modal('hide');
            $("#errorModal").modal('show');

        });
    }));
};


