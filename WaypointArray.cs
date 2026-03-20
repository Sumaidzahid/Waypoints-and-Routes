namespace StarterCode_WayPoints
{
    internal class WaypointArray //class to hold an array of Waypoint objects similar to Stack and Queue classes we have seen before, but with some specific methods to add and display waypoints in the array
    {
        private Waypoint[] waypoints;
        private int numberOfWayPoints = 0;

        public WaypointArray(int size)
        {
            waypoints = new Waypoint[size]; // create an array of Waypoint objects with the specified size
            numberOfWayPoints = 0;
        }

        public void addWayPoint(Waypoint waypoint)
        {
            if (numberOfWayPoints < waypoints.Length)
            {
                waypoints[numberOfWayPoints] = waypoint;
                numberOfWayPoints++;
            }
            else
            {
                Console.WriteLine("Waypoint array is full, cannot add more waypoints.");
            }
        }

        public void displayAllWayPoints()
        {
            for (int i = 0; i < numberOfWayPoints; i++)
            {
                Console.WriteLine(waypoints[i].toString());
            }
        }
    }
}
