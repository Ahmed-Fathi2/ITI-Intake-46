$(document).ready(function () {


    // select all inputs
    $("#btnSelectInputs").click(function () {
        $('*').removeClass('highlight');
        $(':input').addClass('highlight')
    })

    // Select text inputs
    $("#btnSelectText").click(function () {
        $('*').removeClass('highlight');
        $(':text').addClass('highlight')
    })

})