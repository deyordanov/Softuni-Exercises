namespace Medicines.Common;

public static class ValidationConstants
{
    //Pharmacy
    public const int PharmacyNameMinLength = 2;
    public const int PharmacyNameMaxLength = 50;
    public const int PharmacyPhoneNumberMaxLength = 14;
    public const string PharmacyPhoneNumberRegEx = @"\(\d{3}\)\s\d{3}\-\d{4}";

    //Medicine
    public const int MedicineNameMinLength = 3;
    public const int MedicineNameMaxLength = 150;
    public const decimal MedicinePriceMinRange = 0.01m;
    public const decimal MedicinePriceMaxRange = 1000m;
    public const int MedicineCategoryMinRange = 0;
    public const int MedicineCategoryMaxRange = 4;
    public const int MedicineProducerMinLength = 3;
    public const int MedicineProducerMaxLength = 100;

    //Patient
    public const int PatientFullNameMinLength = 5;
    public const int PatientFullNameMaxLength = 100;
    public const int PatientAgeGroupMinRange = 0;
    public const int PatientAgeGroupMaxRange = 2;
    public const int PatientGenderMinRange = 0;
    public const int PatientGenderMaxRange = 1;
}