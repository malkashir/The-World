using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using theWorld.Models;


public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {   
    }

    public SqlConnection connect(String conString) 
    {
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con) 
    {
        SqlCommand cmd = new SqlCommand(); 
        cmd.Connection = con;              
        cmd.CommandText = CommandSTR;    
        cmd.CommandTimeout = 10;        
        cmd.CommandType = System.Data.CommandType.Text; 
        return cmd;
    }
    public List<Country> getCountryDB(string name)
    {
        List<Country> listCountry = new List<Country>();
        SqlConnection con = null; 
        try
        {   
            con = connect("DBConnectionString_Shir"); 
            String selectSTR = "SELECT * FROM Countries_shir WHERE Name LIKE '%" + name + "%'";           
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Country country = new Country();
                country.Id = Convert.ToInt32(dr["Id"]);
                country.Continent = (string)dr["Continent"];
                country.Name = (string)dr["Name"];
                country.Lang = (string)dr["Lang"];
                listCountry.Add(country);
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return listCountry;
    }

    public DBservices readCountries()
    {
        SqlConnection con = null;
        try
        { 
            con = connect("DBConnectionString_Shir");
            da = new SqlDataAdapter("SELECT * FROM Countries_shir", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return this;
    }

    public void update()
    {
        da.Update(dt);
    }

    public List<Country> getContinentDB(string continent)
    {       
        List<Country> listCountry = new List<Country>();
        SqlConnection con = null;
        try
        {  
            con = connect("DBConnectionString_Shir"); 

            String selectSTR = "SELECT * FROM Countries_shir WHERE Continent LIKE '%" + continent + "%'";
           
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Country country = new Country();

                country.Id = Convert.ToInt32(dr["Id"]);
                country.Continent = (string)dr["Continent"];
                country.Name = (string)dr["Name"];
                country.Lang = (string)dr["Lang"];

                listCountry.Add(country);
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return listCountry;
    }
}
