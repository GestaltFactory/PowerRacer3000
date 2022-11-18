using System;
using System.Threading;
using System.Speech.Synthesis;

#pragma warning disable CA1416 // Validate platform compatibility for SpeechSynthesizer
namespace PowerRacer3000
{
    /// <summary>
    /// Race through the console with this class
    /// </summary>
    class Race
    {
        private readonly SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private int currentLaps = 1;
        private int fullRosterFlag = 0;      

        private int _totalRaceDistance;
        private int _totalLaps;
        private bool _raceState;

        private Driver[] _drivers = new Driver[5];

        /// <summary>
        /// The lenght of the console race
        /// </summary>
        public int TotalRaceDistance
        {
            get => _totalRaceDistance;
            set => _totalRaceDistance = value;
        }

        /// <summary>
        /// The number of total laps
        /// </summary>
        public int TotalLaps
        {
            get => _totalLaps;
            set => _totalLaps = value + 1;
        }

        /// <summary>
        /// The state of the race. Is true while the race is on.
        /// </summary>
        public bool RaceState 
        { 
            get => _raceState; 
            set => _raceState = value; 
        }

        /// <summary>
        /// The list of drivers in the console race
        /// </summary>
        public Driver[] Drivers
        {
            get => _drivers;
            set => _drivers = value;
        }

        /// <summary>
        /// Initialize the race parameters
        /// </summary>
        /// <param name="totalLaps"></param>
        /// <param name="totalRaceDistance"></param>
        /// <param name="drivers"></param>
        /// <param name="raceState"></param>
        public Race(int totalLaps, int totalRaceDistance, Driver[] drivers, bool raceState)
        {
            TotalRaceDistance = totalRaceDistance;
            TotalLaps = totalLaps;
            Drivers = drivers;
            RaceState = raceState;
        }

        /// <summary>
        /// Begin the race if more than 2 drivers are present
        /// </summary>
        public void StartRace()
        {
            if (Drivers.Length > 2)
            {
                synthesizer.SpeakAsync("The race has now begun and this is the first lap.");
                UpdateRace();
            }
            else
            {
                synthesizer.Speak("You need more than one racer for a race. Please add more racer to your roster than restart the application.");
            }
        }

        /// <summary>
        /// Update the status of the race
        /// </summary>
        private void UpdateRace()
        {           
            while (_raceState == false)
            {               
                Console.Clear();
                for (int i = 0; i < Drivers.Length; i++)
                {
                    Drivers[i].Run();
                    for (int j = 0; j < Drivers[i].Distance; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(Drivers[i].Name);
                }

                if (fullRosterFlag == Drivers.Length)
                {
                    fullRosterFlag = 0;
                }

                CheckRace();               
                Thread.Sleep(300);               
            }  
        }

        /// <summary>
        /// Verify if we have reach the end of a lap or the end of the race itself
        /// </summary>
        private void CheckRace()
        {
            for (int i = 0; i < Drivers.Length; i++)
            {
                if (Drivers[i].Distance >= TotalRaceDistance)
                {
                    ChangeLap(i);
                }
            }         
        }

        /// <summary>
        /// Change lap when you reach the end of the console track
        /// </summary>
        /// <param name="i"></param>
        private void ChangeLap(int i)
        {
            fullRosterFlag++;

            if (fullRosterFlag == 1)
            {
                currentLaps++;
                LapAndLeadMarker(i);
            }

            Drivers[i].Lap++;
            Drivers[i].Distance = 0;
        }

        /// <summary>
        /// Inform the user about the current first position
        /// </summary>
        /// <param name="i"></param>
        public void LapAndLeadMarker(int i)
        {
            if (currentLaps == 2)
            {
                synthesizer.SpeakAsync("The second lap is underway and " + Drivers[i].Name + " is the lead.");
            }
            else if (currentLaps == 3)
            {
                synthesizer.SpeakAsync("We are now entering the last lap and " + Drivers[i].Name + " is ahead of the pack.");
            }
            else if (currentLaps == TotalLaps)
            {
                synthesizer.Speak("The winner is " + Drivers[i].Name + " from " + Drivers[i].Manufacturer + ".");
                _raceState = true;
            }
        }
    }
}
#pragma warning restore CA1416 // Validate platform compatibility