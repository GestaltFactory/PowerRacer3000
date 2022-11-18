using System;

namespace PowerRacer3000
{
    /// <summary>
    /// Info about the driver
    /// </summary>
    class Driver
    {
        private int _distance;
        private int _lap;
        private string _name;
        private string _manufacturer;

        /// <summary>
        /// Distance presently driven
        /// </summary>
        public int Distance 
        { 
            get => _distance; 
            set => _distance = value; 
        }

        /// <summary>
        /// The lap this current driver is at
        /// </summary>
        public int Lap
        {
            get => _lap;
            set => _lap = value;
        }

        /// <summary>
        /// The name of the driver
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// The manufacturer of the driver's car
        /// </summary>
        public string Manufacturer
        {
            get => _manufacturer;
            set => _manufacturer = value;
        }

        /// <summary>
        /// Driver constructor
        /// </summary>
        /// <param name="lap"></param>
        /// <param name="name"></param>
        /// <param name="manufacturer"></param>
        public Driver(int lap, string name, string manufacturer)
        {
            Lap = lap;
            Name = name;
            Manufacturer = manufacturer;
        }

        /// <summary>
        /// Randomly move the driver horizontally withion the console
        /// </summary>
        public void Run()
        {
            Random random = new Random();
            Distance += random.Next(1, 5);
        }
    }
}
