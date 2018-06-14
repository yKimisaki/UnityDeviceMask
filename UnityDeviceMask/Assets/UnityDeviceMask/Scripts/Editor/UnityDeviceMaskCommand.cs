  
  
  
using UnityEditor;

namespace Tonari.Unity.UnityDeviceMask
{
    internal static partial class UnityDeviceMaskCommand
    {
        [MenuItem(CommandParentHierarchy + "None", isValidateFunction: false)]
        public static void SetNone()
        {
            SetMaskTypeCore(UnityDeviceMaskType.None);
            UpdateMask();
        }
        
        [MenuItem(CommandParentHierarchy + "None", isValidateFunction: true)]
        private static bool IsSetNone()
        {
            SetMaskTypeCore(UnityDeviceMaskSetting.UnityDeviceMaskType);
            return true;
        }

        [MenuItem(CommandParentHierarchy + "iPhoneX_Portrait", isValidateFunction: false)]
        public static void SetiPhoneX_Portrait()
        {
            SetMaskTypeCore(UnityDeviceMaskType.iPhoneX_Portrait);
            UpdateMask();
        }
        
        [MenuItem(CommandParentHierarchy + "iPhoneX_Portrait", isValidateFunction: true)]
        private static bool IsSetiPhoneX_Portrait()
        {
            SetMaskTypeCore(UnityDeviceMaskSetting.UnityDeviceMaskType);
            return true;
        }

        [MenuItem(CommandParentHierarchy + "iPhone5_Portrait_Relative", isValidateFunction: false)]
        public static void SetiPhone5_Portrait_Relative()
        {
            SetMaskTypeCore(UnityDeviceMaskType.iPhone5_Portrait_Relative);
            UpdateMask();
        }
        
        [MenuItem(CommandParentHierarchy + "iPhone5_Portrait_Relative", isValidateFunction: true)]
        private static bool IsSetiPhone5_Portrait_Relative()
        {
            SetMaskTypeCore(UnityDeviceMaskSetting.UnityDeviceMaskType);
            return true;
        }

    }
}