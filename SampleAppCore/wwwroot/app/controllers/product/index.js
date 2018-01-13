﻿var productController = function () {
    this.initialize = function () {
        loadCategories();
        loadData();
        registerEvents();
        registerControls();
    }

    function registerEvents() {
        // Init validation
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtNameM: { required: true },
                ddlCategoryIdM: { required: true },
                txtPriceM: {
                    required: true,
                    number: true
                }
            }
        });

        // todo: binding events to controls
        $('#ddlShowPage').on('change', function () {
            sampleCore.configs.pageSize = $(this).val();
            sampleCore.configs.pageIndex = 1;
            loadData(true);
        });

        $('#btnSearch').on('click', function () {
            loadData();
        });

        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13)
                loadData();
        });

        $('#btnCreate').on('click', function () {
            resetFormMaintainance();
            initTreeDropDownCategory();
            $('#modal-add-edit').modal('show');
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            loadDetail(that);
        });

        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            deleteProduct(that);
        });

        $('#btnSave').on('click', function (e) {
            saveProduct();
        });

        $('#btnSelectImg').on('click', function () {
            $('#fileInputImage').click();
        });

        $('#fileInputImage').on('change', function () {
            uploadImage();
        });

        $('#btn-import').on('click', function () {
            initTreeDropDownCategory();
            $('#modal-import-excel').modal('show');
        });

        $('#btnImportExcel').on('click', function () {
            importExcel();
        });
    }

    function registerControls() {
        CKEDITOR.replace('txtContent', {});

        //Fix: cannot click on element ck in modal
        $.fn.modal.Constructor.prototype.enforceFocus = function () {
            $(document)
                .off('focusin.bs.modal') // guard against infinite focus loop
                .on('focusin.bs.modal', $.proxy(function (e) {
                    if (
                        this.$element[0] !== e.target && !this.$element.has(e.target).length
                        // CKEditor compatibility fix start.
                        && !$(e.target).closest('.cke_dialog, .cke').length
                        // CKEditor compatibility fix end.
                    ) {
                        this.$element.trigger('focus');
                    }
                }, this));
        };
    }

    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: '/Admin/ProductCategory/GetAll',
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });
                });

                var arr = sampleCore.unflattern(data);
                $('#ddlCategoryIdM').combotree({
                    data: arr
                });

                $('#ddlCategoryIdImportExcel').combotree({
                    data: arr
                });

                if (selectedId != undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');

        $('#txtDescM').val('');
        $('#txtUnitM').val('');

        $('#txtPriceM').val('0');
        $('#txtOriginalPriceM').val('');
        $('#txtPromotionPriceM').val('');

        $('#txtImage').val('');

        $('#txtTagM').val('');
        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');

        CKEDITOR.instances.txtContent.setData('');
        $('#ckStatusM').prop('checked', true);
        $('#ckHotM').prop('checked', false);
        $('#ckShowHomeM').prop('checked', false);

    }

    function loadDetail(id) {
        $.ajax({
            type: 'GET',
            url: '/Admin/Product/GetById',
            data: { id: id },
            dataType: 'json',
            beforeSend: function () {
                sampleCore.startLoading();
            },
            success: function (response) {
                var data = response;
                $('#hidIdM').val(data.Id);
                $('#txtNameM').val(data.Name);
                initTreeDropDownCategory(data.CategoryId);

                $('#txtDescM').val(data.Description);
                $('#txtUnitM').val(data.Unit);

                $('#txtPriceM').val(data.Price);
                $('#txtOriginalPriceM').val(data.OriginalPrice);
                $('#txtPromotionPriceM').val(data.PromotionPrice);

                $('#txtImage').val(data.Image);

                $('#txtTagM').val(data.Tags);
                $('#txtMetakeywordM').val(data.SeoKeywords);
                $('#txtMetaDescriptionM').val(data.SeoDescription);
                $('#txtSeoPageTitleM').val(data.SeoPageTitle);
                $('#txtSeoAliasM').val(data.SeoAlias);

                CKEDITOR.instances.txtContent.setData(data.Content);
                $('#ckStatusM').prop('checked', data.Status == 1);
                $('#ckHotM').prop('checked', data.HotFlag);
                $('#ckShowHomeM').prop('checked', data.HomeFlag);

                $('#modal-add-edit').modal('show');
                sampleCore.stopLoading();
            },
            error: function (status) {
                sampleCore.notify('Có lỗi xảy ra', 'error');
                sampleCore.stopLoading();
            }
        });
    }

    function loadCategories() {
        $.ajax({
            type: 'GET',
            url: '/admin/product/GetAllCategories',
            dataType: 'json',
            success: function (response) {
                var render = "<option value=''>--Select category--</option>";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                $('#ddlCategorySearch').html(render);
            },
            error: function (status) {
                console.log(status);
                sampleCore.notify('Can not loading product category data', 'error');
            }
        });
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                categoryId: $('#ddlCategorySearch').val(),
                keyword: $('#txtKeyword').val(),
                page: sampleCore.configs.pageIndex,
                pageSize: sampleCore.configs.pageSize
            },
            url: '/admin/product/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? '<img src ="/admin-side/images/user.png" width=25/>' : '<img src="' + item.Image + '" width=25/>',
                        CategoryName: item.ProductCategory.Name,
                        Price: sampleCore.formatNumber(item.Price, 0),
                        CreatedDate: sampleCore.dateTimeFormatJson(item.DateCreated),
                        Status: sampleCore.getStatus(item.Status)
                    });
                    $('#lblTotalRecords').text(response.RowCount);
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }

                    wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
            },
            error: function (status) {
                console.log(status);
                sampleCore.notify('Cannot loading data', 'error');
            }
        });
    }

    function deleteProduct(id) {
        sampleCore.confirm('Are you sure to delete?', function () {
            $.ajax({
                type: 'POST',
                url: '/Admin/Product/Delete',
                data: { id: id },
                dataType: 'json',
                beforeSend: function () {
                    sampleCore.startLoading();
                },
                success: function (response) {
                    sampleCore.notify('Delete successful', 'success');
                    sampleCore.stopLoading();
                    loadData();
                },
                error: function (status) {
                    sampleCore.notify('Has an error in delete progress', 'error');
                    sampleCore.stopLoading();
                }
            });
        });
    }

    function saveProduct() {
        if ($('#frmMaintainance').valid()) {
            // e.preventDefault();
            var id = $('#hidIdM').val();
            var name = $('#txtNameM').val();
            var categoryId = $('#ddlCategoryIdM').combotree('getValue');

            var description = $('#txtDescM').val();
            var unit = $('#txtUnitM').val();

            var price = $('#txtPriceM').val();
            var originalPrice = $('#txtOriginalPriceM').val();
            var promotionPrice = $('#txtPromotionPriceM').val();

            var image = $('#txtImage').val();

            var tags = $('#txtTagM').val();
            var seoKeyword = $('#txtMetakeywordM').val();
            var seoMetaDescription = $('#txtMetaDescriptionM').val();
            var seoPageTitle = $('#txtSeoPageTitleM').val();
            var seoAlias = $('#txtSeoAliasM').val();

            var content = CKEDITOR.instances.txtContent.getData();
            var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
            var hot = $('#ckHotM').prop('checked');
            var showHome = $('#ckShowHomeM').prop('checked');

            $.ajax({
                type: 'POST',
                url: '/Admin/Product/SaveEntity',
                data: {
                    Id: id,
                    Name: name,
                    CategoryId: categoryId,
                    Image: image,
                    Price: price,
                    OriginalPrice: originalPrice,
                    PromotionPrice: promotionPrice,
                    Description: description,
                    Content: content,
                    HomeFlag: showHome,
                    HotFlag: hot,
                    Tags: tags,
                    Unit: unit,
                    Status: status,
                    SeoPageTitle: seoPageTitle,
                    SeoAlias: seoAlias,
                    SeoKeywords: seoKeyword,
                    SeoDescription: seoMetaDescription
                },
                dataType: 'json',
                beforeSend: function () {
                    sampleCore.startLoading();
                },
                success: function (response) {
                    sampleCore.notify('Update product successful', 'success');
                    $('#modal-add-edit').modal('hide');
                    resetFormMaintainance();

                    sampleCore.stopLoading();
                    loadData(true);
                },
                error: function () {
                    sampleCore.notify('Has an error in save product progress', 'error');
                    sampleCore.stopLoading();
                }
            });
            return false;
        }
    }

    function uploadImage() {
        var fileUpload = $(this).get(0);
        var files = fileUpload.files;
        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        $.ajax({
            type: 'POST',
            url: '/Admin/Upload/UploadImage',
            contentType: false,
            processData: false,
            data: data,
            success: function (path) {
                $('#txtImage').val(path);
                sampleCore.notify('Upload image successful', 'success');
            },
            error: function () {
                sampleCore.notify('There was error uploading files!', 'error');
            }
        });
    }

    function importExcel() {
        var fileUpload = $("#fileInputExcel").get(0);
        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();
        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append("files", files[i]);
        }
        // Adding one more key to FormData object  
        fileData.append('categoryId', $('#ddlCategoryIdImportExcel').combotree('getValue'));
        $.ajax({
            url: '/Admin/Product/ImportExcel',
            type: 'POST',
            data: fileData,
            processData: false,  // tell jQuery not to process the data
            contentType: false,  // tell jQuery not to set contentType
            success: function (data) {
                $('#modal-import-excel').modal('hide');
                loadData();

            }
        });
        return false;
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalSize = Math.ceil(recordCount / sampleCore.configs.pageSize);
        // Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }

        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalSize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                sampleCore.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}