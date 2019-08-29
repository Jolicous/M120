using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA
            Data.Produkt produkt1 = new Data.Produkt();
            produkt1.ProduktName = "Artikel 13";
            produkt1.Erscheinungsdatum = DateTime.Today;
            produkt1.AnLager = true;
            produkt1.Preis = 21;
            Int64 produkt1ID = produkt1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + produkt1ID);
        }
        public static void DemoACreateKurz()
        {
            Data.Produkt produkt2 = new Data.Produkt { ProduktName = "Artikel 2", AnLager = true, Erscheinungsdatum = DateTime.Today, Preis = 21};
            Int64 produkt2ID = produkt2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + produkt2ID);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Produkt klasseA in Data.Produkt.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.ProduktID + " Name:" + klasseA.ProduktName);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.Produkt produkt1 = Data.Produkt.LesenID(1);
            produkt1.ProduktName = "Artikel 1 nach Update";
            produkt1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            //Data.Produkt.LesenID(2).Loeschen();
            Debug.Print("Artikel mit Id 2 gelöscht");
        }
        #endregion
    }
}
