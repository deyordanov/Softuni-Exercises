namespace PublicTransportManagementSystem
{
    using System.Collections.Generic;

    public class Bus
    {
        public Bus()
        {
            this.Passengers = new List<Passenger>();
        }

        public string Id { get; set; }
    
        public string Number { get; set; }
    
        public int Capacity { get; set; }

        public List<Passenger> Passengers { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}