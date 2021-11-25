$(document).ready(function () {
    $.ajax({
        url: "/Employees/Requester/8" ,
        success: function (result) {
            console.log(result);
            $("#employeeId").val(result.id);
            $("#employeeId1").val(result.id);
            $("#fullName").val(result.fullName);
            $("#email").val(result.email);
            $("#phoneNumber").val(result.phoneNumber);
            $("#lastYear").val(result.lastYear);
            $("#currentYear").val(result.currentYear);
            $("#totalLeaves").val(result.totalLeaves);
            $("#eligibleLeave").val(result.eligibleLeave);
            $("#managerId").val(result.managerId);
            $("#managerName").val(result.managerName);
        }
    })
});
$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44312/API/LeaveDetails/GetRequestNumber",
        success: function (result) {
            console.log(result);
            $("#rNumber").val(result);
           
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

            $('#LeaveType').html(leaveType);
        }

    })
});



function Insert() {
    var obj = new Object();
    obj.EmployeeId = $("#employeeId1").val();
    obj.StartDate = $("#startDate").val();
    obj.EndDate = $("#endDate").val();
    obj.ManagerId = $("#managerId").val();
    obj.LeaveTypeId = $("#LeaveType").val();
    obj.Note = $("#notes").val();

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

$("#formRequestLeave").validate({
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
    var a = $("#formRequestLeave").valid();
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