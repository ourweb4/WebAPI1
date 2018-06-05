// ***********************************************************************
// Assembly         : WebAPI1
// Author           : Bill Banks
// Created          : 11-30-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 11-30-2017
// ***********************************************************************
// <copyright file="AuthFilter.cs" company="Ourweb.net">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Text;
using System.Data.Entity;
//using System.Linq;
using WebAPI1.Models;

namespace WebAPI1
{
    /// <summary>
    /// Class AuthFilter.
    /// </summary>
    /// <seealso cref="System.Web.Http.Filters.ActionFilterAttribute" />
    public class AuthFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;
                string dtoken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string username = dtoken.Substring(0, dtoken.IndexOf("|"));
                string password = dtoken.Substring(dtoken.IndexOf("|") + 1);

                using (var db = new Model1())
                {
                   var  masterrec = db.MasterEntities.Where(m => m.Username == username)
                        .Where(m => m.Password == password)
                        .Where(m => m.Active);
                    if (masterrec == null)
                    {
                        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

                    }
                }                
            }
        }
    }
}