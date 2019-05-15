using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int i = 1;
        int j = 1;
        String aux = "";
        string imgPath;
        List<Producto> catalogo = new List<Producto>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //  lv propiedades
            listView1.View = View.Details;

            //construir columnas
            listView1.Columns.Add("Frutas",150);
         
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            txtbCod.Text = j.ToString();
        }

        //poblar lv
        private void populate()
        {
            //inicializar un imagelist con el tama;o que tendra cada imagen
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(150, 150);
            imgs.ColorDepth = ColorDepth.Depth32Bit;

            
            try
            {
                foreach (Producto p in catalogo)
                {
                    imgs.Images.Add(Image.FromFile(p.IMGpath));//cargar imagenes desde el path
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            foreach (Producto p in catalogo)
            {
                listView1.SmallImageList = imgs;
                listView1.Items.Add(p.ToString(), p.codigo-1);

            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
            
        {
            //Producto p = new Producto(34, "Brocoli", "Verdura", 12.63, 34, @"D:\Tomas\Pictures\Frutas\Naranja.jpg");
            //String selected = listView1.SelectedItems[0].SubItems[0].Text;

            //listView1.SelectedItems[0].SubItems[0].Text = p.ToString();
           // listView1.SelectedItems[0].;
           //lb1.Text = listView1.SelectedItems[0].Index.ToString();

           //i++;
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            populate();
         
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
             listView1.Items.Clear();
        }

        private void btnIMG_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    imgPath = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(imgPath);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            Producto p1 = new Producto();
            
            
           j++;
            p1.codigo = Convert.ToInt32(txtbCod.Text);
            p1.nombre = txtbNom.Text;
            p1.descripcion = txtbDesc.Text;
            p1.precio = Convert.ToDouble(txtbPrecio.Text);
            p1.stock = Convert.ToInt32(txtbStock.Text);
            p1.IMGpath = imgPath;
            catalogo.Add(p1);
            txtbCod.Text = j.ToString();
            //lb1.Text = catalogo.First().ToString()+ Environment.NewLine+p1.IMGpath;
            listView1.Items.Clear();
            populate();
            
        }
    }
}
