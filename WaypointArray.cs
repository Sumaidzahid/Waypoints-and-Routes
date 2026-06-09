namespace StarterCode_WayPoints
{
    //class to hold an array of Waypoint objects similar to Stack and Queue
    internal class WaypointArray 
    {
        private Waypoint[] waypoints;
        private int WayPointsIndex = 0;
        public WaypointArray(int size)
        {
            waypoints = new Waypoint[size]; // create an array of Waypoint objects with the specified size
            WayPointsIndex = 0;
        }
        public Waypoint[] Waypoints { get { return waypoints; } } // property to access the waypoints array
        public void getFileWaypoints(Waypoint fileWaypoints) 
        {
            if (WayPointsIndex < waypoints.Length) // check if array is full
            {
                waypoints[WayPointsIndex] = fileWaypoints; 
                WayPointsIndex++; 
            }
            else {Console.WriteLine("Waypoint array is full");} 
        }

        // add a waypoint to the array
        public void addWayPoint() 
        { 
            if (WayPointsIndex < waypoints.Length) // check if array is full
            { 
                Console.WriteLine("Enter: Waypoint Name, Code, Latitude, Longitude, Elevation and Description"); 
                Console.WriteLine("Example: Waypoint1, WP1, 40.7128 N, 74.0060 W, 10, This is a waypoint"); 
                Console.WriteLine("specified format:"); 
                Console.WriteLine("(separated by commas, new elevation in meters)"); 
                string? input = Console.ReadLine();
                if (input == null) {Console.WriteLine("Invalid input"); return; }
                string[] features = input.Split(',');
                string name = features[0]; 
                string code = features[1]; 
                string latitude = features[2]; 
                string longitude = features[3];
                if (!int.TryParse(features[4], out int altitude)) { Console.WriteLine("Invalid input"); return; }
                //int altitude = int.Parse(features[4]);
                string description = features[5]; 

                Waypoint newWaypoint = new Waypoint(name, code, latitude, longitude, altitude, description); 
                waypoints[WayPointsIndex] = newWaypoint; 
                WayPointsIndex++; 
            } 
            else 
            { 
                Console.WriteLine("Waypoint array is full, cannot add more waypoints.");// give a array full message
            }
        }
        public void displayAllWayPoints() // display all waypoints in the array
        {
            for (int i=0;i<WayPointsIndex;i++)
            {
                Console.WriteLine(waypoints[i].toString());
            }
        }
        public void getNumberOfWayPoints() // display the number of waypoints currently in the array
        {
            Console.WriteLine("number of Waypoints: " + WayPointsIndex);
        }
        public Waypoint? SearchWaypoint()
        {
            Console.WriteLine("Enter Waypoint name:");
            string? name = Console.ReadLine();
            if (name == null) return null;
            for (int i = 0; i < WayPointsIndex; i++)
            {
                if (waypoints[i].Name.ToLower() == name.ToLower())
                {
                    Console.WriteLine(waypoints[i].toString());
                    return waypoints[i];
                }
            }
            Console.WriteLine("Waypoint not found.");
            return null;
        }
    }
}