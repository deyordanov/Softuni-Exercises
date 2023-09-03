using System.Collections.Generic;

namespace PublicTransportManagementSystem
{
    public interface IPublicTransportRepository
    {
        void RegisterPassenger(Passenger passenger);

        void AddBus(Bus bus);

        bool Contains(Passenger passenger);

        bool Contains(Bus bus);

        IEnumerable<Bus> GetBuses();

        void BoardBus(Passenger passenger, Bus bus);

        void LeaveBus(Passenger passenger, Bus bus);

        IEnumerable<Passenger> GetPassengersOnBus(Bus bus);

        IEnumerable<Bus> GetBusesOrderedByOccupancy();

        IEnumerable<Bus> GetBusesWithCapacity(int capacity);
    }
}
