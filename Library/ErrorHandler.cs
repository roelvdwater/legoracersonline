using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ErrorHandler
    {
        public static void ShowDialog(string title, string message, Exception exc)
        {
            using (ErrorForm errorForm = new ErrorForm(title, message, exc))
            {
                errorForm.ShowDialog();
            }
        }
    }
}