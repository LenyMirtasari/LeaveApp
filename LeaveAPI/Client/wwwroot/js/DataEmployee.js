$(document).ready(function () {
    $("#tabelEmployee").DataTable({
        'ajax': {
            'url': "https://localhost:44307/api/employees",
            'dataSrc': 'result'
        },
        buttons: [
            {
                extend: 'copyHtml5',
                name: 'copy',
                title: 'Employee',
                sheetName: 'Employee',
                text: '',
                className: 'buttonHide fa fa-copy btn-default',
                filename: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7]
                }
            },
            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Employee',
                sheetName: 'Employee',
                text: '',
                className: 'buttonHide fa fa-download btn-default',
                filename: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7]
                }
            },
            {
                extend: 'pdfHtml5',
                name: 'pdf',
                title: 'Employee',
                sheetName: 'Employee',
                text: '',
                className: 'buttonHide fa fa-download btn-default',
                filename: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7]
                }
            },
            {
                extend: 'csvHtml5',
                name: 'csv',
                title: 'Employee',
                sheetName: 'Employee',
                text: '',
                className: 'buttonHide fa fa-download btn-default',
                filename: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7]
                }
            }
        ],
        'columns': [
            {
                "data": "employeeId"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['firstName'] + " " + row['lastName'];
                }
            },
            {
                "data": "email"
            },
            {
                "data": "phoneNumber",
                "orderable": false,
                "render": function (toFormat) {
                    var tPhone;
                    tPhone = toFormat.toString();
                    subsTphone = tPhone.substring(0, 1);
                    if (subsTphone == "0") {
                        tPhone = '+62 ' + tPhone.substring(1, 4) + ' ' + tPhone.substring(4, 8) + ' ' + tPhone.substring(8, 13);
                        return tPhone
                    } else if (subsTphone == null) {
                        return tPhone
                    }
                    else {
                        tPhone = tPhone.substring(0, 4) + ' ' + tPhone.substring(4, 8) + ' ' + tPhone.substring(8, 13);
                        return tPhone
                    }
                }
            },
            {
                "data": "hireDate",
                "render": function (date) {
                    var date;
                    date = date.toString();
                    dateTime = date.substring(0, 10);
                    return dateTime;
                }
            },
            {
                "data": "jobId"
            },
            {
                "data": "gender",
                "render": function (data, type, row, meta) {
                    if ('Male') {
                        return 'Male'
                    } else if ('Female') {
                        return 'Female'
                    }
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    var button = '<td>' +
                        '<button type="button" onclick="getData(' + row['employeeId'] + ');" class="btn btn-warning text-center fa fa-edit" data-toggle="modal" href="#modalEmployee"> </button>' + ' ' +
                        '<button type="button" onclick="deleteData(' + row['employeeId'] + ');" class="btn btn-danger text-center fa fa-trash-alt" > </button>' +
                        '</td > ';
                    return button;
                }
            }
        ]
    });
});

function ModalRegister(){

}

function InsertData() {
    var obj = new Object();
    obj.FirstName = $('#firstName').val();
    obj.LastName = $('#lastName').val();
    obj.PhoneNumber = $('#phoneNumber').val();
    obj.Gender = $('#gender').val();
    obj.hireDate = $('#hireDate').val();
    obj.Email = $('#email').val();
    obj.Password = $('#password').val();
    obj.JobId = $('#jobId').val();
    obj.RoleId = $('#roleId').val();
    console.log(obj);
    $.ajax({
        url: "https://localhost:44307/api/employees/register",
        'type': 'POST',
        'data': { entity: obj }, //objek kalian
        'dataType': 'json',
    }).done((result) => {
        if (result == 200) {
            swal({
                title: "Good job!",
                text: "Data Berhasil Ditambahkan!!",
                icon: "success",
                button: "Okey!",
            }).then(function () {
                window.location = "https://localhost:44307/home/DataEmployee";
            });
        } else if (result == 400) {
            swal({
                title: "Failed!",
                text: "Data Gagal Dimasukan, NIK,Phone,Email Sudah Terdaftar!!",
                icon: "error",
                button: "Close",
            });
        }
    }).fail((error) => {

        swal({
            title: "Failed!",
            text: "Data Gagal Dimasukan!!",
            icon: "error",
            button: "Close",
        });
    })
}

