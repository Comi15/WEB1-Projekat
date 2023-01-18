using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class GrupniTrening
    {
        int id;
        Trener trener = new Trener();
        string naziv;
        string tipTreninga;
        FitnesCentar centar = new FitnesCentar();
        int trajanjeTreninga;
        DateTime datumIVremeTreninga;
        int maxBrojPosetilaca;
        List<Posetilac> posetioci = new List<Posetilac>();

        

        public GrupniTrening()
        {
            Id = Math.Abs(Guid.NewGuid().GetHashCode());
            trener = new Trener();
        }


        public Trener Trener { get => trener; set => trener = value; }
        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string TipTreninga { get => tipTreninga; set => tipTreninga = value; }
        public FitnesCentar Centar { get => centar; set => centar = value; }
        public int TrajanjeTreninga { get => trajanjeTreninga; set => trajanjeTreninga = value; }
        public DateTime DatumIVremeTreninga { get => datumIVremeTreninga; set => datumIVremeTreninga = value; }
        public int MaxBrojPosetilaca { get => maxBrojPosetilaca; set => maxBrojPosetilaca = value; }
        public List<Posetilac> Posetioci { get => posetioci; set => posetioci = value; }
        

        public static List<GrupniTrening> ReadFromJsonTrening()
        {
            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\GrupniTreninzi.json";
            string jsonFromFile;

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            List<GrupniTrening> treninzi = JsonConvert.DeserializeObject<List<GrupniTrening>>(jsonFromFile);

            
            return treninzi;
        }

        public static GrupniTrening DodajTrening(GrupniTrening trening)
        {

            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\GrupniTreninzi.json";
            string jsonFromFile;

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            trening.Id = Math.Abs(Guid.NewGuid().GetHashCode());
            trening.Posetioci = new List<Posetilac>();

            List<GrupniTrening> treninzi = JsonConvert.DeserializeObject<List<GrupniTrening>>(jsonFromFile);

            treninzi.Add(trening);

            var jsonToWrite = JsonConvert.SerializeObject(treninzi, Formatting.Indented);


            using (var writer = new StreamWriter(_path))
            {
                writer.Write(jsonToWrite);
            }


            return trening;
        }

    }
}