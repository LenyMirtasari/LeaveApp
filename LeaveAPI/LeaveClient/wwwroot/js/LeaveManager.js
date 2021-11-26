$(document).ready(function () {
    $('#leaveManager').DataTable({
        'ajax': {
            'url': "/Employees/RequesterManager/" + 2,
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
                "data": "submitDate",
                "render": function (date) {
                    var date;
                    date = date.toString();
                    dateTime = date.substring(0, 10);
                    return dateTime;
                }
            },
            {
                "data": "",

                "render": function (data, type, row, meta) {
                    return `<button type="button" class="btn btn-primary " data-toggle="tooltip" data-placement="top" title="Detail" data-bs-toggle="modal" onclick="ModalLeave(${row['leaveDetailId']})" data-bs-target=""><small>Details</small></button>`
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
            d = result.startDate.split('T')[0];
            $("#startDate1").val(d);
            f = result.endDate.split('T')[0];
            $("#endDate1").val(f);
            $("#leaveType1").val(result.leaveType);
            $("#note1").val(result.note);
          
            console.log(d);
          
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
            console.log(result)        
                Swal.fire(
                    'Good job!',
                    'Data Approve!',
                    'success'
                )
                $("#ModalLeave").modal("toggle"),
                $('#ModalLeave').modal('hide'),
                $('#leaveManager').DataTable().ajax.reload();          
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
            console.log(result)
            Swal.fire(
                'Good job!',
                'Leave Request Disapproved !',
                'success'
            )
            $("#ModalLeave").modal("toggle"),
                $('#ModalLeave').modal('hide'),
                $('#leaveManager').DataTable().ajax.reload();
        }
    })
}

function WithoutTime(dateTime) {
    var date = new Date(dateTime.getTime());
    date.setHours(0, 0, 0, 0);
    return date;
}