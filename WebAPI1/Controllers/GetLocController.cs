// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 06-24-2018
//
// Last Modified By : Bill Banks
// Last Modified On : 06-24-2018
// ***********************************************************************
// <copyright file="GetLocController.cs" company="Ourweb.net">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoogleMapsAPI.NET;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Geocoding.Components;

namespace WebAPI1.Controllers
{
    /// <summary>
    /// Class GetLocController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class GetLocController : ApiController
    {
        /// <summary>
        /// The googlekey
        /// </summary>
        public const string GOOGLEKEY = "AIzaSyABff2oLcuHsYrLgZa5mzeqANO3aeaSf3M";

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <param name="lng">The LNG.</param>
        /// <param name="lat">The lat.</param>
        /// <returns>System.String.</returns>
        [HttpGet]
        public string GetInfo(double lng, double lat)
        {
            var client = new MapsAPIClient(GOOGLEKEY);
            string zip = "";
            // Look up an address with reverse geocoding
            var reverseGeocodeResult = client.Geocoding.ReverseGeocode(lat, lng);

            var fadd = reverseGeocodeResult.Results[0].FormattedAddress;
            int len = fadd.Length;
            if (len > 20)
                zip = fadd.Substring(len - 10, len - 5);



            return zip;
        }

    }
}
