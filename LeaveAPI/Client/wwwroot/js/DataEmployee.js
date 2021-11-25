$(document).ready(function () {
    $("#tabelEmployee").DataTable({
        'ajax': {
            'url': "https://localhost:44307/api/employees",
            'dataSrc': 'result'
        },
        /*buttons: [
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
        ],*/
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
                "data": "gender",
                "render": function (data, type, row, meta) {
                    if (row['gender'] == 0) {
                        return 'Male'
                    } else if (row['gender'] == 1) {
                        return 'Female'
                    }
                }
            }/*,
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    var button = '<td>' +
                        '<button type="button" onclick="getData(' + row['employeeId'] + ');" class="btn btn-warning text-center fa fa-edit" data-toggle="modal" href="#modalEmployee"> </button>' + ' ' +
                        '<button type="button" onclick="deleteData(' + row['employeeId'] + ');" class="btn btn-danger text-center fa fa-trash-alt" > </button>' +
                        '</td > ';
                    return button;
                }
            }*/
        ]
    });
});

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
        url: "https://localhost:44307/api/employees/register/" + NIK,
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
            $('#modalEmployee').modal('show');
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