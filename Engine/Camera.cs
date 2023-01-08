using Platforms.Engine.Enums;
using Platforms.Engine.Objects;
using System.Drawing;
using System.Numerics;

namespace Platforms.Engine
{
    internal class Camera
    {
        /// <summary>
        /// The location of camera (Offset into the world)
        /// </summary>
        public Vector2 Offset;

        /// <summary>
        /// Bitmap used to "draw" the view of camera
        /// </summary>
        public Bitmap CameraScreen;
        public CameraStates cameraState = CameraStates.StayingIdle;

        public Vector2 CameraPosition { get; set; }
        /// <summary>
        /// Basic camera
        /// </summary>
        public Camera(Size resolution) 
        { 
            CameraScreen = new Bitmap(resolution.Width, resolution.Height);
        }
        /// <summary>
        /// Camera with offset from the beggining
        /// </summary>
        /// <param name="offset">Offset of camera</param>
        public Camera(Size resolution, Vector2 offset)
        {
            CameraScreen = new Bitmap(resolution.Width, resolution.Height);
            Offset = offset;
        }

        public void MoveCameraToLocation(Vector2 newLocation)
        {
            cameraState = CameraStates.MovingToPosition;
            CameraPosition = newLocation;
        }
        /// <summary>
        /// Folows targeted GameObject
        /// </summary>
        /// <param name="target">Targeted GameObject</param>
        public void Folow(GameObject target)
        {
            cameraState = CameraStates.FollowingObject;
            CameraPosition = new Vector2(CameraScreen.Width / 2, CameraScreen.Height / 2) - target.Position;
        }
        /// <summary>
        /// Folows targeted GameObject
        /// </summary>
        /// <param name="target">Targeted GameObject</param>
        /// <param name="width">Width of screen</param>
        /// <param name="height">Height of screen</param>
        public void Folow(GameObject target, int width, int height)
        {
            cameraState = CameraStates.FollowingObject;
            CameraPosition = target.Position - new Vector2(width / 2, height / 2);
        }

    }
}
