using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace iTravel.UITest
{
    [TestFixture]
    public class Tests
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {

            app = ConfigureApp
                .iOS
                //.DeviceIdentifier("7CB431E9-3027-4105-89F7-E6819E1D5080")
                //.AppBundle("../../../iTravel/bin/iPhoneSimulator/Debug/iTravel.app")
                //.InstalledApp("")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.Repl();
        }
    }
}
