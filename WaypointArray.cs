namespace StarterCode_WayPoints
{
    internal class WaypointArray //class to hold an array of Waypoint objects similar to Stack and Queue classes we have seen before, but with some specific methods to add and display waypoints in the array
    {
        private Waypoint[] waypoints;
        private int WayPointsIndex = 0;
        public WaypointArray(int size)
        {
            waypoints = new Waypoint[size]; // create an array of Waypoint objects with the specified size
            WayPointsIndex = 0;
        }
        public Waypoint[] Waypoints { get { return waypoints; } } // property to access the waypoints array
        public void addWayPoint(Waypoint waypoint)
        {
            if (WayPointsIndex < waypoints.Length)  // check if array is full
            {
                waypoints[WayPointsIndex] = waypoint;
                WayPointsIndex++;
            }
            else
            {
               Console.WriteLine("Waypoint array is full, cannot add more waypoints.");// give a array full message
            }
        }
        public void displayAllWayPoints() // display all waypoints in the array
        {
            for (int i = 0; i < WayPointsIndex; i++)
            {
                Console.WriteLine(waypoints[i].toString());
            }
        }
        public void getNumberOfWayPoints() // display the number of waypoints currently in the array
        {
            Console.WriteLine("number of Waypoints: " + WayPointsIndex);
        }
        public Waypoint SearchWaypoint()
        {
            Console.WriteLine("Enter Waypoint name:");
            string name = Console.ReadLine();
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