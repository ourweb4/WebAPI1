// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 11-30-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 05-29-2018
// ***********************************************************************
// <copyright file="StoresController.cs" company="Ourweb.net">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI1.Models;
using GoogleMapsAPI.NET;
using GoogleMapsAPI.NET.API.Client;

namespace WebAPI1.Controllers
{

    /// <summary>
    /// Class StoresController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class StoresController : ApiController
{
        /// <summary>
        /// The googlekey
        /// </summary>
        public const string GOOGLEKEY = "AIzaSyABff2oLcuHsYrLgZa5mzeqANO3aeaSf3M";
        /// <summary>
        /// The database
        /// </summary>
        private Model1 db = new Model1();

        // GET: api/Stores
        /// <summary>
        /// Gets the store entities.
        /// </summary>
        /// <returns>IQueryable&lt;StoreEntity&gt;.</returns>
        public IQueryable<StoreEntity> GetStoreEntities()
        {
            return db.StoreEntities;
        }

        // GET: api/Stores/5
        /// <summary>
        /// Gets the store entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(StoreEntity))]
        public IHttpActionResult GetStoreEntity(int id)
        {
            StoreEntity storeEntity = db.StoreEntities.Find(id);
            if (storeEntity == null)
            {
                return NotFound();
            }

            return Ok(storeEntity);
        }

        // PUT: api/Stores/5
        /// <summary>
        /// Puts the store entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="storeEntity">The store entity.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStoreEntity(int id, StoreEntity storeEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storeEntity.StoreId)
            {
                return BadRequest();
            }
            storeEntity = GetLoc(storeEntity);

            db.Entry(storeEntity).State = EntityState.Modified;

            try
            {

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Stores
        /// <summary>
        /// Posts the store entity.
        /// </summary>
        /// <param name="storeEntity">The store entity.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(StoreEntity))]
        public IHttpActionResult PostStoreEntity(StoreEntity storeEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            storeEntity = GetLoc(storeEntity);
            storeEntity =  db.StoreEntities.Add(storeEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = storeEntity.StoreId }, storeEntity);
        }

        // DELETE: api/Stores/5
        /// <summary>
        /// Deletes the store entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(StoreEntity))]
        public IHttpActionResult DeleteStoreEntity(int id)
        {
            StoreEntity storeEntity = db.StoreEntities.Find(id);
            if (storeEntity == null)
            {
                return NotFound();
            }

            db.StoreEntities.Remove(storeEntity);
            db.SaveChanges();

            return Ok(storeEntity);
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Stores the entity exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool StoreEntityExists(int id)
        {
            return db.StoreEntities.Count(e => e.StoreId == id) > 0;
        }

        /// <summary>
        /// Gets the loc.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns>StoreEntity.</returns>
        private StoreEntity GetLoc(StoreEntity store)
    {
        var client = new MapsAPIClient(GOOGLEKEY);
        var addressx = store.Address + ", " + store.City + ", " + store.State;

        var geocodeResult = client.Geocoding.Geocode(addressx);
        store.Lat = geocodeResult.Results[0].Geometry.Location.Latitude;
        store.Lng = geocodeResult.Results[0].Geometry.Location.Longitude;

            return store;
    }
    }
}