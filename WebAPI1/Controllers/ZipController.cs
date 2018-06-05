using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    public class ZipController : ApiController
    {
        private Model1 db = new Model1();
        /// <summary>
        /// Gets the zip entities.
        /// </summary>
        /// <param name="zip">The zip.</param>
        /// <returns>IQueryable&lt;StoreEntity&gt;.</returns>
        public IQueryable<StoreEntity> GetZipEntities(string zip) => db.StoreEntities.Where(s => s.Zip == zip);
    }
}
