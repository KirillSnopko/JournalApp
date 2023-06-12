$(document).ready(() => {

    render_subjects();

    function render_subjects() {
        server_getSubjects();

        var view = subjects_list();
        view += '<div id="forms"></div>';
        $('#subjects_view').html(view);
    }

});
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

function subject_level_list(subject) {

}
function subject_topic_table(subject) {

}
function subjects_list() {
    var mapSubjects = client_getSubjects();
    var subjectIsEmpty = mapSubjects.size == 0;

    var view = '<div class="col-sm-4" id="subjects_list">';
    view += '<div class="list-group">';
    view += '<button type="button" class="list-group-item list-group-item-action"> id="subject_add">Добавить предмет</button>'

    if (!subjectIsEmpty) {
        // <button type="button" class="list-group-item list-group-item-action active" aria-current="true">

        mapSubjects.forEach((value, key) => {
            view += '<button type="button" class="subject_ref list-group-item list-group-item-action">  data-value= "' + key + '">' + value.Name + '</button>'
        });
        view += '</div></div>';
    }
    if (!subjectIsEmpty) {
        //view += subject_level_list();
        //view += subject_topic_table();
    }

    return view;
}