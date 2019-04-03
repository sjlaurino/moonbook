using System;
using moonbook.Models;

namespace moonbook
{
    class App
    {
        public IDestination CurrentLocation { get; set; }
        public bool Running { get; set; }


        private void Initialize()
        {

            //Create all Planets
            Planet mercury = new Planet("Mercury", "Its hot here, where is Freddy");
            Planet venus = new Planet("Venus", "Everything is melting, where da ladies at");
            Planet earth = new Planet("Earth", "What kind of name is Earth, might as well call it dirt");
            Planet mars = new Planet("Mars", "This planet is entirely inhabited by robots, potatos, and Matt Damon where da boys at");
            Planet jupiter = new Planet("Jupiter", "GAS GIANT.... ppppffftttt");
            Planet saturn = new Planet("Saturn", "HUge rings yall");
            Planet uranus = new Planet("Uranus", "Nope, not even going there");
            Planet neptune = new Planet("Neptune", "Also roman god of the sea, fun fact.");
            Planet pluto = new Planet("Pluto", "ITS TOTALLY A PLANET!!!! Hey is that Arnold?");


            //create moons
            Moon luna = new Moon("Moon", "Its not cheese", earth);
            Moon phobos = new Moon("Phobos", "The better of the two", mars);
            Moon europa = new Moon("Europa", "Yo dawg we herd you like moons", jupiter);
            Moon titan = new Moon("Titan", "AE", saturn);

            //establish relationships
            mercury.AddNearbyDest(Direction.next, venus);
            venus.AddNearbyDest(Direction.previous, mercury);
            venus.AddNearbyDest(Direction.next, earth);
            earth.AddNearbyDest(Direction.moon, luna);
            earth.AddNearbyDest(Direction.previous, venus);
            earth.AddNearbyDest(Direction.next, mars);
            //ETC.


            CurrentLocation = earth;
            Running = true;


        }

        public void Run()
        {
            Initialize();
            while (Running)
            {
                System.Console.WriteLine($"{CurrentLocation.Name}: {CurrentLocation.Description}");
                if (CurrentLocation is Planet)
                {
                    HandlePlanetInput();
                }
                else
                {
                    Moon curMoon = (Moon)CurrentLocation;
                    System.Console.WriteLine(" Returning to planet");
                    CurrentLocation = curMoon.Return();
                }
            }

        }

        private void HandlePlanetInput()
        {
            System.Console.WriteLine("Next, Previous, or Moon");
            string choice = Console.ReadLine();
            Planet curPlanet = (Planet)CurrentLocation;
            //switch to determine next prev or moon
        }
    }
}