$(document).ready(function () {



    // select all elements
    $('#btnSelectAll').click(function () {
        $('*').removeClass('highlight')
        $('*').addClass('highlight');
    })



    // select children of paragraph
    $('#btnSelectChildren').click(function () {
        $('*').removeClass('highlight')
        $("p > *").addClass('highlight')
    })

    // select special ID
    $('#btnSelectById').click(function () {
        $('*').removeClass('highlight')
        $('#specialID').addClass('highlight')
    })


    // select special CLASS
    $('#btnSelectByClass').click(function () {
        $('*').removeClass('highlight')
        $('.specialClass').addClass('highlight')
    })

    // select p empty 
    $('#btnSelectEmpty').click(function () {
        $('*').removeClass('highlight')
        $('p:empty').addClass('highlight')
    })

    // Select Nested Links 
    $('#btnSelectNested').click(function () {
        $('*').removeClass('highlight')
        $('p a.specialClass').addClass('highlight')
    })



})