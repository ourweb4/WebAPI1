// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 06-20-2018
//
// Last Modified By : Bill Banks
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="ZipRadiusController.cs" company="Ourweb.net">
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
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    /// <summary>
    /// Class ZipRadiusController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ZipRadiusController : ApiController
    {
        /// <summary>
        /// The database
        /// </summary>
        private Model1 db = new Model1();
        /// <summary>
        /// The zipapikey
        /// </summary>
        private const string ZIPAPIKEY = "haHmbNrE9Gg3G8EqqrqTvXSsXp7BGEn4u84Bz4MLqA7VqlVPBLjij0ezIVm5f9Wf";
        /// <summary>
        /// The zipurl
        /// </summary>
        private const string ZIPURL = "https://www.zipcodeapi.com/rest/" + ZIPAPIKEY + "/radius.json/";

        /// <summary>
        /// get zip codes as an asynchronous operation.
        /// </summary>
        /// <param name="zip">The zip.</param>
        /// <param name="Distance">The distance.</param>
        /// <returns>System.Threading.Tasks.Task&lt;IList&lt;ZipCodes&gt;&gt;.</returns>
        [HttpGet]
        public async System.Threading.Tasks.Task<IList<ZipCodes>> GetZipCodesAsync(string zip, int Distance)
        {
             HttpClient client = new HttpClient();
            Zips zips = new Zips();

            string geturl = ZIPURL + zip + "/" + Distance.ToString() + "/miles";
            HttpResponseMessage response = await  client.GetAsync(geturl);
            if (response.IsSuccessStatusCode)
            {
                zips = await response.Content.ReadAsAsync<Zips>();
            }

            return zips.ZipCodes;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IList<ZipCodes>> GetZipCodesAsync(string zip)
        {
            HttpClient client = new HttpClient();
            int Distance = 5;
            Zips zips = new Zips();

            string geturl = ZIPURL + zip + "/" + Distance.ToString() + "/miles";
            HttpResponseMessage response = await client.GetAsync(geturl);
            if (response.IsSuccessStatusCode)
            {
                zips = await response.Content.ReadAsAsync<Zips>();
            }

            return zips.ZipCodes;
        }

    }
}
