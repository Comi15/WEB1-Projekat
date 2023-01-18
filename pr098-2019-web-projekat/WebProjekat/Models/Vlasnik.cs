using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Vlasnik:Korisnik
    {
        
        public int Id { get; set; }
        

        public Vlasnik()
        {
            this.uloga = Uloga.VLASNIK;
            this.Id = Math.Abs(Guid.NewGuid().GetHashCode());
            
        }

        public override Korisnik DodajKorisnika(Posetilac posetilac)
        {
            throw new NotImplementedException();
        }
    }
}