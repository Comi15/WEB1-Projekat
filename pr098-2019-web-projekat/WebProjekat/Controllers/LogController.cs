using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class LogController : ApiController
    {
        
        
        public IHttpActionResult Post(LoginParams item)
        {

            if(item == null)
            {
                return BadRequest();
            }
            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\Korisnici.json";
            string jsonFromFile;


            JsonConverter[] converters = { new KorisnikConverter() };

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

           List<Korisnik> Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(jsonFromFile, new JsonSerializerSettings() { Converters = converters });



            Korisnik korisnikSlanje;
            foreach (var korisnik in Korisnici)
            {               
                if(item.LogUsername == korisnik.KorisnickoIme && item.LogPassword == korisnik.Lozinka)
                {
                    Console.WriteLine("Usao u prvi if");
                    
                    if(korisnik.Uloga == Uloga.POSETILAC)
                    {
                        Console.WriteLine("Usao u posetilac if");
                        HttpContext.Current.Session["korisnik"] = (Posetilac)korisnik;
                        korisnikSlanje = (Posetilac)korisnik;
                        return Ok(korisnikSlanje);
                    }

                    else if (korisnik.Uloga == Uloga.TRENER)
                    {
                        HttpContext.Current.Session["korisnik"] = (Trener)korisnik;
                        korisnikSlanje = (Trener)korisnik;
                        return Ok(korisnikSlanje);

                    }

                    else if(korisnik.Uloga == Uloga.VLASNIK)
                    {
                        HttpContext.Current.Session["korisnik"] = (Vlasnik)korisnik;
                        korisnikSlanje = (Vlasnik)korisnik;
                        return Ok(korisnikSlanje);

                    }


                }
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Posetilac p)
        {
            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\Korisnici.json";

            List<Korisnik> korisnici = Korisnik.ReadFromJsonKorisnik();

            foreach (var korisnik in korisnici)
            {
                if (p.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    korisnik.KorisnickoIme = p.KorisnickoIme;
                    korisnik.Lozinka = p.Lozinka;
                    korisnik.Ime = p.Ime;
                    korisnik.Prezime = p.Prezime;
                    korisnik.Email = p.Email;
                    korisnik.Pol = p.Pol;
                    korisnik.DatumRodjenja = p.DatumRodjenja;
                    break;
                }
            }

            var jsonToWrite = JsonConvert.SerializeObject(korisnici, Formatting.Indented);


            using (var writer = new StreamWriter(_path))
            {
                writer.Write(jsonToWrite);
            }




            if (p == null)
            {
                return BadRequest();
            }
            
            return Ok(p);
        }
    }
}
