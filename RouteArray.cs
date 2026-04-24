using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterCode_WayPoints
{
    internal class RouteArray
    {
        private Route[] routes;
        private int RouteIndex = 0;

        public RouteArray(int size)
        {
            routes = new Route[size]; // create an array of Route objects with the specified size
            RouteIndex = 0;
        }
        public Route[] Routes{ get { return routes; } }
        public Route? SearchRoute()
        {
            Console.WriteLine("Enter the name of the route:");
            string? routeName = Console.ReadLine();
            if (routeName == null) return null;
            for (int i = 0;i<RouteIndex;i++)
            {
                if (routes[i].RouteName == routeName){ return routes[i]; }
            }
            Console.WriteLine("Route not found.");
            return null;
        }
        public Route? addRoute()
        {
            if (RouteIndex < routes.Length) // check if array is full
            {
                Console.WriteLine("Enter Route Name:");
                string? routeName = Console.ReadLine();
                if (routeName == null) return null;
                Route newRoute = new Route(routeName);
                routes[RouteIndex] = newRoute;
                RouteIndex++;
                return newRoute;
            }
            else
            {
                Console.WriteLine("Route array is full, cannot add more routes.");
                return null;
            }
        }
        public bool displayAllRoutes()
        {
            if (RouteIndex == 0)
            {
                Console.WriteLine("No routes available.");
                return false;
            }
            for (int i=0;i<RouteIndex;i++)
            {
                Console.WriteLine("Route Name: " + routes[i].RouteName); 
                Console.WriteLine("Number of Waypoints: " + routes[i].NoOfWaypoints);
            }
            return true;
        }
    }
}
