using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    public class ZipRadiusController : ApiController
    {
        private Model1 db = new Model1();
        private const string ZIPAPIKEY = "haHmbNrE9Gg3G8EqqrqTvXSsXp7BGEn4u84Bz4MLqA7VqlVPBLjij0ezIVm5f9Wf";
        private const string ZIPURL = "https://www.zipcodeapi.com/rest/" + ZIPAPIKEY + "/radius.json/";
    }
}