$(document).ready(function () {
    $("#formValidation").validate({
        rules: {
            firstName: "required",
            lastName: "required",
            email: {
                required: true,
                email: true
            },
            phoneNumber: "required",
            hireDate: "required",
            gender: "required",
            password: {
                required: true,
                minlength: 8,
            },
            jobId: "required",
            managerId: "required",
        },
        messages: {
            firstName: "Please enter your First Name",
            lasstName: "Please enter your Last Name",
            email: "Please enter your Email",
            phoneNumber: "Please enter your Phone Number",
            hireDate: "Please enter your Hire Date",
            gender: "Please enter your Gender",
            password: "Please enter your Password",
            jobId: "Please enter your Job Id",
            managerId: "Please enter your Manager Id",
        },
        submitHandler: function () {
            var obj = new Object();
            obj.FirstName = $("#firstName").val();
            obj.LastName = $("#lastName").val();
            obj.Email = $("#email").val();
            obj.PhoneNumber = $("#phoneNumber").val();
            obj.HireDate = $("#hireDate").val();
            obj.Gender = $("#gender").val();
            obj.Password = $("#password").val();
            obj.JobId = $("#jobId").val();
            obj.ManagerId = $("#managerId").val();
            console.log(obj);
            //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
            $.ajax({
                url: "https://localhost:44307/api/employees/register",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                'type': 'POST',
                'data': JSON.stringify(obj),
                'dataType': 'json',
            }).done((result) => {
                swal({
                    title: "Good job!",
                    text: "Data Berhasil Ditambahkan!!",
                    icon: "success",
                    button: "Okey!",
                }).then(function () {
                    window.location.reload();
                });
                $('#modalEmployee').modal('hide');
            }).fail((error) => {
                swal({
                    title: "Failed!",
                    text: "Data Gagal Dimasukan!!",
                    icon: "error",
                    button: "Close",
                });
            })
        }
    });
});

function getData(NIK) {
    /console.log(nik)/
    $.ajax({
        url: "https://localhost:44307/api/employees/register/" + employeeId,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result.result)
            var tanggal = result.result.birthDate.substr(0, 10);
            $('#firstName').val(result.firstName);
            $('#lastName').val(result.lastName);
            $('#email').val(result.email);
            $('#phoneNumber').val(result.phoneNumber);
            $('#hireDate').val(tanggal);
            if (result.gender === 0) {
                $('#gender').val(0);
            } else {
                $('#gender').val(1);
            };
            $('#password').val(result.password);
            /*$('#modalEmployee').modal('show');*/
            $(window).on('load', function () {
                $('#modalEmployee').modal('show');
            });
            $('#btnUpdate').show();
            $('#btnDaftar').hide();
            $('#hidePass').hide();
            $('#hideRow').hide();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
            swal({
                title: "FAILED",
                text: "DATA TIDAK DITEMUKAN!",
                icon: "error"
            }); then(function () {
                window.location = "https://localhost:44375/Home/DataEmployee";
        }); 
    }
    });
return false
};

function updateData() {
    var nik = $('#employeeId');
    var obj = new Object();
    obj.NIK = $("#nik").val();
    obj.FirstName = $("#firstName").val();
    obj.LastName = $("#lastName").val();
    obj.Email = $("#email").val();
    obj.PhoneNumber = $("#phoneNumber").val();
    obj.HireDate = $("#hireDate").val();
    obj.Gender = $("#gender").val();
    obj.Password = $("#password").val();
    obj.JobId = $("#jobId").val();
    obj.ManagerId = $("#managerId").val();
    $.ajax({
        url: "https://localhost:44307/api/employees/" + employeeId,
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result.result);
            var tanggal = result.result.hireDate.substring(0, 10);
            $('#firstName').val(result.result.firstName);
            $('#lastName').val(result.result.lastName);
            $('#email').val(result.result.email);
            $('#phoneNumber').val(result.result.phoneNumber);
            $('#hireDate').val(result.result.hireDate);
            if (result.result.gender === "Male") {
                $('#gender').val("Male");
            } else {
                $('#gender').val("Female");
            };
            $('#jobId').val(result.result.jobId);
            $('#managerId').val(result.result.managerId);
            swal({
                title: "Good job!",
                text: "Data Berhasil Ditambahkan!!",
                icon: "success",
                button: "Okey!",
            }).then(function () {
                window.location.reload();
            });
            $('#modalPokemon').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
};

function deleteData(NIK) {
    var del = confirm("Kamu Yakin Untuk Menghapus Data Ini?");
    if (del) {
        $.ajax({
            url: "https://localhost:44307/api/employees/" + employeeId,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "DELETE",
            dataType: "json",
            data: { "": nik },
            success: function (result) {
                swal({
                    title: "Good job!",
                    text: "Data Berhasil Dihapus!!",
                    icon: "success",
                    button: "Okey!",
                }).then(function () {
                    window.location.reload();
                });
            },
            error: function (errormessage) {
                swal({
                    title: "Failed!",
                    text: "Data Gagal Dihapus!!",
                    icon: "error",
                    button: "Close",
                });
            }
        });
    }
};