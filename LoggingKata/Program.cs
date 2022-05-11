using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log an error if you get 0 lines and a warning if you get 1 line
            string[] lines = File.ReadAllLines(csvPath); //reads the csv file and creates an array of 237 strings 

            if (lines.Length == 0)
            {
                logger.LogError("File has no input");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("File has only one line of input");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(line => parser.Parse(line)).ToArray(); //collection after you apply parse method to each line
                                                                                //basically foreach var line in lines - parse that line and store it in locations (list of TB locations)
                                                                                //if we didn't have the .ToArray, then locations would be an IEnumerable

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distance = 0;

            // Done - Include Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            for (int i = 0; i < locations.Length; i++)
            {
                // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
                var locA = locations[i]; //locationA variable

                // Create a new corA Coordinate with your locA's lat and long
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                // Now, do another loop on locations with scope of your first loop,
                // so you can grab "destination" location (perhaps: `locB`)
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];

                    // Create new Coordinate with your locB's lat and long
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    // If the distance is greater than the currently saved distance,
                    // update distance and the two `ITrackable` variables you set above
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }


                }
            }



            // Once you've looped through everything,
            // you've found the two Taco Bells farthest away from each other.
            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are the farthest apart.");



        }
    }
}
