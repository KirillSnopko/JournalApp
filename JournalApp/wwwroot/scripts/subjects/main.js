$(document).ready(() => {

    render_subjects();

    function render_subjects() {
        server_getSubjects();

        var view = subjects_list();
        view += '<div id="forms"></div>';
        $('#subjects_view').html(view);
    }

});