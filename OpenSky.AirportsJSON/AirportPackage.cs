// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AirportPackage.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.AirportsJSON
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// The airports package.
    /// </summary>
    /// <remarks>
    /// sushi.at, 03/12/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class AirportPackage
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the airports.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public List<Airport> Airports { get; set; } = new List<Airport>();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the SHA-256 hash value of the package (added as a last step before saving).
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string Hash { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates package object from (compressed) JSON string.
        /// </summary>
        /// <remarks>
        /// sushi.at, 03/12/2021.
        /// </remarks>
        /// <exception cref="Exception">
        /// If JSON cannot be parsed.
        /// </exception>
        /// <param name="jsonString">
        /// The JSON string.
        /// </param>
        /// <param name="isCompressed">
        /// (Optional) True if the JSON string is gzipped.
        /// </param>
        /// <returns>
        /// The airports package.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public static AirportPackage FromPackageJson(string jsonString, bool isCompressed = true)
        {
            if (isCompressed)
            {
                jsonString = jsonString.DecompressFromBase64();
            }

            var package = JsonConvert.DeserializeObject<AirportPackage>(jsonString);
            if (package == null)
            {
                throw new Exception("Error deserializing airport client package JSON.");
            }

            return package;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates a gzip compressed, base64 encoded json string and updates the Hash property.
        /// </summary>
        /// <remarks>
        /// sushi.at, 03/12/2021.
        /// </remarks>
        /// <param name="compress">
        /// (Optional) True to compress the output using gzip.
        /// </param>
        /// <returns>
        /// The new package.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public string CreatePackage(bool compress = true)
        {
            // Make sure not to include the hash property for the new SHA256 calculation
            this.Hash = null;

            var jObject = JObject.FromObject(this);
            var jsonString = jObject.ToString(Formatting.None);

            using (var sha256Hash = SHA256.Create())
            {
                var jsonHash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(jsonString));
                this.Hash = Convert.ToBase64String(jsonHash);
            }

            jObject = JObject.FromObject(this);
            jsonString = jObject.ToString(Formatting.None);

            return compress ? jsonString.CompressToBase64() : jsonString;
        }
    }
}