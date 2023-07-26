namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool isValid(object obj)
            => obj != null;
    }
}
