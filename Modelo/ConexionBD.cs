using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
namespace web_umg_bd
{
    public class ConexionBD
    {
        private string contenido = "server=localhost; database=db_empresa; user=usr_empresa; password=Empres@123";
        public MySqlConnection conectar = new MySqlConnection();
        public MySqlDataAdapter adaptador = new MySqlDataAdapter();

        public void AbrirConexion(){
            try {
                string sConn;
                sConn = contenido;
                conectar = new MySqlConnection();
                conectar.ConnectionString = sConn;
                conectar.Open();
               // System.Diagnostics.Debug.WriteLine("Conexion Exitosa");
               
            } 
            catch(Exception ex){
                System.Diagnostics.Debug.WriteLine(ex.Message);
               // Console.WriteLine(ex.StackTrace);
                
            }

        }
        public void CerarConexion(){
            
                if (conectar.State == ConnectionState.Open){
                conectar.Close();            }

        }
    }
}