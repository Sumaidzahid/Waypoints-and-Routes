namespace StarterCode_WayPoints
{
    //Link
    class RouteNode
    {
        private Waypoint waypoint;
        private RouteNode next;
        public RouteNode(Waypoint waypoint)
        {
            this.waypoint = waypoint;
            this.next = null;
        }
        public RouteNode(Waypoint waypoint, RouteNode next)
        {
            this.waypoint = waypoint;
            this.next = next;
        }
        public Waypoint Waypoint
        {
            get { return this.waypoint; }
            set { this.waypoint = value; }
        }
        public RouteNode Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

    }
    //Linked List
    internal class Route
    {
        private RouteNode route_wps = null; // head of the linked list, initially null
        private int noOfWaypoints = 0;
        private string routeName;

        //constructor to create an empty route
        public Route(string routename)
        {
            route_wps = null;
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
        //addFront
        //add a waypoint to the front of the route
        public void addFrontWayPoint(Waypoint waypoint)
        {
            route_wps = new RouteNode(waypoint, route_wps);
            noOfWaypoints++;
        }
        public void addEndWayPoint(Waypoint waypoint)
        {
            if (route_wps == null)
            {
                route_wps = new RouteNode(waypoint);
            }
            else
            {
                RouteNode currentNode = route_wps;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new RouteNode(waypoint);
            }
            noOfWaypoints++;
        }
        //display the route - display each waypoint in the route in order
        public void displayRoute()
        {
            RouteNode currentNode = route_wps; // start at the head of the list
            Console.WriteLine("Route: " + routeName);
            Console.WriteLine("Number of Waypoints: " + noOfWaypoints);
            while (currentNode != null)
            {
                Console.WriteLine("\nWaypoints:\n");
                Console.WriteLine(currentNode.Waypoint.ToString());
                currentNode = currentNode.Next;
            }
        }
        public void RemoveWayPoint(string name)
        {
            RouteNode currentnode = route_wps; // start at the head of the list
            if (route_wps == null)
            {
                Console.WriteLine("Route is empty. No waypoints to remove.");
                return;
            }
            if (route_wps.Waypoint.Name == name)
            {
                route_wps = route_wps.Next; // remove the head of the list if it matches the name
                noOfWaypoints--;
                return;
            }
            while (currentnode.Next != null)
            {
                if (name.CompareTo(currentnode.Next.Waypoint.Name) == 0)
                {
                    currentnode.Next = currentnode.Next.Next;
                    noOfWaypoints--;
                }
                else { currentnode = currentnode.Next; }

                }
        }
        public void InsertSpecific(Waypoint waypoint, int index)
        {
            if (index < 0 || index > noOfWaypoints)
            {
                Console.WriteLine("Invalid index. Please enter a valid index between 0 and " + noOfWaypoints);
                return;
            }
            if (index == 0)
            {
                addFrontWayPoint(waypoint);
                return;
            }
            if (index == noOfWaypoints)
            {
                addEndWayPoint(waypoint);
                return;
            }
            RouteNode currentNode = route_wps; // start at the head of the list
            for (int i=0;i<index-1;i++) // traverse the list until we reach the node before the desired index
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = new RouteNode(waypoint, currentNode.Next); // create a new node (Link) with the waypoint and set its next to the current node's next
            noOfWaypoints++;
        }
    }
}