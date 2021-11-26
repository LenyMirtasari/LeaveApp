$(document).ready(function () {
    $('#history').DataTable({
        'ajax': {
            'url': "/LeaveDetails/GetHistory/"+3,
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
                "data": "leaveId"
            },
            {
                "data": "fullName"
            },
            {
                "data": "startDate",
                "render": function (date) {
                    var date;
                    date = date.toString();
                    dateTime = date.substring(0, 10);
                    return dateTime;
                }
            },
            {
                "data": "endDate",
                "render": function (date) {
                    var date;
                    date = date.toString();
                    dateTime = date.substring(0, 10);
                    return dateTime;
                }
            },
            {
                "data": "note"
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
                    if (row['approval'] == '0') {
                        return "Waiting";
                    } else if (row['approval'] == '1') {
                        return "Approve";
                    } else {
                        return "Rejected";
                    }
                }
            },
            {
                "data": "leaveTypeName"
            }
        ]
    });
    /*   table.ajax.reload(); */
});

function LeaveRequest() {
    /*console.log(nik);*/

    $.ajax({
        url: "/Employees/Requester/3" ,
        success: function (result) {
            console.log(result);
            $("#ModalLeaveRequest").modal("show");
            $("#employeeId2").val(result.id);
            $("#fullName2").val(result.fullName);
            $("#email2").val(result.email);
            $("#phoneNumber2").val(result.phoneNumber);
            $("#lastYear2").val(result.lastYear);
            $("#currentYear2").val(result.currentYear);
            $("#totalLeaves2").val(result.totalLeaves);
            $("#eligibleLeave2").val(result.eligibleLeave);
            $("#managerId2").val(result.managerId);
            $("#managerName2").val(result.managerName);

        }
    })
}

$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44312/API/LeaveDetails/GetRequestNumber",
        success: function (result) {
            console.log(result);
            $("#rNumber2").val(result);

        }
    })
});

$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44312/API/LeaveTypes",
        success: function (result) {
            console.log(result)
            var leaveType = "";
            $.each(result, function (key, val) {
                leaveType += ` <option value="${val.leaveTypeId}">${val.leaveTypeName}</option>`;
            })

            $('#LeaveType2').html(leaveType);
        }

    })
});

function Insert() {
    var obj = new Object();
    obj.EmployeeId = $("#employeeId2").val();
    obj.StartDate = $("#startDate2").val();
    obj.EndDate = $("#endDate2").val();
    obj.ManagerId = $("#managerId2").val();
    obj.LeaveTypeId = $("#LeaveType2").val();
    obj.Note = $("#notes2").val();

    console.log(obj);
    $.ajax({
        url: "/LeaveDetails/LeaveRequest",
        type: "POST",
        'data': obj,
        'dataType': 'json',
    }).done((result) => {
        console.log(result);
        if (result == 200) {
            Swal.fire(
                'Good job!',
                'Data Inserted!',
                'success'
            )
                $("#ModalLeaveRequest").modal("toggle"),
                $('#ModalLeaveRequest').modal('hide'),
                $('#history').DataTable().ajax.reload();
        }
        if (result == 404) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Date has passed !'
            })
        }
        if (result == 400) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Eligible Leave Not Available !'
            })
        }

    }).fail((error) => {
        console.log(error)
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Leave Request Failed !'
        })
    })
}

$("#formRequestLeave2").validate({
    rules: {
        LeaveType: {
            required: true
        },
        startDate: {
            required: true
        },
        endDate: {
            required: true
        },
        notes: {
            /*   minlength: 50,*/
            maxlength: 225,
            required: true
        }
    },
    errorPlacement: function (error, element) {
        error.insertAfter(element);
    },
    highlight: function (element) {
        $(element).closest('.form-control').addClass('is-invalid');
    },
    unhighlight: function (element) {
        $(element).closest('.form-control').removeClass('is-invalid');
    }
});

function Validation() {
    var a = $("#formRequestLeave2").valid();
    console.log(a);
    if (a == true) {
        Insert();
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Leave Request Failed!',
            footer: 'All columns must be filled !'

        })
    }
}