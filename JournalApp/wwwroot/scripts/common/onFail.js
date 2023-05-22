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