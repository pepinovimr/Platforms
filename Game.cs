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
    /// <summary>
    /// Main game class with dependent objects and methods
    /// </summary>
    internal class Game : PlatformsEngine
    {
        PlayerObject player;
        readonly string resourcesDir = Directory.GetCurrentDirectory() + @"\Resources\";
        int scaleOfMap = 48;
        Dictionary<string, Image> PlayerDictionary = new Dictionary<string, Image>();
        Dictionary<string, Image> TileDictionary = new Dictionary<string, Image>();
        public Dictionary<Color, Tuple<Type, Image>> ColorTypeDictionary = new Dictionary<Color, Tuple<Type, Image>>();
        Bitmap level1;

        private Vector2 lastPos = Vector2.Zero;
        private float playerMoveX = 2f;
        private float playerMoveY = 2f;
        bool up;
        bool down;
        bool left;
        bool right;

        public Game(Form window) : base(window)
        {
        }


        public override void OnLoad()
        {
            FillDictionaries();
            MapCreator.CreateMapByColor(ColorTypeDictionary, level1, scaleOfMap);

            player = new PlayerObject(new Vector2(10, 10), new Vector2(46, 51), PlayerDictionary["rogue"]);

        }
        public override void OnDraw()
        {
            
        }

        public override void OnUpdate()
        {
            PlayerMovement();
            _camera.Folow(player);
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

        private void PlayerMovement()
        {
            if (player.IsColiding())
                player.Position = lastPos;
            else
                lastPos = player.Position;

            if (right)
            {
                player.Position.X += playerMoveX;
                _camera.MoveCameraToLocation(new Vector2(0, 0));
                return;
            }
            if (up)
            {
                player.Position.Y -= playerMoveY;
                return;
            }
            if (left)
            {
                player.Position.X -= playerMoveX;
                return;
            }
            if (down)
            {
                player.Position.Y += playerMoveY;
                return;
            }
        }



        public override void KeyDownEvent(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                right = true;
                return;
            }

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                up = true;
                return;
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                left = true;
                return;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                down = true;
                return;
            }
        }

        public override void KeyUpEvent(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                right = false;
                return;
            }

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                up = false;
                return;
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                left = false;
                return;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                down = false;
                return;
            }
        }
    }
}
