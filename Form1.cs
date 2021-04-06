using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string nombre = txtNombre.Text;
                string apellidoPaterno = txtApellidoPa.Text;
                string apellidoMaterno = txtApellidoMa.Text;
                string telefono = txtTelefono.Text;
                string correo = txtCorreo.Text;
                string semestre = txtSemestre.Text;
                


                if (nombre != "" && apellidoPaterno != "" && apellidoMaterno != "" && telefono != "" && correo != "" && semestre != "")
                {



                    string sql = "INSERT INTO alumndual (ID_Alumn, Nombre,Apellido_P, Apellido_M, Telefono,Correo,Semestre) VALUES ('" + id + "', '" + nombre + "','" + apellidoPaterno + "','" + apellidoMaterno + "','" + telefono + "','" + correo + "','" + semestre + "') ";

                    //traemos la conexion haciendo una instancia
                    MySqlConnection conexionBD = conexion.Conexion();
                    //abrimos la conexion
                    conexionBD.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Regristro guardado");
                        limpiar();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                    finally
                    {
                        conexionBD.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }

            }
            catch (FormatException fex)
            {
                MessageBox.Show("Error al guardar: " + fex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }


        private void limpiar()
        {
            txtId.Text ="";
            txtNombre.Text = "";
            txtApellidoPa.Text = "";
            txtApellidoMa.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtSemestre.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoPa.Text;
            string apellidoMaterno = txtApellidoMa.Text;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string semestre = txtSemestre.Text;



            string sql = "UPDATE alumndual SET Nombre = '" + nombre + "',Apellido_P = '" + apellidoPaterno + "', Apellido_M = '" + apellidoMaterno + "', Telefono= '" + telefono + "',Correo = '" + correo + "',Semestre= '" + semestre + "' WHERE ID_Alumn= '" + id + "'";


            //traemos la conexion haciendo una instancia
            MySqlConnection conexionBD = conexion.Conexion();
            //abrimos la conexion
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Regristro Modificado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modfiicar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;

            MySqlDataReader reader = null;

            string sql = "SELECT ID_Alumn, Nombre,Apellido_P, Apellido_M, Telefono,Correo,Semestre FROM alumndual WHERE ID_Alumn LIKE '" + Id + "'  LIMIT 1";
            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        txtId.Text = reader.GetString(0);
                        txtNombre.Text = reader.GetString(1);
                        txtApellidoPa.Text = reader.GetString(2);
                        txtApellidoMa.Text = reader.GetString(3);
                        txtTelefono.Text = reader.GetString(4);
                        txtCorreo.Text = reader.GetString(5);
                        txtSemestre.Text = reader.GetString(6);
           
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;


            string sql = "DELETE FROM alumndual WHERE ID_Alumn='" + id + "'";

            //traemos la conexion haciendo una instancia
            MySqlConnection conexionBD = conexion.Conexion();
            //abrimos la conexion
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Regristro Eliminado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Eliminado: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}
