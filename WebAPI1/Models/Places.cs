// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 06-26-2018
//
// Last Modified By : Bill Banks
// Last Modified On : 06-26-2018
// ***********************************************************************
// <copyright file="Places.cs" company="Ourweb.net">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{
    /// <summary>
    /// Class Places.
    /// </summary>
    public class Places
    {
        /// <summary>
        /// Gets or sets the zipcode.
        /// </summary>
        /// <value>The zipcode.</value>
        public string Zipcode { get; set; }
        /// <summary>
        /// Gets or sets the place identifier.
        /// </summary>
        /// <value>The place identifier.</value>
        public string PlaceID { get; set; }
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; set; }
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; set; }
    }
}