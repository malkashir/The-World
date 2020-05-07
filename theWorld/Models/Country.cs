using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using theWorld.Models;


namespace theWorld.Models
{
    public class Country
    {
        private int id;
        private string continent;
        private string name;
        private string lang;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Continent { get => continent; set => continent = value; }
        public string Lang { get => lang; set => lang = value; }

        public Country(string _name, string _lang, string _continent)
        {
            Name = _name;
            Lang = _lang;
            Continent = _continent;
        }

        public Country() { }

        public List<Country> Read(string name)
        {  
            DBservices dbs = new DBservices();
            return dbs.getCountryDB(name);
        }

        public int updateDB(Country country)
        {
            DBservices dbs = new DBservices(); 
            dbs = dbs.readCountries();
            dbs.dt = CountriesTable(this, dbs.dt);
            dbs.update();
            return 0;
        }

        public DataTable CountriesTable(Country country, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                if (id == country.Id)
                {
                    dr["Lang"] = country.Lang;
                    dr["Continent"] = country.Continent;
                }
            }
            return dt;
        }
        public List<Country> getContinent(string continent)
        {
            DBservices dbs = new DBservices();
            return dbs.getContinentDB(continent);
        }

    }
}