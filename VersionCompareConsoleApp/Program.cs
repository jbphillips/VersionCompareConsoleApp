using System;

namespace VersionCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string version1 = "1.2.3";  // for example
            string version2 = "1.2.2";  // for example
            int comparisonResult = VersionHelper.VersionCompare(version1, version2);
            Console.WriteLine("The comparison result is: " + comparisonResult);

            Console.ReadLine();
        }
    }

    public class VersionHelper
    {
        // This will compare the two version numbers and return -1 if the first is lower,
        // 0 if they are equal, or 1 if the first is larger. The function assumes that version
        // numbers are in the format "major.minor.patch", but it can handle
        // version numbers with more or fewer parts as well.
        public static int VersionCompare(string version1, string version2)
        {
            //Insert your code here 
            // Split the version strings into arrays of integers
            var v1 = version1.Split('.').Select(int.Parse).ToArray();
            var v2 = version2.Split('.').Select(int.Parse).ToArray();

            // Compare each part of the version numbers
            for (int i = 0; i < Math.Max(v1.Length, v2.Length); i++)
            {
                int part1 = i < v1.Length ? v1[i] : 0;
                int part2 = i < v2.Length ? v2[i] : 0;

                if (part1 < part2)
                    return -1;
                if (part1 > part2)
                    return 1;
            }

            // If all parts are equal, return 0
            return 0;
        }
    }
}
