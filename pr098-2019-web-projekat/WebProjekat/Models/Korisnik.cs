using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public enum Uloga
    {
        POSETILAC,
        TRENER,
        VLASNIK

    }

    abstract public class Korisnik
    {
        private int id;
        protected string korisnickoIme;
        protected string lozinka;
        protected string ime;
        protected string prezime;
        protected char pol;
        protected string email;
        protected DateTime datumRodjenja;
        protected Uloga uloga;

        public static List<Korisnik> Korisnici { get; set; } = new List<Korisnik>();
        public List<int> PrijavljeniTreninziId { get; set; } = new List<int>();
        public List<int> FitnesCentriId { get; set; } = new List<int>();

        

        public Korisnik()
        {

        }


        public int Id { get => id; set => id = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public char Pol { get => pol; set => pol = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public Uloga Uloga { get => uloga; set => uloga = value; }
        

        public abstract Korisnik DodajKorisnika(Posetilac posetilac);

        public static List<Korisnik> ReadFromJsonKorisnik()
        {
            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\Korisnici.json";
            string jsonFromFile;


            JsonConverter[] converters = { new KorisnikConverter() };

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            List<Korisnik> getKorisnici = JsonConvert.DeserializeObject<List<Korisnik>>(jsonFromFile, new JsonSerializerSettings() { Converters = converters });
            return getKorisnici;

        }


    }
}