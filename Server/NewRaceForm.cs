using LEGORacersAPI;
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class NewRaceForm : Form
    {
        public Circuit SelectedCircuit { get; set; }

        public bool Mirror { get; set; }

        public NewRaceForm()
        {
            InitializeComponent();

            cmbCircuit.DataSource = Circuit.GetAll();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SelectedCircuit = (Circuit)cmbCircuit.SelectedValue;
            Mirror = chkMirror.Checked;

            Close();
        }
    }
}