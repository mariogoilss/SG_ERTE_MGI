﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_ERTE_MGI
{
    public partial class frmEmpresas : Form
    {
        /*
         * FUNCIONES
         */

        private void mostrarEmpresas()
        {
            using (bd_ertesEntities objBD = new bd_ertesEntities())
            {
                var consultaEmpresas = from soc in objBD.EMPRESAS
                                       orderby soc.Nombre
                                       select new { soc.Nombre, soc.Sector, soc.Cif };

                var lista = consultaEmpresas.ToList();
                dgvEmpresas.DataSource = lista;
            }
        }

        private void accionModificar()
        {

            if (dgvEmpresas.SelectedRows.Count > 0)
            {
                frmModificarAux form = new frmModificarAux(dgvEmpresas.SelectedRows[0].Cells[2].Value.ToString());
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada");
            }

        }

        /*
         * FUNCIONES DEL FORM
         */
        public frmEmpresas()
        {
            InitializeComponent();
        }

        
        //ONLOAD
        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            mostrarEmpresas();
        }

        


        private void btnModificar_Click(object sender, EventArgs e)
        {
            accionModificar();
        }

        

        private void dgvEmpresas_DoubleClick(object sender, EventArgs e)
        {
            accionModificar();
        }
    }
}
