$(document).ready(function () {
    $('#leaveManager').DataTable({
        'ajax': {
            'url': "/Employees/RequesterManager/" + 3,
            'dataSrc': ''
        },
        'columns': [
            {
                "data": "no",
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "leaveDetailId"
            },
            {
                "data": "employeeId"
            },
            {
                "data": "fullName"
            },
            {
                "data": "jobTittle"
            },
            {
                "data": "email"
            },
            {
                "data": "phoneNumber"
            },
            {
                "data": "submitDate"
            },
            {
                "data": "",

                "render": function (data, type, row, meta) {
                    return `<button type="button" class="btn btn-sm btn-primary " data-toggle="tooltip" data-placement="top" title="Detail" data-bs-toggle="modal" onclick="ModalLeave(${row['leaveDetailId']})" data-bs-target="">Details</button>`
                }

            }
        ]
    });
});

function ModalLeave(id) {
    /*console.log(nik);*/

    $.ajax({
        url: "/LeaveDetails/GetLeaveDetail/" + id,
        success: function (result) {
            console.log(result);
            $("#ModalLeave").modal("show");
            $("#leaveDetailId1").val(result.leaveDetailId);
            $("#employeeId1").val(result.employeeId);
            $("#fullName1").val(result.fullName);
            $("#startDate1").val(result.startDate);
            $("#endDate1").val(result.endDate);
            $("#leaveType1").val(result.leaveType);
            $("#note1").val(result.note);
          
        }
    })
}

function Approve(id) {

    $.ajax({
          headers: {
           'Content-Type': 'application/json',
           'charset': 'utf-8'
        },
        url: "https://localhost:44312/API/LeaveDetails/Approve/" + id,
        type: "PUT",
        success: function (result) {
            console.log(result);
        }
    })
}

function Disapprove(id) {
    $.ajax({
        headers: {
            'Content-Type': 'application/json',
            'charset': 'utf-8'
        },
        url: "https://localhost:44312/API/LeaveDetails/Disapprove/ " + id,
        type: "DELETE",
        success: function (result) {
            console.log(result);
        }
    })
}