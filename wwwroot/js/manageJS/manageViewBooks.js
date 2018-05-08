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
                    return '<div class="text-center"><button class="btn btn-sm btn-danger" onclick="giveModalBookData(\'' + data.title + '\', ' + data.bookId + ')" data-toggle="modal" data-target="#confirmDelete" value="' + data.bookId + '">Delete</button><button class="btn btn-sm btn-warning" href="' + data + '">Modify</button> </div>';
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

    $("#yesDelete").click(function () {
        alert(id);
        $.post("RemoveBookById", { "id": id }, function (id) {
            {
                alert("deleted " + title + '!');
            }
        }).fail(function () {
            alert("error lol");
        });
    });
}
