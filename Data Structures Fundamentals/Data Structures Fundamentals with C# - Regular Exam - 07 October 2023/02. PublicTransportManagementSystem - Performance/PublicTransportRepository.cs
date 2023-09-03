using System;
using System.Collections.Generic;

namespace PublicTransportManagementSystem
{
    using System.Linq;

    public class PublicTransportRepository : IPublicTransportRepository
    {
        private Dictionary<string, Passenger> passengers;
        private Dictionary<string, Bus> busses;

        public PublicTransportRepository()
        {
            this.passengers = new Dictionary<string, Passenger>();
            this.busses = new Dictionary<string, Bus>();
        }


        public void RegisterPassenger(Passenger passenger)
        {
            this.passengers.TryAdd(passenger.Id, passenger);
        }

        public void AddBus(Bus bus)
        {
            this.busses.TryAdd(bus.Id, bus);
        }

        public bool Contains(Passenger passenger)
            => this.passengers.ContainsKey(passenger.Id);

        public bool Contains(Bus bus)
            => this.busses.ContainsKey(bus.Id);

        public IEnumerable<Bus> GetBuses()
            => this.busses.Values;

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!this.passengers.ContainsKey(passenger.Id) || !this.busses.ContainsKey(bus.Id))
            {
                throw new ArgumentException();
            }

            this.busses[bus.Id].Passengers.Add(passenger);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (!this.passengers.ContainsKey(passenger.Id) || !this.busses.ContainsKey(bus.Id) || !this.busses[bus.Id].Passengers.Contains(passenger))
            {
                throw new ArgumentException();
            }
            /////
            this.busses[bus.Id].Passengers.Remove(passenger);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
            => this.busses[bus.Id].Passengers;

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
            => this.busses.Values
                .OrderBy(b => b.Passengers.Count);

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
            => this.busses.Values
                .Where(b => b.Capacity >= capacity);
    }
}