var main = {
    ApplyMasks: function() {
        $(".currency").maskMoney({ thousands: "", decimal: "." });
        $(".phone").mask("(99) 9999-9999?9");
        $(".cpf").mask("999.999.999-99");
        $(".datepicker").datepicker();
    },
    ApplyProductAutocomplete: function() {
        $(".productAutocomplete").autocomplete({
            source: "/Sale/SearchProduct",
            minLength: 2,
            select: function (event, ui) {
                $("#ProductToIncludeId").val(ui.item.id);
                $("#UnitValueToInclude").val(ui.item.price.toFixed(2));
                console.log(ui);
            }
        });
    },
    AddProduct: function () {
        var id = $("#ProductToIncludeId").val();
        var name = $("#ProductToInclude").val();
        var quantity = $("#QuantityToInclude").val();
        var unitValue = parseFloat($("#UnitValueToInclude").val()).toFixed(2);

        if (id.trim().length === 0 ||
            name.trim().length === 0 ||
            quantity.trim().length === 0 ||
            parseFloat(quantity) <= 0 ||
            unitValue.trim().length === 0 ||
            parseFloat(unitValue) <= 0) {

            $("#insertProductValidataionMessage").html("The product, quantity and unit price need to be informed");
            return;
        } else {
            $("#insertProductValidataionMessage").html("");
        }

        var totalValue = parseFloat(quantity * unitValue).toFixed(2);
        var htmlToApend =
            "<tr id=\"id_" + id + "\"><td><input type=\"hidden\" name=\"products.index\" value=\"" + id +"\" />" +
            name + "</td><td><input type=\"hidden\" name=\"products[" + id +"].quantity\" class=\"productQuantityIncluded\" value=\"" + quantity+"\" />" +
            quantity + "</td><td><input type=\"hidden\" name=\"products["+id+"].unitValue\" class=\"productUnitValueIncluded\" value=\"" + unitValue+"\" />" +
            "R$ " + unitValue + "</td><td><input type=\"hidden\" rel=\"" + id + "\" class=\"productTotalValueIncluded\" value=\"" + totalValue+"\" />" +
            "R$ " + totalValue+"</td><td>" +
            "<input type=\"button\" value=\"x\" class=\"pull-right btn btn-sm btn-danger\" onclick=\"main.RemoveProduct('id_" + id + "');\" />" +
            "</td></tr >";
        $("#productList").append(htmlToApend);
        main.UpdateTotalSale();

        $("#ProductToIncludeId").val("");
        $("#ProductToInclude").val("");
        $("#QuantityToInclude").val("");
        $("#UnitValueToInclude").val("");
    },
    RemoveProduct: function(idToRemove) {
        $("#" + idToRemove).remove();
        main.UpdateTotalSale();
    },
    UpdateTotalSale: function() {
        var total = 0;
        $(".productTotalValueIncluded").each(function () {
            total += parseFloat($(this).val());
        });

        $("#totalSale").html("R$ " + total.toFixed(2));
    },
    SubmitSale: function () {
        var submit = true; 
        if ($("#productList").html().trim().length === 0) {
            $("#productsValidataionMessage").html("Products are required");
            submit = false;
        } else {
            $("#productsValidataionMessage").html("");
        }
        if ($("#CustomerId").val() === "") {
            $("#customerValidataionMessage").html("Customer is required");
            submit = false;
        } else {
            $("#customerValidataionMessage").html("");
        }

        return submit;
    }
}