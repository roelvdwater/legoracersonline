using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string title, string message, Exception exc)
        {
            InitializeComponent();

            Text = title;
            tabError.Text = title;
            lblMessage.Text = message;
            lblExceptionDetailsValue.Text = exc.Message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}