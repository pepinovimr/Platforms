using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platforms
{
    public partial class GameUI : Form
    {
        public GameUI()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //redraws into second buffer, prevents filcker
        }
    }
}
