using System;
using System.Collections.Generic;
using System.Diagnostics;
using M120Projekt.Data;

namespace M120Projekt
{
    static class API
    {
        public static void createProduct(string name, DateTime datum, bool anLager, decimal preis, string versandart)
        {
            Produkt produkt = new Produkt();
            produkt.ProduktName = name;
            produkt.Erscheinungsdatum = datum;
            produkt.AnLager = anLager;
            produkt.Preis = preis;
            produkt.Versandart = versandart;
            Int64 produktId = produkt.Erstellen();
        }

        public static List<Produkt> readProduct()
        {
            var produktListe = new List<Produkt>();
            foreach (Produkt produkt in Produkt.LesenAlle())
            {
                produktListe.Add(produkt);
            }
            return produktListe;
        }

        public static void updateProdukt(long id, string name, DateTime datum, bool anLager, decimal preis, string versandart)
        {
            Produkt produkt = Produkt.LesenID(id);
            produkt.ProduktName = name;
            produkt.Erscheinungsdatum = datum;
            produkt.AnLager = anLager;
            produkt.Preis = preis;
            produkt.Versandart = versandart;
            produkt.Aktualisieren();
        }

        public static void deleteProduct(long id)
        {
            Produkt.LesenID(id).Loeschen();
        }
    }
}
