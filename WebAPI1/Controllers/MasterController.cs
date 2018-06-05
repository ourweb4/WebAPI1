// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 12-02-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 12-02-2017
// ***********************************************************************
// <copyright file="MasterController.cs" company="Ourweb.net">
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

namespace WebAPI1.Controllers
{
    /// <summary>
    /// Class MasterController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class MasterController : ApiController
    {
        /// <summary>
        /// The database
        /// </summary>
        private Model1 db = new Model1();

        // GET: api/Master
        /// <summary>
        /// Gets the master entities.
        /// </summary>
        /// <returns>IQueryable&lt;MadterEntity&gt;.</returns>
        public IQueryable<MadterEntity> GetMasterEntities()
        {
            return db.MasterEntities;
        }

        // GET: api/Master/5
        /// <summary>
        /// Gets the madter entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(MadterEntity))]
        public IHttpActionResult GetMadterEntity(int id)
        {
            MadterEntity madterEntity = db.MasterEntities.Find(id);
            if (madterEntity == null)
            {
                return NotFound();
            }

            return Ok(madterEntity);
        }


        /// <summary>
        /// Gets the madter account.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="password">The password.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(MadterEntity))]
        public IHttpActionResult GetMadterAccount(string  userid, string password)
        {
            var masterrec = db.MasterEntities.Where(m => m.Username == userid)
                         .Where(m => m.Password == password)
                         .Where(m => m.Active);
            if (masterrec == null)
            {
                return NotFound();
            }

            return Ok(masterrec);
        }

        // PUT: api/Master/5
        /// <summary>
        /// Puts the madter entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="madterEntity">The madter entity.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMadterEntity(int id, MadterEntity madterEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != madterEntity.MasterId)
            {
                return BadRequest();
            }

            db.Entry(madterEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MadterEntityExists(id))
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

        // POST: api/Master
        /// <summary>
        /// Posts the madter entity.
        /// </summary>
        /// <param name="madterEntity">The madter entity.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(MadterEntity))]
        public IHttpActionResult PostMadterEntity(MadterEntity madterEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MasterEntities.Add(madterEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = madterEntity.MasterId }, madterEntity);
        }

        // DELETE: api/Master/5
        /// <summary>
        /// Deletes the madter entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(MadterEntity))]
        public IHttpActionResult DeleteMadterEntity(int id)
        {
            MadterEntity madterEntity = db.MasterEntities.Find(id);
            if (madterEntity == null)
            {
                return NotFound();
            }

            db.MasterEntities.Remove(madterEntity);
            db.SaveChanges();

            return Ok(madterEntity);
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
        /// Madters the entity exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool MadterEntityExists(int id)
        {
            return db.MasterEntities.Count(e => e.MasterId == id) > 0;
        }
    }
}