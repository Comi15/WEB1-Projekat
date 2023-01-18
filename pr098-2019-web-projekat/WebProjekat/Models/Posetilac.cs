using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebProjekat.Models
{
    public class Posetilac : Korisnik
    {
        
        public int Id { get; set;}
        
        
        public Posetilac()
        {
            this.uloga = Uloga.POSETILAC;
            this.Id = Math.Abs(Guid.NewGuid().GetHashCode());
        }

        public override Korisnik DodajKorisnika(Posetilac posetilac)
        {
             
            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\Korisnici.json";
            string jsonFromFile;


            JsonConverter[] converters = { new KorisnikConverter() };

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(jsonFromFile, new JsonSerializerSettings() { Converters = converters });
            
            posetilac.Uloga = Uloga.POSETILAC;
            posetilac.Id = Math.Abs(Guid.NewGuid().GetHashCode());
            posetilac.PrijavljeniTreninziId = new List<int>();

            Korisnici.Add(posetilac);

            var jsonToWrite = JsonConvert.SerializeObject(Korisnici, Formatting.Indented);

            
            using (var writer = new StreamWriter(_path))
            {
                writer.Write(jsonToWrite);
            }

            return posetilac;
        }
    }
}