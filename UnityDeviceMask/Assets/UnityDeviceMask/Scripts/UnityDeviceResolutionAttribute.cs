using System;

namespace Tonari.Unity.UnityDeviceMask
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class UnityDeviceResolutionAttribute : Attribute
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public UnityDeviceResolutionAttribute(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
