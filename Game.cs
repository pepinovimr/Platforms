using Platforms.Engine;
using Platforms.Engine.Objects;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using System.IO;
using System;

namespace Platforms
{
    internal class Game : PlatformsEngine
    {
        PlayerObject player;
        string resourcesDir = Directory.GetCurrentDirectory() + @"\Resources\";
        int scaleOfMap = 25;
        MapCreator creator = new MapCreator();
        Dictionary<string, Image> PlayerDictionary = new Dictionary<string, Image>();
        Dictionary<string, Image> TileDictionary = new Dictionary<string, Image>();
        public Dictionary<Color, Tuple<Type, Image>> ColorTypeDictionary = new Dictionary<Color, Tuple<Type, Image>>();
        Bitmap level1;
        public Game(Form window) : base(window)
        {
        }


        public override void OnLoad()
        {
            FillDictionaries();

            creator.CreateMapByColor(ColorTypeDictionary, level1, scaleOfMap);

            player = new PlayerObject(new Vector2(10, 10), new Vector2(100, 100), PlayerDictionary["rogue"]);
        }
        public override void OnDraw()
        {
            
        }

        public override void OnUpdate()
        {
            //player.Speed = .5f;
            //player.Position.X += player.Speed;
        }

        private void FillDictionaries()
        {
            PlayerDictionary = ResourceHelper.GetSprites(resourcesDir + "Rogue");
            TileDictionary = ResourceHelper.GetSprites(resourcesDir + "Tiles");
            level1 = ResourceHelper.GetMap(resourcesDir + @"Map\MapTest.png");
            ColorTypeDictionary = FillColorDictionary();
        }

        private Dictionary<Color, Tuple<Type, Image>> FillColorDictionary()
        {
            return new Dictionary<Color, Tuple<Type, Image>>()
            {
                [Color.FromArgb(0,0,0)] = new Tuple<Type, Image>(typeof(TerrainObject), TileDictionary["tile46"])
            };
        }
    }
}
