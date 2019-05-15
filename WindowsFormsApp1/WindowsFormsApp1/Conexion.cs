using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Conexion
    {
        static string CadenaConexion;
        static OleDbConnection Conex;
        static OleDbDataAdapter Adaptador;
        static OleDbCommandBuilder Constructor;
        static DataTable Tabla;
        static BindingSource Fuente;

        public BindingSource Source
        {
            get
            {
                return Fuente;
            }
        }
        public void Conectar()
        {
            CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Tomas\Documents\Programacion\Progra 3\1er parcial\Base de datos\Nueva carpeta\colchones2003.mdb;Persist Security Info=False";
            Conex = new OleDbConnection(CadenaConexion);
            Conex.Open();
        }
        public void Desconectar()
        {
            Conex.Close();
        }

        public void ConsultarProd()
        {


            string Consulta = "select*  from PRODUCTOS; ";
            Adaptador = new OleDbDataAdapter(Consulta, Conex);
            Constructor = new OleDbCommandBuilder(Adaptador);
            Tabla = new DataTable("PRODUCTOS");
            Adaptador.Fill(Tabla);
            Fuente = new BindingSource();
            Fuente.DataSource = Tabla;

        }
        public void guardarProd(string campo1, string campo2, string campo3, string campo4)

        {
            int codMueble = Convert.ToInt32(campo1);
            string nombmueble = campo2;
            string materialmueble = campo3;
            string dimensiones = campo4;


            try
            {

                string insertar = "INSERT INTO PRODUCTOS VALUES ('" + codMueble + "','" + nombmueble + "','" + materialmueble + "','" + dimensiones + "')";
                OleDbCommand cmd = new OleDbCommand(insertar, Conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro guardado");



            }

            catch (DBConcurrencyException ex)
            {
                MessageBox.Show("Error de concurrencia:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
