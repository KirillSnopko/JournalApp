var mapSubjects = new Map();

function client_subjectById(id) {
    return mapSubjects.get(id);
}

function client_getSubjects() {
    return mapSubjects;
}

function server_getSubjects() {

    $.get("http://" + getPathName() + "/api/Subject/",
        {},

        function (data) {
            if (data != null) {
                $(data).each(function (index, item) {

                    var id = item.Id;
                    var name = item.Name;
                    mapSubjects.set(id, name);
                });
            }

        }).fail(function (jqXHR) {
            onFail(jqXHR);
        });
}
