using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Trener:Korisnik
    {
        public List<GrupniTrening> DrziTreninge { get; set; } = new List<GrupniTrening>();
        public FitnesCentar AngazovanUFitnesCentru { get; set; } = new FitnesCentar();

        

        public Trener()
        {
            this.uloga = Uloga.TRENER;

        }

        public override Korisnik DodajKorisnika(Posetilac posetilac)
        {
            throw new NotImplementedException();
        }

        public static Korisnik DodajTrenera(Trener trener)
        {
            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\Korisnici.json";
            string jsonFromFile;


            JsonConverter[] converters = { new KorisnikConverter() };

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(jsonFromFile, new JsonSerializerSettings() { Converters = converters });

            trener.Uloga = Uloga.TRENER;
            trener.Id = Math.Abs(Guid.NewGuid().GetHashCode());
            trener.DrziTreninge = new List<GrupniTrening>();
            //trener.AngazovanUFitnesCentru = new FitnesCentar();

            Korisnici.Add(trener);

            var jsonToWrite = JsonConvert.SerializeObject(Korisnici, Formatting.Indented);


            using (var writer = new StreamWriter(_path))
            {
                writer.Write(jsonToWrite);
            }

            return trener;
        }
    }
}