using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class Produkt
    {
        #region Datenbankschicht
        [Key]
        public Int64 ProduktID { get; set; }
        [Required]
        public String ProduktName { get; set; }
        [Required]
        public DateTime Erscheinungsdatum { get; set; }
        [Required]
        public Boolean AnLager { get; set; }
        [Required]
        public Decimal Preis { get; set; }
        [Required]
        public string Versandart { get; set; }
        #endregion

        #region Applikationsschicht
        public static List<Produkt> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA select record).ToList();
            }
        }
        public static Produkt LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.ProduktID == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<Produkt> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.ProduktName == suchbegriff select record).ToList();
            }
        }
        public static List<Produkt> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.ProduktName.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.ProduktName == null || this.ProduktName == "") this.ProduktName = "leer";
            if (this.Erscheinungsdatum == null) this.Erscheinungsdatum = DateTime.MinValue;
            using (var db = new Context())
            {
                db.KlasseA.Add(this);
                db.SaveChanges();
                return this.ProduktID;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.ProduktID;
            }
        }
        public void Loeschen()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return ProduktID.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}