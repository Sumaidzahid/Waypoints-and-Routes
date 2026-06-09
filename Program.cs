using System.Text;

namespace StarterCode_WayPoints
{
    internal class Program
    {
        //directory containing file
        static string FILE_PATH = "C:\\MMU\\Algorithms and data Structures\\WAY_POINT\\"; //set path to solution directory
        static string fileName = "UK_waypoints.csv"; //file to read
        static WaypointArray waypointarray = new WaypointArray(5000);
        static RouteArray routearray = new RouteArray(100);
        static void Main(string[] args)
        {
            readDisplayFileWayPoints(FILE_PATH + fileName);
            //To Do : Add your test code here to show that each criteria you attempted is working
            //2. Display all waypoints in array (DONE)
            //3. Create a route and display a route (DONE)
            //4. insert a waypoint in a specific place route - display edited route (DONE)
            //5. remove a waypoint - display edited route (DONE)
            do
            {
                Console.WriteLine("\nPlease select an option (1,2,3,4,5,6):\n");
                Console.WriteLine("1. Display all Waypoints.");
                Console.WriteLine("2. Total number of Waypoints.");
                Console.WriteLine("3. Select a Waypoint.");
                Console.WriteLine("4. Create a Waypoint.");
                Console.WriteLine("5. Create a Route.");
                Console.WriteLine("6. Add Waypoint at front of the Route.");
                Console.WriteLine("7. Add Waypoint at end of the Route.");
                Console.WriteLine("8. Insert Waypoint at specific place in the Route.");
                Console.WriteLine("9. Remove a Waypoint from the Route.");
                Console.WriteLine("10. Display a Route.");
                Console.WriteLine("11. Exit\n");

                if (int.TryParse(Console.ReadLine(), out int Choice))
                {
                    switch (Choice)
                    {
                        case 1: { waypointarray.displayAllWayPoints(); break; }
                        case 2: { waypointarray.getNumberOfWayPoints(); break; }
                        case 3: { waypointarray.SearchWaypoint(); break; }
                        case 4: { waypointarray.addWayPoint(); break; }
                        case 5:
                            {
                                Route addroute = routearray.addRoute();
                                if (addroute == null) continue;
                                while (true)
                                {
                                    Console.WriteLine("press enter to add another waypoint or type 'done' to finish:\n");
                                    if (Console.ReadLine().ToLower() == "done") break;
                                    Waypoint wp = waypointarray.SearchWaypoint();
                                    if (wp != null)
                                    {
                                        addroute.addFrontWayPoint(wp);
                                    }
                                }
                                break;
                            }
                        case 6:
                            {
                                if (!routearray.displayAllRoutes()) { continue; }
                                Route addfront = routearray.SearchRoute();
                                if (addfront == null) continue;
                                while (true)
                                {
                                    Waypoint wp = waypointarray.SearchWaypoint();
                                    if (wp == null) continue;
                                    addfront.addFrontWayPoint(wp);
                                    Console.WriteLine("Waypoint added to front of route. Add another? (y/n)");
                                    if (Console.ReadLine().ToLower() != "y") break;
                                }
                                break;
                            }
                        case 7:
                            {
                                if (!routearray.displayAllRoutes()) { continue; }
                                Route addend = routearray.SearchRoute();
                                if (addend == null) continue;
                                while (true)
                                {
                                    Waypoint wp = waypointarray.SearchWaypoint();
                                    if (wp == null) continue;
                                    addend.addEndWayPoint(wp);
                                    Console.WriteLine("Waypoint added to end of route. Add another? (y/n)");
                                    if (Console.ReadLine().ToLower() != "y") break;
                                }
                                break;
                            }
                        case 8:
                            {
                                if (!routearray.displayAllRoutes()) { continue; }
                                Route insert = routearray.SearchRoute();
                                if (insert == null) continue;
                                while (true)
                                {
                                    Waypoint wp = waypointarray.SearchWaypoint();
                                    if (wp == null) continue;
                                    Console.WriteLine("Enter the index to insert the waypoint at:");
                                    int index = int.Parse(Console.ReadLine());
                                    insert.InsertSpecific(wp, index);
                                    Console.WriteLine("Waypoint inserted at index " + index + ". Insert another? (y/n)");
                                    if (Console.ReadLine().ToLower() != "y") break;
                                }
                                break;
                            }
                        case 9:
                            {
                                if (!routearray.displayAllRoutes()) { continue; }
                                Route remove = routearray.SearchRoute();
                                if (remove == null) continue;
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of the waypoint to remove:");
                                    string name = Console.ReadLine();
                                    remove.RemoveWayPoint(name);
                                    remove.displayRoute();
                                    Console.WriteLine("Waypoint removed. Remove another? (y/n)");
                                    if (Console.ReadLine().ToLower() != "y") break;
                                }
                                break;
                            }

                        case 10:
                            {
                                if (!routearray.displayAllRoutes()) { continue; }
                                Route displayroute = routearray.SearchRoute();
                                if (displayroute != null) displayroute.displayRoute();
                                break;
                            }
                        case 11:
                            {
                                Console.WriteLine("Exiting Program...");
                                return;
                            }

                        default: { Console.WriteLine("Invalid Choice"); break; }
                    }
                }
            } while (true);
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

                    waypointarray.getFileWaypoints(new Waypoint(name, code, latitude, longitude, elevation, description));
                }
            }
        }
/*
        static void displayWayPoint(string name, string code, string latitude, string longitude, int elevation, string description)
        {
            Console.Write("WayPoint: " + name + ",Code:" + code);
            Console.Write(",Position:[" + latitude + "," + longitude + "]");
            Console.WriteLine(",Elevation:" + elevation + "m");
            Console.WriteLine(description);
        }
*/
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

