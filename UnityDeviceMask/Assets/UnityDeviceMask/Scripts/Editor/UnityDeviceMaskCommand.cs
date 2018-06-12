  
  
  
using System;
using UnityEditor;

namespace Tonari.Unity.UnityDeviceMask
{
    internal static class UnityDeviceMaskCommand
    {
        private const string CommandParentHierarchy = "Tonari/UnityDeviceMask/";

        [MenuItem(CommandParentHierarchy + "None", isValidateFunction: false)]
        public static void SetNone()
        {
            SetMaskTypeCore(UnityDeviceMaskType.None);
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
        }
		
        [MenuItem(CommandParentHierarchy + "iPhoneX_Portrait", isValidateFunction: true)]
        private static bool IsSetiPhoneX_Portrait()
        {
            SetMaskTypeCore(UnityDeviceMaskSetting.UnityDeviceMaskType);
			return true;
        }


        private static void SetMaskTypeCore(UnityDeviceMaskType maskType)
        {
            foreach(UnityDeviceMaskType value in Enum.GetValues(typeof(UnityDeviceMaskType)))
            {
                if (value != maskType)
                {
                    Menu.SetChecked(CommandParentHierarchy + value.ToString(), false);
                    continue;
                }

                Menu.SetChecked(CommandParentHierarchy + value.ToString(), true);
                UnityDeviceMaskSetting.UnityDeviceMaskType = value;
            }
        }
    }
}