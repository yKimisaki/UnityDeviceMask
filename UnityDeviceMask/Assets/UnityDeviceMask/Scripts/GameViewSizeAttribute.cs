using System;

namespace Tonari.Unity.UnityDeviceMask
{
    public enum GameViewSizeType
    {
        AspectRatio = 0,
        FixedResolution = 1,
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GameViewSizeAttribute : Attribute
    {
        public GameViewSizeType GameViewSizeType { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public GameViewSizeAttribute(GameViewSizeType gameViewSizeType, int width, int height)
        {
            this.GameViewSizeType = gameViewSizeType;
            this.Width = width;
            this.Height = height;
        }
    }
}
