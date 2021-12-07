$(document).ready(function () {
    $('#history').DataTable({
        'ajax': {
            'url': "/LeaveDetails/GetHistory/",
            'dataSrc': ''
        },
        'columns': [
            {
                "data": "no",
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
           /* {
                "data": "leaveId"
            },
            {
                "data": "fullName"
            },*/
            {
                "data": "startDate",
                "render": function (date) {
                 /*   var date;
                    date = date.toString();
                    dateTime = date.substring(0, 10);
                    return dateTime;*/
                    date = date.toString();
                    date = moment(date, "YYYY-MM-DD").format("DD MMMM YYYY");
                    return date;
                }
            },
            {
                "data": "endDate",
                "render": function (date) {
                    date = date.toString();
                    date = moment(date, "YYYY-MM-DD").format("DD MMMM YYYY");
                    return date;
                }
            },
            {
                "data": "note"
            },
            {
                "data": "leaveTypeName"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    if (row['approval'] == '0') {
                        return `<h5><span class="badge badge-warning">Waiting</span></h5>`;
                    } else if (row['approval'] == '1') {
                        return `<h5><span class="badge badge-success">Approve</span></h5>`;
                    } else {
                        return `<h5><span class="badge badge-danger">Rejected</span></h5>`;
                    }
                }
            }
            
        ]
    });
    /*   table.ajax.reload(); */
});



function LeaveRequest() {
    listSW = "";
    $.ajax({
        url: "/Employees/Requester/" ,
        success: function (result) {
            console.log(result);
            $("#ModalLeaveRequest").modal("show");
            $("#managerId2").val(result.managerId);
            $("#employeeId2").val(result.id);
            $("#managerName2").val(result.managerName);
            listSW += `                                                         
	                    <div class="row form-group">                       
                            <label class="col-md-4" for="employeeId"><strong>Employee ID</strong></label>
                            <span class="col-md-7">: ${result.id}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Name</strong></label>
                            <span class="col-md-7">: ${result.fullName}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Email</strong></label>
                            <span   class="col-md-7">: ${result.email}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Phone Number</strong></label>
                            <span class="col-md-7">: ${result.phoneNumber}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Total Leave</strong></label>
                            <span class="col-md-7">: ${result.totalLeaves}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Eligible Leave</strong></label>
                            <span class="col-md-7">: ${result.eligibleLeave}</span>
                        </div>
                        <div class="row form-group">
                            <label class="col-md-4" for="employeeId"><strong>Manager Name</strong></label>
                            <span class="col-md-7">: ${result.managerName}</span>
                        </div>
                        ` ;

            $('#modal1').html(listSW);
            list = "";
            $.ajax({
                url: "https://localhost:44312/API/LeaveDetails/GetRequestNumber",
                success: function (result) {
                    console.log(result);
                    list += `<div class="row form-group">
                                    <label class="col-md-4" for="employeeId"><strong>Requester Number</strong></label>
                                    <span class="col-md-7">: ${result}</span>
                            </div>`;
                    $('#modal2').html(list);
                }
            })
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

$(document).ready(function () {
    $.ajax({
        url: "/Employees/Requester/",
        success: function (result) {
            console.log(result)
            var eligible = `<div class="h5 mb-0 font-weight-bold text-gray-800">${result.eligibleLeave}</div>`;
            var total = `<div class="h5 mb-0 font-weight-bold text-gray-800">${result.totalLeaves}</div>`;
            $('#eligiblee').html(eligible);
            $('#totalle').html(total);
        }

    })
});

function Insert() {

    var formData = new FormData();
    formData.append('file', $('#fileUpload')[0].files[0]);
    formData.append('EmployeeId', $("#employeeId2").val());
    formData.append('StartDate', $("#startDate2").val());
    formData.append('EndDate', $("#endDate2").val());
    formData.append('ManagerId', $("#managerId2").val());
    formData.append('LeaveTypeId', $("#LeaveType2").val());
    formData.append('Note', $("#notes2").val());
  
    var obj = new Object();
    obj.EmployeeId = $("#employeeId2").val();
    obj.StartDate = $("#startDate2").val();
    obj.EndDate = $("#endDate2").val();
    obj.ManagerId = $("#managerId2").val();
    obj.LeaveTypeId = $("#LeaveType2").val();
    leave1 = $("#LeaveType2").val();
    obj.Note = $("#notes2").val();
    //obj.File = fileData.append.name[0], files[0];
    obj.File = $("#fileUpload").val();
    manager = $("#managerName2").val()
    //obj.File = new FormData(File)
    leaveType1 = "";
    if (leave1 == 1) {
        leaveType1 = "Cuti Tahunan";
    } else if (leave1 ==2) {
        leaveType1 = "Pekerja menikah";
    } else if (leave1 == 3) {
        leaveType = "Mengkhitankan anaknya";
    } else if (leave1 == 4) {
        leaveType1 = "Membaptiskan anaknya";
    } else if (leave1 == 5) {
        leaveType1 = "Anggota keluarga dalam satu rumah meninggal dunia";
    }
    console.log(leave1)
    console.log(leaveType1)
    console.log(manager)

    console.log(obj);
    $.ajax({
        url: "/LeaveDetails/LeaveRequest",
        type: "POST",
        data: formData,
        processData: false,
        contentType: false

    
    }).done((result) => {
        console.log(result);
        if (result == 200) {
            Swal.fire(
                'Good job!',
                'Data Inserted!',
                'success'
            )
            
            $.ajax({
                url: "/Employees/ManagerEmail" ,
                success: function (data1) {
                    console.log(data1.email);
                    $.ajax({
                        url: "/Employees/SendEmailToManager/",
                        type: "POST",
                        'data': { email: data1.email, sd: obj.StartDate, ed: obj.EndDate, note: obj.Note, lt: leaveType1, mng: manager },
                        'dataType': 'json',
                        success: function (data) {
                            console.log("email sent !");
                        }
                    })
                }
            })

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
            required: true,
            greaterThan: "#startDate2"
        },
        notes: {
            /*   minlength: 50,*/
            maxlength: 225,
            required: true
        },
        File: {
            required : true
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

$.validator.addMethod("greaterThan",
    function (value, element, params) {

        if (!/Invalid|NaN/.test(new Date(value))) {
            return new Date(value) > new Date($(params).val());
        }

        return isNaN(value) && isNaN($(params).val())
            || (Number(value) > Number($(params).val()));
    }, 'Must be greater than start date');

