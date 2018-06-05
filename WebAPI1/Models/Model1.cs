// ***********************************************************************
// Assembly         : WebAPI1
// Created          : 11-25-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 11-28-2017// Author           : Bill Banks

// ***********************************************************************
// <copyright file="Model1.cs" company="Ourweb.net">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace WebAPI1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Class Model1.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebAPI1.Models.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        /// <summary>
        /// Initializes a new instance of the <see cref="Model1"/> class.
        /// </summary>
        public Model1()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on
        /// Gets or sets the stor configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        /// <summary>e entities.
        /// </summary>
        /// <value>The store entities.</value>
        public virtual DbSet<StoreEntity> StoreEntities { get; set; }
        /// <summary>
        /// Gets or sets the master entities.
        /// </summary>
        /// <value>The master entities.</value>
        public virtual DbSet<MadterEntity> MasterEntities { get; set; }

    }

    /// <summary>
    /// Class MadterEntity.
    /// </summary>
    public class MadterEntity
    {
        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>The master identifier.</value>
        [Key]
        public int MasterId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public string Zip { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show website].
        /// </summary>
        /// <value><c>true</c> if [show website]; otherwise, <c>false</c>.</value>
        public bool ShowWebsite { get; set; }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show email].
        /// </summary>
        /// <value><c>true</c> if [show email]; otherwise, <c>false</c>.</value>
        public bool ShowEmail { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MadterEntity"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the stores.
        /// </summary>
        /// <value>The stores.</value>
        public List<StoreEntity> Stores { get; set; }
    }
    /// <summary>
    /// Class StoreEntity.
    /// </summary>
    public class StoreEntity
    {
        /// <summary>
        /// Gets or sets the store identifier.
        /// </summary>
        /// <value>The store identifier.</value>
        [Key]
       public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the masterid.
        /// </summary>
        /// <value>The masterid.</value>
   //     public int Masterid { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public string Zip { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show website].
        /// </summary>
        /// <value><c>true</c> if [show website]; otherwise, <c>false</c>.</value>
        public bool ShowWebsite { get; set; }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show email].
        /// </summary>
        /// <value><c>true</c> if [show email]; otherwise, <c>false</c>.</value>
        public bool ShowEmail { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the sun.
        /// </summary>
        /// <value>The sun.</value>
        public string Sun { get; set; }

        /// <summary>
        /// Gets or sets the mon.
        /// </summary>
        /// <value>The mon.</value>
        public string Mon { get; set; }
        /// <summary>
        /// Gets or sets the tue.
        /// </summary>
        /// <value>The tue.</value>
        public string Tue { get; set; }
        /// <summary>
        /// Gets or sets the wed.
        /// </summary>
        /// <value>The wed.</value>
        public string Wed  { get; set; }
        /// <summary>
        /// Gets or sets the thu.
        /// </summary>
        /// <value>The thu.</value>
        public string Thu  { get; set; }
        /// <summary>
        /// Gets or sets the fri.
        /// </summary>
        /// <value>The fri.</value>
        public string Fri { get; set; }
        /// <summary>
        /// Gets or sets the sat.
        /// </summary>
        /// <value>The sat.</value>
        public string Sat { get; set; }
        //geoloc
        public double  Lat { get; set; }
        public double   Lng { get; set; }



    }
}