namespace Exam.MobileX
{
    public class Vehicle
    {
        public Vehicle(string id, string brand, string model, string location, string color, int horsepower, double price, bool isVIP)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Location = location;
            Color = color;
            Horsepower = horsepower;
            Price = price;
            IsVIP = isVIP;
        }

        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Location { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }

        public double Price { get; set; }

        public bool IsVIP { get; set; }

        public string SellerName { get; set; }
    }
}
