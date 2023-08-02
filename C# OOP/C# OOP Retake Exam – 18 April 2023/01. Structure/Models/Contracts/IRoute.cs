namespace EDriveRent.Models.Contracts
{
    public interface IRoute
    {
        public string StartPoint { get; }

        public string EndPoint { get; }

        public double Length { get; }

        public int RouteId { get; }

        public bool IsLocked { get; }

        public void LockRoute();
    }
}
