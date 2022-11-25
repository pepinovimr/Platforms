using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Platforms
{
    public partial class GameUI : Form
    {
        private Game game;
        public GameUI()
        {
            InitializeComponent();

            DoubleBuffered = true;     //redraws into second buffer, prevents filckering

            game = new Game(this)
            {
                _backgroundColor = Color.LightGray
            };
        }
    }
}
