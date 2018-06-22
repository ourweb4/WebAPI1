// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 05-27-2018
//
// Last Modified By : Bill Banks
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="ZipController.cs" company="Ourweb.net">
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
    /// Class ZipController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ZipController : ApiController
    {
        /// <summary>
        /// The database
        /// </summary>
        private Model1 db = new Model1();
        /// <summary>
        /// Gets the zip entities.
        /// </summary>
        /// <returns>IList&lt;StoreEntity&gt;.</returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        public IList<StoreEntity> GetZipEntities()
        {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            IList<StoreEntity> stores;
           return stores;
        }

        /// <summary>
        /// Gets the zip entities.
        /// </summary>
        /// <param name="zip">The zip.</param>
        /// <returns>IQueryable&lt;StoreEntity&gt;.</returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [HttpGet]
        public IList<StoreEntity> GetZipEntities(string zip)
        {
            if (zip  == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            IList<StoreEntity> stores;
            stores = db.StoreEntities.Where(s => s.Zip == zip).ToList<StoreEntity>();
            if (stores == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return stores;
        }

    }
}
