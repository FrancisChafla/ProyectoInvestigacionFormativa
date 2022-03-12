using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investigacion_Formativa
{
    public partial class Form1 : Form
    {
        ListaProductos listaProductos = new ListaProductos();
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var errorProvider = new ErrorProvider();
            if (mtxtNombre.Text == "")
            {
                errorProvider.SetError(mtxtNombre, value: "Debe ingresar un nombre");
            }
            if (cmbArticulo.Text == "")
            {
                errorProvider.SetError(cmbArticulo, value: "Debe seleccionar un producto");
            }
            if (mtxtCodigo.Text == "")
            {
                errorProvider.SetError(mtxtCodigo, value: "Ingrese un codigo");
            }
            if (txtCantidad.Text == "")
            {
                errorProvider.SetError(txtCantidad, value: "Seleccione una cantidad");
            }
            Producto producto = new Producto();
            producto.Nombre = mtxtNombre.Text;
            producto.Articulo = cmbArticulo.Text;        
            try
            {
                producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                producto.Codigo = Convert.ToInt32(mtxtCodigo.Text);
            }
            catch(Exception error)
            {
                MessageBox.Show("Error" + error.Message);
            }
            listaProductos.AgregarProduct(producto);
            LimpiarControl();
            MessageBox.Show("PRODUCTO REGISTRADO");
        }

        private void cmbArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            float precio;
            precio= cmbArticulo.SelectedIndex;
            switch(precio)
            {
                case 0: lblPrecio.Text = "1";break;
                case 1: lblPrecio.Text = "0,30"; break;
                case 2: lblPrecio.Text = "0,40"; break;
                case 3: lblPrecio.Text = "0,75"; break;
                case 4: lblPrecio.Text = "0,65"; break;
                case 5: lblPrecio.Text = "1,5"; break;
                default: lblPrecio.Text = "0,25"; break;
            }
            float codigo;
            codigo = cmbArticulo.SelectedIndex;
            switch (codigo)
            {
                case 0: mtxtCodigo.Text = "1101"; break;
                case 1: mtxtCodigo.Text = "2101"; break;
                case 2: mtxtCodigo.Text = "3101"; break;
                case 3: mtxtCodigo.Text = "4101"; break;
                case 4: mtxtCodigo.Text = "5101"; break;
                case 5: mtxtCodigo.Text = "6101"; break;
                default: mtxtCodigo.Text = "7101"; break;
            }
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = listaProductos.ListProductos;
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dgvPrecio);
            file.Cells[0].Value =(float.Parse(lblPrecio.Text)*float.Parse(txtCantidad.Text)).ToString();
            dgvPrecio.Rows.Add(file);
            lblPrecio.Text = ""; 
            Total();
            LimpiarControles();
        }

        public void Total()
        {
            float costot = 0;
            int cont = 0;
            cont = dgvPrecio.RowCount;
            for(int i=0;i<cont;i++)
            {
                costot += float.Parse(dgvPrecio.Rows[i].Cells[0].Value.ToString());
            }
            lblPagar.Text = costot.ToString();
        }
       
        public void LimpiarControles()
        {
            cmbArticulo.Text = "";
            mtxtCodigo.Text = "";
            txtCantidad.Text = "";
            lblPrecio.Text = "";
        }
        public void LimpiarControl()
        {
            cmbArticulo.Text = "";
            mtxtCodigo.Text = "";
        }
        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblDevolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(lblPagar.Text)).ToString();
            }
            catch
            {

            }
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (float.Parse(txtEfectivo.Text)>= float.Parse(lblPagar.Text))
            {
                MessageBox.Show("SU CAMBIO ES DE: " + lblDevolucion.Text);
                MessageBox.Show("GRACIAS POR SU COMPRA");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("DINERO INSUFICIENTE");
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
            
    }
}
