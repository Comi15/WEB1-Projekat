using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class FitnesCentar
    {
        int id;
        string naziv;
        string adresa;
        int godinaOtvaranja;
        Vlasnik vlasnik = new Vlasnik();
        int mesecnaClanarina;
        int godisnjaClanarina;
        int cenaJednogTreninga;
        int cenaJednogGrupnogTreninga;
        int cenaJednogTreningaSaPersonalnimTrenerom;
        public static List<FitnesCentar> CenterList { get; set; } = new List<FitnesCentar>();

        public FitnesCentar(string naziv, string adresa, int godinaOtvaranja, Vlasnik vlasnik, int mesecnaClanarina, int godisnjaClanarina, int cenaJednogTreninga, int cenaJednogGrupnogTreninga, int cenaJednogTreningaSaPersonalnimTrenerom)
        {
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.GodinaOtvaranja = godinaOtvaranja;
            this.Vlasnik = vlasnik;
            this.MesecnaClanarina = mesecnaClanarina;
            this.GodisnjaClanarina = godisnjaClanarina;
            this.CenaJednogTreninga = cenaJednogTreninga;
            this.CenaJednogGrupnogTreninga = cenaJednogGrupnogTreninga;
            this.CenaJednogTreningaSaPersonalnimTrenerom = cenaJednogTreningaSaPersonalnimTrenerom;
        }
        public FitnesCentar()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public int GodinaOtvaranja { get => godinaOtvaranja; set => godinaOtvaranja = value; }
        public Vlasnik Vlasnik { get => vlasnik; set => vlasnik = value; }
        public int MesecnaClanarina { get => mesecnaClanarina; set => mesecnaClanarina = value; }
        public int GodisnjaClanarina { get => godisnjaClanarina; set => godisnjaClanarina = value; }
        public int CenaJednogTreninga { get => cenaJednogTreninga; set => cenaJednogTreninga = value; }
        public int CenaJednogGrupnogTreninga { get => cenaJednogGrupnogTreninga; set => cenaJednogGrupnogTreninga = value; }
        public int CenaJednogTreningaSaPersonalnimTrenerom { get => cenaJednogTreningaSaPersonalnimTrenerom; set => cenaJednogTreningaSaPersonalnimTrenerom = value; }
        

        public static List<FitnesCentar> ReadFromJsonCenters()
        {
            string _path = "..\\..\\Users\\Korisnik\\Desktop\\Projekat Web\\pr098-2019-web-projekat\\FajloviJson\\Centri.json";
            string jsonFromFile;

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            List<FitnesCentar> centri = JsonConvert.DeserializeObject<List<FitnesCentar>>(jsonFromFile);

            foreach (var item in centri)
            {
                CenterList.Add(item);
            }

            return centri;
        }

    }
}