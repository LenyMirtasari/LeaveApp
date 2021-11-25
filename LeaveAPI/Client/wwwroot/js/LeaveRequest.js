$(document).ready(function () {
    $.ajax({
        url: "/Employees/Requester/6" ,
        success: function (result) {
            console.log(result);
            $("#employeeId").val(result.id);
            $("#fullName").val(result.fullName);
            $("#email").val(result.email);
            $("#phoneNumber").val(result.phoneNumber);
            $("#lastYear").val(result.lastYear);
            $("#currentYear").val(result.currentYear);
            $("#totalLeaves").val(result.totalLeaves);
            $("#eligibleLeave").val(result.eligibleLeave);      
        }
    })
});