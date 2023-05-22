function closeFormAndRemove(id) {
    $('#' + id).hide();
    $('.modal-backdrop').hide();
    $('.modal-backdrop').remove();
    $("body").removeClass();
}