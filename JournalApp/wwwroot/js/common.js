function closeFormAndRemove(id) {
    $('#' + id).hide();
    $('.modal-backdrop').hide();
    $('.modal-backdrop').remove();
    $("body").removeClass();
}
function getPathName() {
    return window.location.host;
   /* var pathname = window.location.pathname.split('/')[1];
    var url;
    if (pathname == '') {
        url = '';
    } else {
        url = '/' + pathname;
    }

    return url;*/
}
function onFail(jqXHR) {

    var code = jqXHR.status;
    var text = new String(jqXHR.responseText);

    console.log(code);
    text = text.split('<title>')[1].split('</title>')[0].split('-')[2];
    console.log(text);

    onFailCatched(code, text);
}

function onFailCatched(code, text) {


    switch (code) {
        case 400:
            statusResponse("warning", code, text, 4000);
            break;
        case 403:
            window.history.go(-window.history.length);
            window.location.reload(true);
            break;
        case 404:
            statusResponse("warning", code, text, 4000);
            break;
        case 406:
            statusResponse("warning", code, text, 4000);
            window.location.reload(true);
            break;
        default:
            statusResponse("danger", code, text, 4000);
    }
}
function statusResponse(level, message1, message2, duration) {
    var temp = '<div class="alert alert-' + level + ' alert-dismissible">' +
        '<img src = "' + getPathName();

    switch (level) {
        case 'success':
            temp += '/root/images/success.png';
            break;
        case 'warning':
            temp += '/root/images/warning.png';
            break;
        case 'danger':
            temp += '/root/images/danger.png';
            break;
        case 'info':
        default:
            temp += '/root/images/info.png';
            break;
    };

    temp += '" height = "25" width = "25" alt = "status" ><strong> ' + message1 + '</strong> ' + message2 + '</div> ';

    $("div.status_alert").html(temp);

    $(".alert").alert();
    window.setTimeout(function () {
        $(".alert").fadeTo(1000, 0).slideUp(1000, function () {
            $(this).remove();
        });
    }, duration);
}