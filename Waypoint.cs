namespace StarterCode_WayPoints
{
    internal class Waypoint
    {
        private string name;
        private string code;
        private string latitude;
        private string longitude;
        private string altitude;
        private string description;

        public Waypoint(string name, string code, string latitude, string longitude, string altitude, string description)
        {
            this.name = name;
            this.code = code;
            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
            this.description = description;
        }

        //public string toString()
        //{
        //    return "WayPoint: " + name + ",Code:" + code + ",Position:[" + latitude + "," + longitude + "],Elevation:" + altitude + "m\n" + description;
        //}
    }
}
