$(document).ready(function () {

    /* DataTables start here. */

    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[6, "desc"]],
        buttons: [
            {
                text: 'Add',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Refresh',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Category/GetAllCategories/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#categoriesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const categoryListDto = jQuery.parseJSON(data);
                            console.log(categoryListDto);
                            if (categoryListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(categoryListDto.Categories.$values,
                                    function (index, category) {
                                        tableBody += `
                                                <tr name=${category.Id}>
                                    <td>${category.Id}</td>
                                    <td>${category.Name}</td>
                                    <td>${category.Description}</td>
                                    <td>${category.IsActive ? "Yes" : "No"}</td>
                                    <td>${category.IsDeleted ? "Yes" : "No"}</td>
                                    <td>${category.Note}</td>
                                    <td>${convertToShortDate(category.CreatedDate)}</td>
                                    <td>${category.CreatedByName}</td>
                                    <td>${convertToShortDate(category.ModifiedDate)}</td>
                                    <td>${category.ModifiedByName}</td>
                                    <td>
                                <button class="btn btn-primary btn-sm btn-update" data-id="${category.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span></button>
                                    </td>
                                            </tr>`;
                                    });
                                $('#categoriesTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#categoriesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${categoryListDto.Message}`, 'Process Failed!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#categoriesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
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
        }
    });

    /* DataTables end here */

    /* Ajax GET / Getting the _CategoryAddPartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/Category/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _CategoryAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as CategoryAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-category-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const categoryAddAjaxModel = jQuery.parseJSON(data);
                    console.log(categoryAddAjaxModel);
                    const newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                <tr name="${categoryAddAjaxModel.CategoryDto.Category.Id}">
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.IsActive ? "Yes" : "No"}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.IsDeleted ? "Yes" : "No"}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Note}</td>
                                                    <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.CreatedByName}</td>
                                                    <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.ModifiedByName}</td>
                                                    <td>
                                                        <button class="btn btn-primary btn-sm btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit"></span></button>
                                                        <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button>
                                                    </td>
                                                </tr>`;
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#categoriesTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, 'Process Successful!');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */

    /* Ajax POST / Deleting a Category starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const categoryName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Are you sure you want to delete?',
                text: `${categoryName} will be deleted!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes.',
                cancelButtonText: 'Cancel.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { categoryId: id },
                        url: '/Admin/Category/Delete/',
                        success: function (data) {
                            const categoryDto = jQuery.parseJSON(data);
                            if (categoryDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    `${categoryDto.Category.Name} has been deleted successfully.`,
                                    'success'
                                );

                                tableRow.fadeOut(3500);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Proccess Failed!',
                                    text: `${categoryDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Error!")
                        }
                    });
                }
            });
        });

/* Ajax GET / Getting the _CategoryUpdatePartial as Modal Form starts from here. */

    $(function() {
        const url = '/Admin/Category/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function(event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { categoryId: id }).done(function(data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function() {
                    toastr.error("An Error Occurred.");
                });
            });

    /* Ajax POST / Updating a Category starts from here */

    placeHolderDiv.on('click',
        '#btnUpdate',
        function(event) {
            event.preventDefault();

            const form = $('#form-category-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function(data) {
                const categoryUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(categoryUpdateAjaxModel);
                const newFormBody = $('.modal-body', categoryUpdateAjaxModel.CategoryUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                                <tr name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}">
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Id}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Name}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category
                        .Description}</td>
                                                    <td>${categoryUpdateAjaxModel
                        .CategoryDto.Category.IsActive ? "Yes" : "No"}</td>
                                                    <td>${categoryUpdateAjaxModel
                        .CategoryDto.Category.IsDeleted ? "Yes" : "No"}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Note}</td>
                                                    <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto
                            .Category.CreatedDate)}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category
                        .CreatedByName}</td>
                                                    <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto
                            .Category.ModifiedDate)}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category
                        .ModifiedByName}</td>
                                                    <td>
                                                        <button class="btn btn-primary btn-sm btn-update" data-id="${
                        categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit"></span></button>
                                                        <button class="btn btn-danger btn-sm btn-delete" data-id="${
                        categoryUpdateAjaxModel.CategoryDto.Category.Id
                        }"><span class="fas fa-minus-circle"></span></button>
                                                    </td>
                                                </tr>`;
                    const newTableRowObject = $(newTableRow);
                    const categoryTableRow = $(`[name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"]`);
                    newTableRowObject.hide();
                    categoryTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${categoryUpdateAjaxModel.CategoryDto.Message}`, "Process Successful!");
                } else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function(response) {
                console.log(response);
            });
        });

    });
});