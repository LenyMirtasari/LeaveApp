$(document).ready(function () {
    $('#history').DataTable({
        'ajax': {
            'url': "/LeaveDetails/GetHistory/"+6,
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
                "data": "startDate"
            },
            {
                "data": "endDate"
            },
            {
                "data": "note"
            },
            {
                "data": "submitDate"
            },
            {
                "data": "approval"
            },
            {
                "data": "leaveTypeName"
            }
        ]
    });
    /*   table.ajax.reload(); */
});