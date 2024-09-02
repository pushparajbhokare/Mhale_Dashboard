class ApiCall {
    constructor(_url, _data, _headers, _method) {
        this.url = _url;
        this.data = _data;
        this.headers = _headers;
        this.method = _method;
    }

    call() {
        let me = this;
        $.ajax({
            url: me.url,
            headers: this.headers,
            type: this.method,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(this.data),
            success: function (result) {
                me.onSuccess(result);
            },
            error: function (errormessage) {
                me.onError(errormessage);
            }
        });
    }

    onSuccess(result) {
    }

    onError(errormessage) {
        //Swal.fire({ icon: 'error', title: 'Oops...', text: 'Some Error Occured', });
        console.log(errormessage.responseText);
    }

    populateGrid(result, divId, datafields, table_columns) {
        var source_raw_data = {
            localData: result,
            datatype: "array",

            datafields: datafields,
            pagesize: 15,
        };
        var data_adapter_raw_data = new $.jqx.dataAdapter(source_raw_data);

        $(divId).jqxGrid({
            width: '100%',
            autoheight: true,
            source: data_adapter_raw_data,
            pageable: true,
            pagermode: 'simple',
            columnsresize: true,
            columnsreorder: true,
            filterable: true,
            sortable: true,
            columns: table_columns,
        });
    }

    populateDropdown(result, divId, displayMember, valueMember) {
        var dataAdapter = new $.jqx.dataAdapter(result);

        $(divId).jqxDropDownList({
            source: dataAdapter,
            displayMember: displayMember,
            valueMember: valueMember,
            selectedIndex: 0,
            width: 200,
            height: 25
            //theme: 'energyblue',
        });
    }

    statusRender(row, column, value, defaulthtml, columnproperties, data) {
        return '<div class="incellbutton">' + (data.status == 1 ? "Active" : "InActive") + '</div>';
    }

    editRender(row, column, value, defaulthtml, columnproperties, data) {
        let editObject = getEdit(data);
        return "<div class='incellbutton'><i class='fa-solid fa-pen' onclick='Edit(" + JSON.stringify(editObject) + ")' clickable/></div>";
    }

    deleteRender(row, column, value, defaulthtml, columnproperties, data) {
        let id = data.id;
        return "<div class='incellbutton'><i class='fa-solid fa-trash-can' onclick='Delete(" + id + ")' clickable/></div>";
    }
}

class ApiGet extends ApiCall {
    constructor(_url, _data, _headers) {
        super(_url, _data, _headers, "GET");
    }
}

class ApiPost extends ApiCall {
    constructor(_url, _data, _message, _headers) {
        super(_url, _data, _headers, "POST");
        this.message = _message;
    }
}

function getQueryStringValue(key) {
    return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}