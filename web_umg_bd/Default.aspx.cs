using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_umg_bd
{
    public partial class _Default : Page
    {
        Empleado empleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                empleado = new Empleado();
                empleado.drop_puesto(drop_puesto);
                empleado.grid_empleados(grid_empleados);
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            empleado = new Empleado();
            if (empleado.agregar(txt_codigo.Text,txt_nombres.Text,txt_apellidos.Text,txt_direccion.Text,txt_telefono.Text,txt_fn.Text,Convert.ToInt32(drop_puesto.SelectedValue)) > 0){
                lbl_mensaje.Text = "Ingreso Exitoso";
                empleado.grid_empleados(grid_empleados);

            }
        }

        protected void grid_empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grid_empleados.SelectedValue.ToString();
            //grid_empleados.DataKeys[indice].Values["id"].ToString();
            txt_codigo.Text = grid_empleados.SelectedRow.Cells[2].Text;
            txt_nombres.Text = grid_empleados.SelectedRow.Cells[3].Text;
            txt_apellidos.Text = grid_empleados.SelectedRow.Cells[4].Text;
            txt_direccion.Text = grid_empleados.SelectedRow.Cells[5].Text;
            txt_telefono.Text = grid_empleados.SelectedRow.Cells[6].Text;
            DateTime fecha = Convert.ToDateTime(grid_empleados.SelectedRow.Cells[7].Text);
            txt_fn.Text  = fecha.ToString("yyyy-MM-dd");
            int indice = grid_empleados.SelectedRow.RowIndex;
            drop_puesto.SelectedValue = grid_empleados.DataKeys[indice].Values["id_puesto"].ToString();

            btn_modificar.Visible = true;
        }

        protected void grid_empleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            empleado = new Empleado();
            if (empleado.eliminar( Convert.ToInt32( e.Keys["id"])) > 0){
                lbl_mensaje.Text = "Eliminacion Exitoso...";
                empleado.grid_empleados(grid_empleados);
                btn_modificar.Visible = false;
            }
            
            

        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {


            empleado = new Empleado();
            if (empleado.modificar( Convert.ToInt32(grid_empleados.SelectedValue) ,txt_codigo.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fn.Text, Convert.ToInt32(drop_puesto.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Modifacacion Exitoso...";
                empleado.grid_empleados(grid_empleados);
                btn_modificar.Visible = false;
            }

            

           
            
        }
    }
}