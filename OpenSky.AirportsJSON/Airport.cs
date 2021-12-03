﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Airport.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.AirportsJSON
{
    using System.Collections.Generic;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// An airport.
    /// </summary>
    /// <remarks>
    /// sushi.at, 03/12/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class Airport
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the airport has AV gas for refueling.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool HasAvGas { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the airport has jet fuel for refueling.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool HasJetFuel { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the ICAO identifier of the airport.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string ICAO { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the airport is closed.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool IsClosed { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the airport is a military one.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool IsMilitary { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the latitude of the airport.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Latitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the longitude of the airport.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Longitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the airport if available in MSFS 2020.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool MSFS { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string Name { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the runways.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public List<Runway> Runways { get; set; } = new List<Runway>();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the size of the airport (from -1 to 6).
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public int Size { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the airport supports super-heavy aircraft like the Airbus A380.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool SupportsSuper { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the airport if available in X-Plane 11.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool XP11 { get; set; }
    }
}