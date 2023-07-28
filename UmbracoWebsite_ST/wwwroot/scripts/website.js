$(document).ready(function () {
    $("#click-more-news-link").on("click", function () {
        var thisPage = $('#PageNumber')[0].value;
        var thisPageNumber = parseInt(thisPage);
        var pageData = { pageNumber: thisPageNumber + 1 }
        $.ajax(
            {
                url: "/umbraco/surface/news/getnews",
                data: pageData,
                type: "GET",
                success: function (html) {
                    $('#newslist').replaceWith(html);
                },
                error: function () {
                    console.log("Error getting next page");
                }
            });
        return false;
    });
});