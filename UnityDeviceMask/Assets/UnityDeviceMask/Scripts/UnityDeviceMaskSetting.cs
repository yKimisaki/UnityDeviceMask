#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Tonari.Unity.UnityDeviceMask
{
    public enum UnityDeviceMaskType
    {
        None,

        [GameViewSize(GameViewSizeType.FixedResolution, 1125, 2436)]
        iPhoneX_Portrait,

        [GameViewSize(GameViewSizeType.AspectRatio, 9, 16)]
        iPhone5_Portrait_Relative,
    }

    public static class UnityDeviceMaskSetting
    {
        public const string UnityDeviceMaskSetting_Key = "UnityDeviceMaskSetting";

        public const int UnityDeviceMaskLayer = 30;
        public const int CanvasSoringOrder = (int)short.MaxValue;

        public static UnityDeviceMaskType UnityDeviceMaskType
        {
            get
            {
#if UNITY_EDITOR
                return (UnityDeviceMaskType)EditorPrefs.GetInt(UnityDeviceMaskSetting_Key);
#else
                return UnityDeviceMaskType.None;
#endif
            }
            set
            {
#if UNITY_EDITOR
                EditorPrefs.SetInt(UnityDeviceMaskSetting_Key, (int)value);
#endif
            }
        }
    }
}