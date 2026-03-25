namespace StarterCode_WayPoints
{
    internal class Route
    {
        private LinkedList<Waypoint> waypoints;
        private int noOfWaypoints = 0;
        private string routeName;

        //constructor to create an empty route
        public Route(string routename)
        {
            waypoints = new LinkedList<Waypoint>();
            noOfWaypoints = 0;
            routeName = routename;
        }
        public string RouteName
        {
            get { return routeName; }
            set { routeName = value; }
        }
        public int NoOfWaypoints
        {
            get { return noOfWaypoints; }
        }
        //add a waypoint to the end of the route
        public void addWayPoint(Waypoint waypoint)
        {
            waypoints.AddLast(waypoint);
            noOfWaypoints++;
        }
        //
        //display the route - display each waypoint in the route in order
    }
}
