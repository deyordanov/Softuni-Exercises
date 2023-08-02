namespace EDriveRent.Models.Contracts
{
    public interface IUser
    {
        public string FirstName { get; }

        public string LastName { get; }

        public double Rating { get; }

        public string DrivingLicenseNumber { get; }

        public bool IsBlocked { get; }

        void IncreaseRating();

        void DecreaseRating();
    }
}
