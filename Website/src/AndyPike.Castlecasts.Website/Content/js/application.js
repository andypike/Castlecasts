$(document).ready(function() {

    $("form").validate({
        submitHandler: function(form) {
            $("input[type='submit']").attr("disabled", "disabled");
            form.submit();
        }
    });

    $("#header").click(function() {
        location.href = '/';
    });

    $(".tweet").tweet({
        avatar_size: 32,
        count: 4,
        query: "%23castlecasts",
        loading_text: "searching twitter..."
    });

});