  
  
  
using System;
using UnityEditor;
using Object = UnityEngine.Object;

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

            // お掃除
            foreach (var gabage in Object.FindObjectsOfType<UnityDeviceMaskObject>())
            {
                Object.DestroyImmediate(gabage.gameObject);
            }

            if (maskType == UnityDeviceMaskType.None)
            {
                return;
            }
            
            // 生成
            var instance = Object.Instantiate(UnityEngine.Resources.Load<UnityDeviceMaskObject>("UnityDeviceMask"));
            instance.Initialize();
        }
    }
}