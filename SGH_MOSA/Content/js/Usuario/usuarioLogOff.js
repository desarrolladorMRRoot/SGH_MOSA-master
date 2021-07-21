$(document).ready(function () {

    $("#logOutBtn").click(function () {
        // closeWindow();
       // alert("prueba de click sin jqwidgets!");
        //window.location.assign("/Home/Index")
        $.ajax({
            type: "post",
            url: "/User/GetLogOut",
            datatype: 'json',
            contenttype: 'application/json',
            data: JSON.stringify(),
            success: function (response) {
                location.reload(true);
            }
        });

        //location.reload(true);

    });

});
