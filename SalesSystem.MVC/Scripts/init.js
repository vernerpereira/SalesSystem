$(document).ready(function () {
    main.ApplyMasks();
    main.ApplyProductAutocomplete();

    $("#includeProduct").click(function() {
        main.AddProduct();
    });
    $("#submitSale").click(function() {
        main.SubmitSale();
    });
});