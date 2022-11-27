using Platforms.Engine;
using Platforms.Engine.Objects;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Platforms
{
    internal class Game : PlatformsEngine
    {
        PlayerObject player;
        public Game(Form window) : base(window)
        {
        }


        public override void OnLoad()
        {
            Dictionary<string, Image> dict = ResourceHelper.getImages(@"C:\Users\uzivatel 1\Desktop\C# Projekty\Platforms\Resources\Rogue");
            player = new PlayerObject(new Vector2(10, 10), new Vector2(100, 100), dict["rogue"]);
        }

        public override void OnDraw()
        {
            
        }

        public override void OnUpdate()
        {
            player.Speed = .5f;
            player.Position.X += player.Speed;
        }
    }
}
