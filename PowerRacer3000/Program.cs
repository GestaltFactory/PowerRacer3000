/// <summary>
/// Everything has been implemented. + some added fun features. I gave you the video because you need to have the
/// System.Speech.Synthesis from the nuget packages install to activate the project ref and have access to the namespace
/// The only validation was about not having less than 2 players. I did that one in start race method of the Race class. 
/// </summary>

namespace PowerRacer3000
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver[] drivers = DriverGeneration();
            Race race = new(3, 50, drivers, false);
            race.StartRace();
        }

        /// <summary>
        /// Create the drivers
        /// </summary>
        /// <returns>Return the list of drivers</returns>
        private static Driver[] DriverGeneration()
        {
            Driver[] drivers = new Driver[5];

            Driver driver1 = new(1, "Carl", "Ferrari");
            Driver driver2 = new(1, "Even", "Porsh");
            Driver driver3 = new(1, "Mike", "Chrisler");
            Driver driver4 = new(1, "Riny", "Tesla");
            Driver driver5 = new(1, "Mary", "Ford");

            drivers[0] = driver1;
            drivers[1] = driver2;
            drivers[2] = driver3;
            drivers[3] = driver4;
            drivers[4] = driver5;

            return drivers;
        }
    }
}
