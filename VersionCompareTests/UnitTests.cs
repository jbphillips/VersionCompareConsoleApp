namespace VersionCompareTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEqual()
        {
            bool allPass = true;

            // should be equal
            allPass &= (0 == VersionCompare.VersionHelper.VersionCompare("1", "1"));
            allPass &= (0 == VersionCompare.VersionHelper.VersionCompare("1.1", "1.1"));
            allPass &= (0 == VersionCompare.VersionHelper.VersionCompare("3.3.20", "3.3.20"));

            Assert.True(allPass);
        }

        [Test]
        public void TestLower()
        {
            bool allPass = true;

            // v1 should be lower
            allPass &= (-1 == VersionCompare.VersionHelper.VersionCompare("1", "2"));
            allPass &= (-1 == VersionCompare.VersionHelper.VersionCompare("1.0", "1.0.1"));
            allPass &= (-1 == VersionCompare.VersionHelper.VersionCompare("1.0", "1.1"));
            allPass &= (-1 == VersionCompare.VersionHelper.VersionCompare("1.0.0.3", "1.1"));
            allPass &= (-1 == VersionCompare.VersionHelper.VersionCompare("1.2.3.4", "1.2.3.48"));
            allPass &= (-1 == VersionCompare.VersionHelper.VersionCompare("1.2.3.4", "1.2.3.4.8"));
            allPass &= (-1 == VersionCompare.VersionHelper.VersionCompare("1.8.0", "20.0.0.0"));
            allPass &= (-1 == VersionCompare.VersionHelper.VersionCompare("5.6.0.788.2", "20.0.0.0"));

            Assert.True(allPass);
        }

        [Test]
        public void TestHigher()
        {
            bool allPass = true;

            // v1 should be higher
            allPass &= (1 == VersionCompare.VersionHelper.VersionCompare("2", "1"));
            allPass &= (1 == VersionCompare.VersionHelper.VersionCompare("1.0.1", "1.0"));
            allPass &= (1 == VersionCompare.VersionHelper.VersionCompare("1.1", "1.0"));
            allPass &= (1 == VersionCompare.VersionHelper.VersionCompare("1.1", "1.0.0.3"));
            allPass &= (1 == VersionCompare.VersionHelper.VersionCompare("1.2.3.5", "1.2.3.4"));
            allPass &= (1 == VersionCompare.VersionHelper.VersionCompare("1.2.3.50", "1.2.3.48"));
            allPass &= (1 == VersionCompare.VersionHelper.VersionCompare("20.0.0.0", "5.6.0.788.2"));

            Assert.True(allPass);
        }
    }
}