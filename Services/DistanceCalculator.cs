namespace iranAttractions.Services
{
    public static class DistanceCalculator
    {
        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // شعاع زمین به کیلومتر
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; // فاصله بر حسب کیلومتر
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }

}
