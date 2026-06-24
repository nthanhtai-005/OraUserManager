using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Interfaces;

namespace GUI.Views
{
    public partial class frmMain : Form, IMainView
    {
        public frmMain()
        {
            InitializeComponent();
        }
    }
}
