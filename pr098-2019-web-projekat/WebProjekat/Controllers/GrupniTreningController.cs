using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class GrupniTreningController : ApiController
    {
        public List<GrupniTrening> Get()
        {

            return GrupniTrening.ReadFromJsonTrening();
        }

        public IHttpActionResult Post(GrupniTrening trening)
        {
            if (trening == null)
            {
                return BadRequest();
            }
            return Ok(GrupniTrening.DodajTrening(trening));
        }


    }
}
