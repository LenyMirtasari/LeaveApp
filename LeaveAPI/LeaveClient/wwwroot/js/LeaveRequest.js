$(document).ready(function () {
    $.ajax({
        url: "/Employees/Requester/6" ,
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
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "/LeaveDetails/LeaveRequest",
        type: "POST",
        'data': obj, //objek kalian
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

    }).fail((error) => {
        console.log(error)
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Register Failed!',
            footer: 'All columns must be filled !'

        })
    })
    /* }*/
}