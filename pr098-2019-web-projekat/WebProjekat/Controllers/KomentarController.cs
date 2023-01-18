using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class KomentarController : ApiController
    {
        public List<Komentar> Get()
        {

            return Komentar.ReadFromJsonKomentar();
        }

        public IHttpActionResult Post(Komentar komentar)
        {
            if (komentar == null)
            {
                return BadRequest();
            }
            return Ok(Komentar.DodajKomentar(komentar));
        }

    }
}
