﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Events.GebruikerBeheer
{
    class GebruikerBeheer
    {
        Database.Database Database = new Database.Database();
        public void Inloggen(string gebruikersnaam, string wachtwoord)
        {

        }
        
        //Hier wordt een gebruiker geregistreerd.
        //Zijn gegegevens worden toegevoegd aan de Database.
        public void Registreren(string email, string naam, string wachtwoord, int aanwezig, string admin)
        {
            string sqlGebruiker = "INSERT INTO GEBRUIKER(Gebruikersnaam, Naam, Wachtwoord,  Aanwezig, AdminCheck) VALUES('" + email + "','" + naam + "','" + wachtwoord + "','" + Convert.ToString(aanwezig) + "','" + admin + "')";
            if (admin == "Ja")
            {  
                string sqlAdmin = "INSERT INTO ADMIN(Gebruikergebruikersnaam) VALUES('" + email + "')";
                if (Database.Insert(sqlGebruiker) == true)
                {
                    Database.Insert(sqlAdmin);
                    MessageBox.Show("Admin is toegevoegd.");
                }
            }
            else
            {
                string sqlGast = "INSERT INTO GAST(Gebruikergebruikersnaam) VALUES('" + email + "')";
                if (Database.Insert(sqlGebruiker) == true)
                {
                    Database.Insert(sqlGast);
                    MessageBox.Show("Gast is toegevoegd.");
                }
            }
        }

        public List<Gebruiker> LijstAanwezigen(bool aanwezig)
        {
            string sql;
            if(aanwezig == true)
            {
                sql = "SELECT * FROM GEBRUIKER WHERE AANWEZIG = 1";
            }
            else
            {
                sql = "SELECT * FROM GEBRUIKER WHERE AANWEZIG = 0";
            }
            List<Gebruiker> Gebruikers = new List<Gebruiker>();
            Gebruikers = Database.GetGebruikerList(sql);
            return Gebruikers;
        }

        public Gebruiker GebruikerOpvragen(string email)
        {
            string sql = "SELECT * FROM GEBRUIKER WHERE GEBRUIKERSNAAM = '" + email + "'";
            List<Gebruiker> Gebruikers = new List<Gebruiker>();
            Gebruiker Eengebruiker;
            Gebruikers = Database.GetGebruikerList(sql);
            foreach(Gebruiker Temp in Gebruikers)
            {
                Eengebruiker = Temp;
                return Eengebruiker;
            }
            return null;
        }
    }
}
