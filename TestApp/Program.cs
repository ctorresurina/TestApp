using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BEBuilder;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            using (OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["TestApp.Properties.Settings.testConnectionString"].ConnectionString))
            { 
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuarios";
                BusinesEntityBuilder<UsuarioBE> be = new BusinesEntityBuilder<UsuarioBE>();
                try{
                    con.Open();
                    var listaUsuarios = be.ConstructList(cmd.ExecuteReader());
                }catch(Exception exp){
                    Console.Write(exp.Message);
                }finally{
                    con.Close();
                }
            }
            
        }
    }
}
