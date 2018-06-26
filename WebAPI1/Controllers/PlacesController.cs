// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 06-26-2018
//
// Last Modified By : Bill Banks
// Last Modified On : 06-26-2018
// ***********************************************************************
// <copyright file="PlacesController.cs" company="Ourweb.net">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using GoogleMapsAPI.NET.API.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    /// <summary>
    /// Class PlacesController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class PlacesController : ApiController
    {
        /// <summary>
        /// The googlekey
        /// </summary>
        public const string GOOGLEKEY = "AIzaSyABff2oLcuHsYrLgZa5mzeqANO3aeaSf3M";


        /// <summary>
        /// Gets the place.
        /// </summary>
        /// <param name="zip">The zip.</param>
        /// <returns>Places.</returns>
        [HttpGet]
        public Places GetPlace(string zip)
        {
            Places places = new Places();
            places.Zipcode = zip;
            var client = new MapsAPIClient(GOOGLEKEY);
            var addressx = zip;

            var geocodeResult = client.Geocoding.Geocode(addressx);
            places.Latitude= geocodeResult.Results[0].Geometry.Location.Latitude;
            places.Longitude= geocodeResult.Results[0].Geometry.Location.Longitude;
            places.PlaceID = geocodeResult.Results[0].PlaceId;
            return places;
        }
    }
}
