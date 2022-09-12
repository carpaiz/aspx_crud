using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace web_umg_bd
{
    public class Empleado
    {
        ConexionBD conectar;
        private DataTable drop_puesto(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select id_puesto as id,puesto from puestos;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void drop_puesto(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige Puesto >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_puesto();
            drop.DataTextField = "puesto";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        private DataTable grid_empleados() {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            String consulta = string.Format("select e.id_empleado as id,e.codigo,e.nombres,e.apellidos,e.direccion,e.telefono,e.fecha_nacimiento,p.puesto,p.id_puesto from empleados as e inner join puestos as p on e.id_puesto = p.id_puesto;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void grid_empleados(GridView grid){
            grid.DataSource = grid_empleados();
            grid.DataBind();

        }
        public int agregar(string codigo,string nombres,string apellidos,string direccion,string telefono,string fecha,int id_puesto){
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("insert into empleados(codigo,nombres,apellidos,direccion,telefono,fecha_nacimiento,id_puesto) values('{0}','{1}','{2}','{3}','{4}','{5}',{6});",codigo,nombres,apellidos,direccion,telefono,fecha,id_puesto);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            
            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
        public int modificar(int id,string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto){
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("update empleados set codigo = '{0}',nombres = '{1}',apellidos = '{2}',direccion='{3}',telefono='{4}',fecha_nacimiento='{5}',id_puesto = {6} where id_empleado = {7};", codigo, nombres, apellidos, direccion, telefono, fecha, id_puesto,id);
            MySqlCommand modificar = new MySqlCommand(strConsulta, conectar.conectar);

            modificar.Connection = conectar.conectar;
            no_ingreso = modificar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }
        public int eliminar(int id){
            int no_ingreso = 0;
        conectar = new ConexionBD();
        conectar.AbrirConexion();
            string strConsulta = string.Format("delete from empleados  where id_empleado = {0};", id);
        MySqlCommand eliminar = new MySqlCommand(strConsulta, conectar.conectar);

            eliminar.Connection = conectar.conectar;
            no_ingreso = eliminar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }

}
}