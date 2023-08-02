namespace EDriveRent.Utilities.Messages
{
    public static class OutputMessages
    {
        public const string UserWithSameLicenseAlreadyAdded = "{0} is already registered in our platform.";

        public const string UserSuccessfullyAdded = "{0} {1} is registered successfully with DLN-{2}";

        public const string VehicleTypeNotAccessible = "{0} is not accessible in our platform.";

        public const string LicensePlateExists = "{0} belongs to another vehicle.";

        public const string VehicleAddedSuccessfully = "{0} {1} is uploaded successfully with LPN-{2}";

        public const string RouteExisting = "{0}/{1} - {2} km is already added in our platform.";

        public const string RouteIsTooLong = "{0}/{1} shorter route is already added in our platform.";

        public const string NewRouteAdded = "{0}/{1} - {2} km is unlocked in our platform.";

        public const string UserBlocked = "User {0} is blocked in the platform! Trip is not allowed.";

        public const string VehicleDamaged = "Vehicle {0} is damaged! Trip is not allowed.";

        public const string RouteLocked = "Route {0} is locked! Trip is not allowed.";

        public const string RepairedVehicles = "{0} vehicles are successfully repaired!";
    }
}
