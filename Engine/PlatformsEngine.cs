using Platforms.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;

namespace Platforms.Engine
{
    /// <summary>
    /// Provides 
    /// </summary>
    internal abstract class PlatformsEngine
    {
        protected Form _window;
        protected Camera _camera;
        protected Thread _gameLoopThread;
        /// <summary>
        /// Background color of game
        /// </summary>
        public Color _backgroundColor = Color.White;
        private Stopwatch _stopwatch = new Stopwatch();
        private readonly TimeSpan refreshTime;

        /// <summary>
        /// List with all GameObjects
        /// </summary>
        public static List<GameObject> AllObjects = new List<GameObject>();
        /// <summary>
        /// Position of Camera
        /// </summary>
        //public Vector2 CameraPosition = Vector2.Zero;
        //Might need camera angle in future

        public PlatformsEngine(Form window, double targetFPS = 120)
        {
            double time = 1 / (targetFPS /1000 );
            refreshTime = new TimeSpan(0,0,0,0,(int)time);

            _camera = new Camera(window.Size);
            _window = window;
            _window.Paint += Renderer;

            _window.KeyDown += WindowKeyDown;
            _window.KeyUp += WindowKeyUp;

            _gameLoopThread = new Thread(GameLoop);
            _gameLoopThread.Start();
        }

        private void WindowKeyUp(object? sender, KeyEventArgs e)
        {
            KeyUpEvent(e);
        }

        private void WindowKeyDown(object? sender, KeyEventArgs e)
        {
            KeyDownEvent(e);
        }

        /// <summary>
        /// Adds new GameObject to list
        /// </summary>
        /// <param name="newGameObject"></param>
        public static void AddNewObject(GameObject newGameObject)
        {
            //Don't add player if one already exists
            if (newGameObject.GetType() == typeof(PlayerObject) && AllObjects.Any(x => x.GetType() == typeof(PlayerObject)))
                return;

            AllObjects.Add(newGameObject);
        }

        /// <summary>
        /// Removes GameObject from list
        /// </summary>
        /// <param name="gameObject"></param>
        public static void RemoveObject(GameObject gameObject)
        {
            AllObjects.Remove(gameObject);
        }

        /// <summary>
        /// Loop - loads all at first, then draws and updates everything as defined by OnDraw and OnUpdate methods
        /// </summary>
        public void GameLoop()
        {
            OnLoad();
            while (_gameLoopThread.IsAlive)
            {
                _stopwatch.Restart();
                OnDraw();
                _window.BeginInvoke((MethodInvoker)delegate
                {
                    _window.Refresh();
                });
                OnUpdate();
                _stopwatch.Stop();
                if(_stopwatch.Elapsed < refreshTime)
                    Thread.Sleep(refreshTime - _stopwatch.Elapsed);


                if (!_window.IsHandleCreated)
                    break;
            }
        }

        /// <summary>
        /// Clears background and renders all objects
        /// </summary>
        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(_backgroundColor);

            g.TranslateTransform(_camera.CameraPosition.X, _camera.CameraPosition.Y);

            foreach (GameObject o in AllObjects)
            {
                if (o.Sprite != null)
                    g.DrawImage(o.Sprite, o.Position.X, o.Position.Y, o.Size.X, o.Size.Y);
                else
                    g.FillRectangle(new SolidBrush(Color.Red), o.Position.X, o.Position.Y, o.Size.X, o.Size.Y);
            }
        }

        /// <summary>
        /// Gets called once - before game loop starts
        /// </summary>
        public abstract void OnLoad();

        /// <summary>
        /// Calls anything regarding Moving, physics etc..
        /// </summary>
        public abstract void OnUpdate();

        /// <summary>
        /// Calls anything regarding drawing
        /// </summary>
        public abstract void OnDraw();
        /// <summary>
        /// Handles key up event
        /// </summary>
        public abstract void KeyDownEvent(KeyEventArgs e);
        /// <summary>
        /// Handles key down event
        /// </summary>
        public abstract void KeyUpEvent(KeyEventArgs e);
    }
}
