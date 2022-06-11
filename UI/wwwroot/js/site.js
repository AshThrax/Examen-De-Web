// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function ()
{
    var api ="https://www.googleapis.com/youtube/v3/search?key="
    var apikey = "AIzaSyBQn4jTntWHt5QeZJ4xBORFQkKg9jJorBA"
    var Video = ""
    var Videos=$("#videos")
    $("form").submit(function (event)
    {
        event.preventDefault()
        var search=$("#search").val()
        videoSearch(apikey,search,10)
    }
        )

    function videosearch(key, search, maxresult) {
        $.get("https://www.googleapis.com/youtube/v3/search?key="key+ &type=video&part=snippet&maxResult=" + maxresult + "&q" + search, function (data)
        {
            console.log(data)
            data.items.forEach( item => {
                Video ='<iframe width="300" height="315" src="htto://www.youtube.com/embed/ ${item.id.videoId}" frameborder="0" allowfullscreen></iframe>'

                   
                $("#videos").append(Video)
            });
        })
    }
}
    )

   