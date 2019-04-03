using System;
using System.Collections.Generic;

namespace moonbook.Models
{
    class Planet : IDestination
    {
        public string Name { get; set; }
        public string Description { get; set; }
        List<string> GuestBook { get; set; }
        Dictionary<Direction, IDestination> NearbyDestinations { get; set; }
        public void SignBook(string name)
        {
            GuestBook.Add(name);
        }
        public void PrintGuestBook()
        {
            Console.WriteLine("Visitors to our planet: ");
            GuestBook.ForEach(name =>
            {
                Console.WriteLine(name);
            });
        }
        public void AddNearbyDest(Direction direction, IDestination dest)
        {
            NearbyDestinations.Add(direction, dest);
        }
        public IDestination TraveltoDest(Direction dir)
        {
            if (NearbyDestinations.ContainsKey(dir))
            {
                return NearbyDestinations[dir];
            }
            System.Console.WriteLine("Your Ship cant go that way Capt'n");
            return (IDestination)this;
        }
        public Planet(string name, string desc)
        {
            NearbyDestinations = new Dictionary<Direction, IDestination>();
            GuestBook = new List<string>();
            Name = name;
            Description = desc;
        }
    }

    public enum Direction
    {
        next,
        previous,
        moon
    }
}
