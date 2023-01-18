using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class KorisnikController : ApiController
    {

        
        public IHttpActionResult Post(Posetilac posetilac)
        {
            if (posetilac == null)
            {
                return BadRequest();
            }
            return Ok(posetilac.DodajKorisnika(posetilac));
        }

        public List<Korisnik> Get()
        {

            return Korisnik.ReadFromJsonKorisnik();
        }

        [HttpPut]
        public IHttpActionResult Put(Posetilac p)
        {
            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\Korisnici.json";
            string _path2 = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\GrupniTreninzi.json";

            if (p == null)
            {
                return BadRequest();
            }

            List<Korisnik> korisnici = Korisnik.ReadFromJsonKorisnik();

            foreach(var korisnik in korisnici)
            {
                if(p.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    korisnik.PrijavljeniTreninziId = p.PrijavljeniTreninziId;
                    break;
                }
            }

            var jsonToWrite = JsonConvert.SerializeObject(korisnici, Formatting.Indented);


            using (var writer = new StreamWriter(_path))
            {
                writer.Write(jsonToWrite);
            }

            List<GrupniTrening> grupniTreninzi = GrupniTrening.ReadFromJsonTrening();

            foreach(var tr in grupniTreninzi)
            {
               foreach(var id in p.PrijavljeniTreninziId)
                {
                    if(tr.Id == id)
                    {
                        tr.Posetioci.Add(p);
                        break;
                    }
                }
            }

            var jsonToWriteTr = JsonConvert.SerializeObject(grupniTreninzi, Formatting.Indented);


            using (var writer = new StreamWriter(_path2))
            {
                writer.Write(jsonToWriteTr);
            }



            return Ok(p);
        }





    }
}
