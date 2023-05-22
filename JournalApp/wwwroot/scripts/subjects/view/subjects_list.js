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