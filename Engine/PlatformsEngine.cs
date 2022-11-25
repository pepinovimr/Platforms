using Platforms.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Platforms.Engine
{
    internal abstract class PlatformsEngine
    {
        protected Form _window;
        protected Thread _gameLoopThread;
        public Color _backgroundColor = Color.White;
        private Stopwatch _stopwatch = new Stopwatch();
        private readonly TimeSpan refreshTime;

        public static List<GameObject> AllObjects = new List<GameObject>();

        public PlatformsEngine(Form window, double targetFPS = 120)
        {
            double time = 1 / (targetFPS /1000 );
            refreshTime = new TimeSpan(0,0,0,0,(int)time);

            _window = window;
            _window.Paint += Renderer;

            _gameLoopThread = new Thread(GameLoop);
            _gameLoopThread.Start();
        }

        public static void AddNewObject(GameObject newGameObject)
        {
            AllObjects.Add(newGameObject);
        }

        public static void RemoveObject(GameObject gameObject)
        {
            AllObjects.Add(gameObject);
        }

        public void GameLoop()
        {
            OnLoad();
            while (_gameLoopThread.IsAlive && !_window.IsHandleCreated)
            {
                _stopwatch.Restart();
                OnDraw();
                _window.BeginInvoke((MethodInvoker)delegate
                {
                    _window.Refresh();
                });
                OnUpdate();
                _stopwatch.Stop();
                Thread.Sleep(refreshTime - _stopwatch.Elapsed);
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(_backgroundColor);

            foreach (GameObject o in AllObjects)
            {
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
    }
}
