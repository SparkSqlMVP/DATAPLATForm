$(function () {

    var orderby = $("#_orderby").val();
    var ordercolumn = $("#_ordercolumn").val();

    $(".orderby").each(function () {
        var col = $(this).attr("data-column");
        if (col == ordercolumn) {
            if (orderby == "asc") {
                $(this).addClass("table-asc");
                $(this).removeClass("table-desc");
            } else if (orderby == "desc") {
                $(this).removeClass("table-asc");
                $(this).addClass("table-desc");
            }
        }
    });

    $(".orderby").on("click", function () {
        if ($(this).hasClass("table-asc")) {

            $(this).removeClass("table-asc");
            $(this).addClass("table-desc");

            $("#_orderby").val("desc");
            $("#_ordercolumn").val($(this).attr("data-column"));

        } else if ($(this).hasClass("table-desc")) {
            $(this).addClass("table-asc");
            $(this).removeClass("table-desc");

            $("#_orderby").val("asc");
            $("#_ordercolumn").val($(this).attr("data-column"));
        }
        document.forms[0].submit();
        //document.getElementById("btnsearch").click();
    });
})