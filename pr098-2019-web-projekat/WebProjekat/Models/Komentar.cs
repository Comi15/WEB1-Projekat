using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Komentar
    {
        Posetilac posetilac = new Posetilac();
        FitnesCentar fitnesCentar = new FitnesCentar();
        string textKomentara;
        int ocena;

        public Komentar()
        {
           
        }

        public Posetilac Posetilac { get => posetilac; set => posetilac = value; }
        public FitnesCentar FitnesCentar { get => fitnesCentar; set => fitnesCentar = value; }
        public string TextKomentara { get => textKomentara; set => textKomentara = value; }
        public int Ocena { get => ocena; set => ocena = value; }

        public static List<Komentar> ReadFromJsonKomentar()
        {
            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\Komentari.json";
            string jsonFromFile;

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            List<Komentar> komentari = JsonConvert.DeserializeObject<List<Komentar>>(jsonFromFile);


            return komentari;
        }

        public static Komentar DodajKomentar (Komentar komentar)
        {

            string _path = $"C:\\Users\\milov\\OneDrive\\Desktop\\WebGitLabRepo\\pr098-2019-web-projekat\\FajloviJson\\Komentari.json";
            string jsonFromFile;

            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            List<Komentar> komentari = JsonConvert.DeserializeObject<List<Komentar>>(jsonFromFile);

            komentari.Add(komentar);

            var jsonToWrite = JsonConvert.SerializeObject(komentari, Formatting.Indented);


            using (var writer = new StreamWriter(_path))
            {
                writer.Write(jsonToWrite);
            }



            return komentar;
        }
    }
}