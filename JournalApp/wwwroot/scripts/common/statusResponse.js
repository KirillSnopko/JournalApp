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