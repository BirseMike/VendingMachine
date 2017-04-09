var productViewModel = function (options) {
        self = this;
        self.Products = ko.observableArray();
        self.EnteredProductCode = ko.observable();
        self.SelectedProduct = ko.observable();
        self.PriceToPay = ko.computed(function () {
            if (self.SelectedProduct()) {
                return self.SelectedProduct().Price;
            }
            return 0;
        });
        self.CreditCardNo = ko.observable();
        self.DisplayEnteredProductCode = ko.computed(function () {
            if (!self.EnteredProductCode()) {
                return "0";
            }

            return self.EnteredProductCode();
        });
        
        self.IsProductSelected = function (selectedProduct, id) {
            return selectedProduct && selectedProduct.Id == id;
        }

        self.HasError = ko.observable(false);
        self.ErrorMessage = ko.observable();
        self.HasPurchased = ko.observable(false);
        self.PurchaseMessage = ko.observable();

        self.BalancePaid = ko.observable(0);
        self.PaidDisplay = ko.computed(function () {
            return self.BalancePaid().toFixed(2);
        })

        self.KeyPadPress = function (item, event) {
            var keyValue = $(event.currentTarget).attr('data-id');
            var value = self.EnteredProductCode() ? self.EnteredProductCode() : "";
            self.HasError(false);
            switch (keyValue) {
                case "Cancel":
                    if (value)
                        if (value.length > 2) {
                            self.EnteredProductCode(value.substring(0, self.EnteredProductCode().length - 1));
                        }
                        else {
                            self.EnteredProductCode(null);
                        }
                    break;
                case "Ok": {
                    self.GetProduct(value);
                }
                    break;
                case "Clear": {
                    self.EnteredProductCode(null);
                    self.SelectedProduct(null);
                }
                    break; default:
                        self.EnteredProductCode(value + keyValue);
            }
        }

        self.CashInserted = function (item, event) {
            var denom = {
                Value: $(event.currentTarget).attr('data-value') 
            }
            $.ajax({
                type: "POST",
                data: JSON.stringify(denom),
                url: options.tenderCashUrl,
                contentType: "application/json"
            }).done(function (result) {
                self.BalancePaid(result);
            }).fail(function (error) {
                self.HasError(true);
                self.ErrorMessage(error.responseText);
            });

        }

        self.GetProduct = function (id) {
            $.getJSON(options.getProductUrl, { id: id })
                .done(function (data) {
                    self.EnteredProductCode(null);
                    self.SelectedProduct(data);
                }).fail(function (error) {
                    self.HasError(true);
                    self.ErrorMessage(error.responseText);
                });
        }

        self.GetProducts = function () {
            $.getJSON(options.getProductsUrl)
                .done(function (data) {
                    self.Products(data);
                }).fail(function (error) {
                    self.HasError(true);
                    self.ErrorMessage(error.responseText);
                });
        }

        self.Cancel = function () {
            $.ajax({
                type: "POST",
                url: options.refundCashUrl,
            }).done(function (result) {
                self.BalancePaid(0);
                self.CreditCardNo(null);
                self.SelectedProduct(null);
            }).fail(function (error) {
                self.HasError(true);
                self.ErrorMessage(error.responseText);
            });
        };

        self.Pay = function () {
            self.HasPurchased(false);
            self.HasError(false);
            if (!self.SelectedProduct()) {
                return;
            }
            var payment = {
                CreditCardNo: self.CreditCardNo(),
                Cash: self.BalancePaid(),
                ProductId: self.SelectedProduct().Id
            };
            $.ajax({
                type: "POST",
                data: JSON.stringify(payment),
                url: options.payProductUrl,
                contentType: "application/json"
            }).done(function (result) {
                self.HasPurchased(true);
                self.PurchaseMessage(result);
                self.BalancePaid(0);
                self.CreditCardNo(null);
            }).fail(function (error) {
                self.HasError(true);
                self.ErrorMessage(error.responseText);
            });
        };

        self.GetProducts();

    }
