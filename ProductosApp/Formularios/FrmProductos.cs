using AppCore.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infraestructure.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Formularios
{
    public partial class FrmProductos : Form
    {
        private IProductoService service;
        private ProductoModel model;
        public FrmProductos(IProductoService service)
        {
            this.service = service;
            model = new ProductoModel();
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.Items.AddRange(Enum.GetValues(typeof(UnidadMedida))
                                              .Cast<object>()
                                              .ToArray()
                                          );

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.PModel = service;
            frmProducto.ShowDialog();

            rtbProductView.Text = service.GetProductosAsJson();
        }

        private void CmbFinderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFinderType.SelectedIndex)
            {
                case 0:
                    txtFinder.Visible = true;
                    cmbMeasureUnit.Visible = false;
                    break;
                case 3:
                    cmbMeasureUnit.Visible = true;
                    txtFinder.Visible = false;
                    break;                
            }
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            string mostrar="";
            Producto[] productos = model.Ordenar(service.FindAll());
            foreach (Producto p in productos)
            {
                mostrar = $@" Id: {p.Id}{Environment.NewLine} Nombre: {p.Nombre}{Environment.NewLine}
Descripcion: {p.Descripcion}{Environment.NewLine} Existencias: {p.Existencia}{Environment.NewLine}
Precio: {p.Precio}{Environment.NewLine} Fecha de vencimiento: {p.FechaVencimiento}{Environment.NewLine}
Unidad de medida: {p.UnidadMedida}{Environment.NewLine}{Environment.NewLine}" + mostrar;
            }
            rtbProductView.Text = mostrar;
        }
    }
}
