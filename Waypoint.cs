namespace StarterCode_WayPoints
{
    internal class Waypoint
    {
        private string name;
        private string code;
        private string latitude;
        private string longitude;
        private int altitude;
        private string description;
        // constructor for a waypoint object with all features
        public Waypoint(string name, string code, string latitude, string longitude, int altitude, string description)
        {
            this.name = name;
            this.code = code;
            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
            this.description = description;
        }

        // properties for each feature of a waypoint
        public string Name
        {
            get { return name; }
            set { name = value; } 
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public int Altitude
        {
            get { return altitude; }
            set { altitude = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // display a single waypoint
        public string toString()
        {
            return "WayPoint: " + name + ", Code:" + code + ", Position: [ " + latitude + " , " + longitude + " ], Elevation:" + altitude + "m\nDiscription:\n" + description + "\n";
        }
    }
}
