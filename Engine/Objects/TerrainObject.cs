
using System.Drawing;
using System.Numerics;

namespace Platforms.Engine.Objects
{
    /// <summary>
    /// Default preset for terrain - walls, ground etc.
    /// </summary>
    internal class TerrainObject : GameObject
    {

        public TerrainObject(Vector2 position, Vector2 size, Image? image) : base(position, size, image)
        {

        }
    }
}
