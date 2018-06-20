// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 06-20-2018
//
// Last Modified By : Bill Banks
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="Zips.cs" company="Ourweb.net">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{

    /// <summary>
    /// Class Zips.
    /// </summary>
    public class Zips
    {
        /// <summary>
        /// Gets or sets the zip codes.
        /// </summary>
        /// <value>The zip codes.</value>
        [JsonProperty("zip_codes")]
        public List<ZipCodes> ZipCodes { get; set; }
    }
    /// <summary>
    /// Class ZipCodes.
    /// </summary>
    public class ZipCodes
    {
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>The distance.</value>
        [JsonProperty("distance")]
        public double Distance { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public string State { get; set; }
    }

}