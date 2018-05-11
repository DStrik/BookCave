// Material Select Initialization
// Initialize and fill out the table.
var deleteRow;
$(document).ready(function () {
    console.log("Manage View EmployeeList up and running");

    var table = $('#viewEmployeesTable').DataTable({
        "processing": true,
        "serverSide": false,
        "ajax": { "url": "getAllUsers", "dataSrc": "" },
        "autoWidth": false,
        "autoHeight": true,
        "columns": [
            { "data": "firstName" },
            { "data": "lastName" },
            { "data": "userId" },
            { "data": "role", "className": "userRoleSpace" },
            {
                "className": '',
                "data": null,
                "sortable": false,
                "searchable": false,
                "autoSize": true,
                "render": function (data, type, row, meta) {
                    var markup =
                        '<button data-toggle="modal" data-target="#ModifyEmployee" data-userId="' + data.userId 
                        + '" data-username="' + data.firstName + '"data-oldRole="' + data.role 
                        + '"class="btn btn-warning btn-sm removeUser">Modify/Remove</button>';
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



    $("#viewEmployeesTable").on("click", "button", function() {
        var parentTr = $(this).closest("tr");
        var userId = $(this).attr("data-userId");
        var userName = $(this).attr("data-username");
        var oldRole = $(this).attr("data-oldRole");
        $(".modalEmployeeName").text(userName);
        $(".curr-role").text(oldRole);

        $("#yesDelete").one("click", (function () {
            $("#ModifyEmployee").modal("hide");
            $("#waitingModal").modal("show");
            $.post("DeleteUser", { "userId": userId }, function (id) {
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

        $("#modifyRole").click(function (e) { 
            e.preventDefault();
            $("#ModifyEmployee").modal("hide");
            $("#waitingModal").modal("show");

            var newRole = $(".roles option:selected").val();
    
            var changeValue = {
                "OldRole" : oldRole,
                "NewRole" : newRole,
                "UserId" : userId
            }

            $.post("ChangeUsersRole", changeValue, function(data, status) {
                parentTr.find(".userRoleSpace").text(newRole);
                $("#successModal").modal("show");
                $("#waitingModal").modal("hide");
            }).fail(function(err) {
                setTimeout(function() {
                    $("#modifyFail").modal('show');
                    $("#waitingModal").modal('hide');
                }, 500);
            });
        });
    });

   /* $("#refreshPage").click(function (e) { 
        e.preventDefault();
        location.reload();
    });*/

});