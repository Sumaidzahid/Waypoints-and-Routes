using System.Text;

namespace StarterCode_WayPoints
{
    internal class Program
    {
        //directory containing file
        static string FILE_PATH = "C:\\MMU\\Algorithms and data Structures\\WAY_POINT\\"; //set path to solution directory
        static string fileName = "UK_waypoints.csv"; //file to read

        static void Main(string[] args)
        {
            readDisplayFileWayPoints(FILE_PATH + fileName);
            //To Do : Add your test code here to show that each criteria you attempted is working
            //2. Display all waypoints in array
            //3. Create a route and display a route
            //4. insert a waypoint in a specific place route - display edited route
            //5. remove a waypoint - display edited route
        }

        static void readDisplayFileWayPoints(string fileName)
        {
            string[] linesInFile = File.ReadAllLines(fileName); //Read whole file into array of string
            int lineNumber = 0;

            foreach (string line in linesInFile) //take each line string from the file one at a time
            {
                lineNumber++; //increment the current line number
                              //split up line into separate features split by commas array of strings, each element is a word on the current line
                if (lineNumber != 1 && line != "") //ignore line 1 (column headers) and any empty lines
                {
                    string[] featuresInLine = line.Split(','); //csv file, split each line based on ','
                                                               //11 features, ignore: country,style,rwdir,rwlen,freq
                    string name = featuresInLine[0];
                    string code = featuresInLine[1];
                    string latitude = featuresInLine[3];
                    string longitude = featuresInLine[4];
                    int elevation = convertElevationToMeters(featuresInLine[5]); //some in ft, some in m - convert to meters
                    string description = buildDescription(featuresInLine);

                    displayWayPoint(name, code, latitude, longitude, elevation, description);
                }
            }
        }

        static void displayWayPoint(string name, string code, string latitude, string longitude, int elevation, string description)
        {
            Console.Write("WayPoint: " + name + ",Code:" + code);
            Console.Write(",Position:[" + latitude + "," + longitude + "]");
            Console.WriteLine(",Elevation:" + elevation + "m");
            Console.WriteLine(description);
        }


        //Description starts at feature 11 but it may contain commas
        //so we need to concat all remaining strings on the line to be the description
        static string buildDescription(string[] featuresInLine)
        {
            StringBuilder description = new StringBuilder();
            int arrayPosition = 11; //position of start of Description
            string descriptionPart;
            while (arrayPosition < featuresInLine.Length)
            {
                descriptionPart = featuresInLine[arrayPosition];
                if (isText(descriptionPart))
                {
                    description.Append(descriptionPart + ",");
                }
                arrayPosition++;
            }
            return description.ToString();
        }
        static Boolean isText(string str)
        {
            if (str == "" || str == " ")
                return false;
            return true;
        }

        static int convertElevationToMeters(string elevationStr)
        {
            char[] unitChars = { 'f', 't', 'M', 'm' };
            if (elevationStr.ToLower().EndsWith("m"))
            {
                return (int)Double.Parse(elevationStr.TrimEnd(unitChars));
            }

            double elevationFeet = Double.Parse(elevationStr.TrimEnd(unitChars));
            return (int)(elevationFeet / 3.142); //constant for ft to m
        }
    }
}

