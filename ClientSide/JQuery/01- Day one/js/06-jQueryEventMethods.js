$(document).ready(function () {


    $("#clickablePara").click(function () {
        $(this).hide();
    })

    $("#doubleClickPara").dblclick(function () {
        $(this).css("backgroundColor", "red")
    })

    $("#eventButton").click(function () {
        alert("hello was clicked")
    })

    $("#keyInput").keypress(function () {
        console.log($(this).val())
    })
})