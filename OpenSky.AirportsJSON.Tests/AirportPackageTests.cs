// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AirportPackageTests.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.AirportsJSON.Tests
{
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Newtonsoft.Json;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Airports package tests.
    /// </summary>
    /// <remarks>
    /// sushi.at, 03/12/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    [TestClass]
    public class AirportPackageTests
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Test package generation, hash comparison and package parsing.
        /// </summary>
        /// <remarks>
        /// sushi.at, 03/12/2021.
        /// </remarks>
        /// -------------------------------------------------------------------------------------------------
        [TestMethod]
        public void TestGenerateAndParsePackage()
        {
            var package = new AirportPackage();
            Debug.WriteLine("Empty package:");
            var json = package.CreatePackage(false);
            Debug.WriteLine(json);
            Debug.WriteLine(package.Hash);
            var emptyHash = package.Hash;

            // Make sure multiple runs don't change the hash
            package.CreatePackage();
            Assert.AreEqual(emptyHash, package.Hash);

            var parsedPackage = AirportPackage.FromPackageJson(json, false);
            Assert.AreEqual(parsedPackage.Hash, package.Hash);
            Assert.AreEqual(parsedPackage.CreatePackage(false), package.CreatePackage(false));
            Assert.AreEqual(parsedPackage.CreatePackage(), package.CreatePackage());

            var loww = new Airport
            {
                ICAO = "LOWW",
                HasAvGas = true,
                HasJetFuel = true,
                IsClosed = false,
                IsMilitary = false,
                Latitude = 48.11027908325195,
                Longitude = 16.569721221923828,
                MSFS = true,
                Name = "Schwechat",
                Size = 5,
                SupportsSuper = true,
                XP11 = true,
            };

            var r1129 = new Runway
            {
                HasLighting = true,
                Length = 11487
            };

            r1129.RunwayEnds.Add(new RunwayEnd
            {
                Name = "11",
                HasClosedMarkings = false,
                Latitude = 48.12283706665039,
                Longitude = 16.53326416015625
            });

            r1129.RunwayEnds.Add(new RunwayEnd
            {
                Name = "29",
                HasClosedMarkings = false,
                Latitude = 48.109031677246094,
                Longitude = 16.57568359375
            });

            var r1634 = new Runway
            {
                HasLighting = true,
                Length = 11819
            };

            r1634.RunwayEnds.Add(new RunwayEnd
            {
                Name = "16",
                HasClosedMarkings = false,
                Latitude = 48.119815826416016,
                Longitude = 16.578155517578125
            });

            r1634.RunwayEnds.Add(new RunwayEnd
            {
                Name = "34",
                HasClosedMarkings = false,
                Latitude = 48.088619232177734,
                Longitude = 16.591339111328125
            });

            loww.Runways.Add(r1129);
            loww.Runways.Add(r1634);

            package.Airports.Add(loww);

            Debug.WriteLine("LOWW package:");
            json = package.CreatePackage(false);
            Debug.WriteLine(json);
            Assert.AreNotEqual(emptyHash, package.Hash);

            parsedPackage = AirportPackage.FromPackageJson(json, false);
            Assert.AreEqual(parsedPackage.Hash, package.Hash);
            Assert.AreEqual(parsedPackage.CreatePackage(false), package.CreatePackage(false));
            Assert.AreEqual(parsedPackage.CreatePackage(), package.CreatePackage());

            Debug.WriteLine("Compression tests:");
            json = package.CreatePackage();
            Debug.WriteLine(json);

            Assert.ThrowsException<JsonReaderException>(() => AirportPackage.FromPackageJson(json, false));
            parsedPackage = AirportPackage.FromPackageJson(json);
            Assert.AreEqual(parsedPackage.Hash, package.Hash);
            Debug.WriteLine(parsedPackage.CreatePackage(false));
        }
    }
}