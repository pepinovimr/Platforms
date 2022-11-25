using Platforms.Engine;
using Platforms.Engine.Objects;
using System.Numerics;
using System.Windows.Forms;

namespace Platforms
{
    internal class Game : PlatformsEngine
    {
        public Game(Form window) : base(window)
        {
        }


        public override void OnLoad()
        {
            PlayerObject player = new PlayerObject(new Vector2(10, 10), new Vector2(10, 10));
        }

        public override void OnDraw()
        {
        }

        public override void OnUpdate()
        {
        }
    }
}
