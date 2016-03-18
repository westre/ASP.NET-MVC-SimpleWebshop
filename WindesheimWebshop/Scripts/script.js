$(document).ready(function () {
    
    $("#product-add").click(function () {
        var productId = $("#product-add").data("pid");
        var amount = $("#product-amount").val();

        $.ajax({
            url: "/Winkelmand/Edit",
            type: "post",
            data: { pid: productId, pamount: amount },
            dataType: "json",
            success: function (data) {
                console.log(data)
                alert("Product toegevoegd!");
            }
        });
    });

    $(".product-remove").click(function () {
        var productId = $(this).data("pid");

        $.ajax({
            url: "/Winkelmand/Edit",
            type: "post",
            data: { pid: productId, pamount: 0 },
            dataType: "json",
            success: function (data) {
                console.log(data)
            }
        });

        $('tr[data-pid="' + productId + '"').remove();
    });

});