$(document).ready(function () {
    $('#articlesTable').DataTable({
        "order": [[4, "desc"]],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "No Available data in Table",
            "sInfo": "_TOTAL_ records _START_ - _END_ shows between records",
            "sInfoEmpty": "No Record",
            "sInfoFiltered": "(_MAX_ records found)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "page _MENU_ show record",
            "sLoadingRecords": "Loading...",
            "sProcessing": "Processing...",
            "sSearch": "Search:",
            "sZeroRecords": "Did not find matching records",
            "oPaginate": {
                "sFirst": "First",
                "sLast": "Last",
                "sNext": "Next",
                "sPrevious": "Previous"
            },
            "oAria": {
                "sSortAscending": ": sort by ascending",
                "sSortDescending": ": sort by descending"
            },
            "select": {
                "rows": {
                    "_": "%d record deleted",
                    "0": "",
                    "1": "1 record selected"
                }
            }
        },
        
    });
});