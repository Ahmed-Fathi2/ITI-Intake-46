$(document).ready(function () {

    $('#btnAttrEquals').click(function () {
        $('*').removeClass('highlight');
        $('[data-type="fruit"]').addClass('highlight')
    })

    $('#btnAttrNotEquals').click(function () {
        $('*').removeClass('highlight');
        $('[data-type!="fruit"]').addClass('highlight')
        $('[data-type="fruit"]').addClass('highlight2')
    })


    // ~ -> contain word
    $('#btnAttrContainsWord').click(function () {
        $('*').removeClass('highlight');
        $('[data-type~=berry]').addClass('highlight')
    })


    // ^ -> START WITH
    $('#btnAttrStartsWith').click(function () {
        $('*').removeClass('highlight');
        $('[data-category^="food"]').addClass('highlight')
    })



    // $ -> END WITH
    $('#btnAttrEndsWith').click(function () {
        $('*').removeClass('highlight');
        $('[data-category$="item"]').addClass('highlight')
    })

    // * contain (any matched chars)
    $('#btnAttrContains').click(function () {
        $('*').removeClass('highlight');
        $('[data-info*="note"]').addClass('highlight')
    })
})