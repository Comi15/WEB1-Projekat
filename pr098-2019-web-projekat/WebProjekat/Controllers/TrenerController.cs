using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class TrenerController : ApiController
    {

        public IHttpActionResult Post(Trener trener)
        {
            if (trener == null)
            {
                return BadRequest();
            }
            return Ok(Trener.DodajTrenera(trener));
        }
    }
}
