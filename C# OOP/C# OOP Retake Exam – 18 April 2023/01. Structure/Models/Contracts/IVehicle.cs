namespace EDriveRent.Models.Contracts
{
    public interface IVehicle
    {
        public string Brand { get; }

        public string Model { get; }

        public double MaxMileage { get; }

        public string LicensePlateNumber { get; }

        public int BatteryLevel { get; }

        public bool IsDamaged { get; }

        public void Drive(double mileage);

        public void Recharge();

        public void ChangeStatus();
    }
}
