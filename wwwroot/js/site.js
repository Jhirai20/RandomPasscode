
$(document).ready(function() {
    $("#password").on("submit",
        function(e) {
            e.preventDefault();
            $.getJSON("/password").done(
                function (response) {
                    var result = response;
                    
                    $("h3").text(result);
                });
        });
});