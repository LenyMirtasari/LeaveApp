$(document).ready(function () {
    $('#leaveManager').DataTable({
        'ajax': {
            'url': "/Employees/RequesterManager/",
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
    leaves = "";
    $.ajax({
        url: "https://localhost:44312/API/LeaveDetails/GetLeaveDetail/" + id,
        success: function (result) {
            console.log(result);
            $("#ModalLeave").modal("show");
            $("#leaveDetailId1").val(result.leaveDetailId);
            d = result.startDate.split('T')[0];
            f = result.endDate.split('T')[0];
            leaves += `
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Leave Request ID</strong></label>
                            <span class="col-md-7">: ${result.leaveDetailId}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Employee ID</strong></label>
                            <span class="col-md-7">: ${result.employeeId}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Full Name</strong></label>
                            <span class="col-md-7">: ${result.fullName}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Start Date</strong></label>
                            <span class="col-md-7">: ${d}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>End Date</strong></label>
                            <span class="col-md-7">: ${f}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Leave Type</strong></label>
                            <span class="col-md-7">: ${result.leaveType}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Note</strong></label>
                            <span class="col-md-7">: ${result.note}</span>
                        </div>
                     `
            $('#leaveModal1').html(leaves);
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
            $.ajax({
                url: "/Employees/EmployeeEmail/" + id,
                success: function (data1) {
                    console.log(data1);
                    $.ajax({
                        url: "/Employees/SendEmailToEmployee/",
                        type: "POST",
                        'data': { email: data1.email },
                        'dataType': 'json',
                        success: function (data) {
                            console.log("email sent !");
                        }
                    })
                }
            })

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
                'Leave Request Rejected !',
                'success'
            )

            $.ajax({
                url: "https://localhost:44312/API/Employees/EmployeeEmail/" + id,
                success: function (data1) {
                    console.log(data1);
                    $.ajax({
                        url: "/Employees/SendEmailToEmployee/",
                        type: "POST",
                        'data': { email: data1.email },
                        'dataType': 'json',
                        success: function (data) {
                            console.log("email sent !");
                        }
                    })
                }
            })


            $("#ModalLeave").modal("toggle"),
            $('#ModalLeave').modal('hide'),
            $('#leaveManager').DataTable().ajax.reload();
        }
    })
}

