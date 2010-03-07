$(document).ready(function() {

    $("form").validate({
        submitHandler: function(form) {
            $("input[type='submit']").attr("disabled", "disabled");
            form.submit();
        }
    });
    
});