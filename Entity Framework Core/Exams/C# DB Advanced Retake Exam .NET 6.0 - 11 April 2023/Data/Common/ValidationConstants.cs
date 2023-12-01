namespace Invoices.Data.Common;

public static class ValidationConstants
{
    //Product
    public const int ProductNameMinLength = 9;
    public const int ProductNameMaxLength = 30;
    public const decimal ProductPriceMinRange = 5m;
    public const decimal ProductPriceMaxRange = 1000m;
    public const int ProductCategoryTypeMinRange = 0;
    public const int ProductCategoryTypeMaxRange = 4;

    //Address
    public const int AddressStreetNameMinLength = 10;
    public const int AddressStreetNameMaxLength = 20;
    public const int AddressCityMinLength = 5;
    public const int AddressCityMaxLength = 15;
    public const int AddressCountryMinLength = 5;
    public const int AddressCountryMaxLength = 15;

    //Invoice
    public const int InvoiceCurrencyTypeMinValue = 0;
    public const int InvoiceCurrencyTypeMaxValue = 2;
    public const int InvoiceNumberMinRange = 1000000000;
    public const int InvoiceNumberMaxRange = 1500000000;

    //Client
    public const int ClientNameMinLength = 10;
    public const int ClientNameMaxLength = 25;
    public const int ClientVatNumberMinLength = 10;
    public const int ClientVatNumberMaxLength = 15;
}