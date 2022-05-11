namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line) //our Parse method will convert a string into an ITrackable
        {
            logger.LogInfo("Begin parsing"); //every time we parse a string to turn it into an ITrackable, it will show this

            // Take your line and use line.Split(',')
            // to split it up into an array of strings, separated by the char ','
            //line.split will split a string every time it sees a comma and turn it into an array of strings
            //example: {"34.07345","-84.03434", "Taco Bell Acworth..."}
            var cells = line.Split(','); //will contain 3 items in the array

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogWarning("less than three items. incomplete data");

                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }
            //Break up the string into latitude, longitude, and name
            // grab the latitude from your array at index 0
            var latitude = double.Parse(cells[0]); //example: 34.07345 // double.Parse converts string to double

            // grab the longitude from your array at index 1
            var longitude = double.Parse(cells[1]); // double.Parse converts string to double

            // grab the name from your array at index 2
            var name = cells[2];

            // DONE - You'll need to create a TacoBell class 
            // DONE - that conforms to ITrackable

            // Then, you'll need an instance of TacoBell class
            // With the name and point set correctly
            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point; //stores the latitude and longitude
       
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;
        }
    }
}