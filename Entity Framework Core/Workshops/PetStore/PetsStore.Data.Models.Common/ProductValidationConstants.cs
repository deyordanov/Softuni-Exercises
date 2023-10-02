namespace PetsStore.Data.Models.Common;

public class ProductValidationConstants
{
    public const string NameIsRequired = "Name is required!";
    public const string NameMinLengthMessage = "The name can contain a minimum of 3 characters!";
    public const string NameMaxLengthMessage = "The name can contain a maximum of 70 characters!";
    public const string PriceRangeMessage = "Price should be between 0 and 79228162514264337593543950335!";

    public const string PriceMinValue = "0";
    public const string PriceMaxValue = "79228162514264337593543950335";

    public const int NameMaxLength = 70;
    public const int NameMinLength = 3;
}