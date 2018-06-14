  
  
  
using System;
using System.Reflection;
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
            Cleaning();
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
            Cleaning();
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
            Cleaning();
        }
        
        [MenuItem(CommandParentHierarchy + "iPhone5_Portrait_Relative", isValidateFunction: true)]
        private static bool IsSetiPhone5_Portrait_Relative()
        {
            SetMaskTypeCore(UnityDeviceMaskSetting.UnityDeviceMaskType);
            return true;
        }


        private static void SetMaskTypeCore(UnityDeviceMaskType maskType)
        {
            foreach (UnityDeviceMaskType value in Enum.GetValues(typeof(UnityDeviceMaskType)))
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

        private static void Cleaning()
        {
            var maskType = UnityDeviceMaskSetting.UnityDeviceMaskType;

            // お掃除
            foreach (var gabage in Object.FindObjectsOfType<UnityDeviceMaskObject>())
            {
                Object.DestroyImmediate(gabage.gameObject);
            }

            if (maskType == UnityDeviceMaskType.None)
            {
                return;
            }

            // GameViewSizeAttributeが設定されてたらGameViewに親切に設定
            var memberInfos = typeof(UnityDeviceMaskType).GetMember(maskType.ToString());
            var resolutionAttributes = memberInfos[0].GetCustomAttributes(typeof(GameViewSizeAttribute), false);
            if (resolutionAttributes.Length != 0)
            {
                var resolutionAttribute = (GameViewSizeAttribute)resolutionAttributes[0];

                var gameViewSizes = typeof(Editor).Assembly.GetType("UnityEditor.GameViewSizes");
                var scriptableSingleton = typeof(ScriptableSingleton<>).MakeGenericType(gameViewSizes);
                var getGroup = gameViewSizes.GetMethod("GetGroup");
                var scriptableSingletonInstance = scriptableSingleton.GetProperty("instance");
                var gameViewSizesInstance = scriptableSingletonInstance.GetValue(null, null);
                var group = getGroup.Invoke(gameViewSizesInstance, new object[] { 0 /* = Standalone */});

                // サイズがあるか検索
                var getTotalCount = group.GetType().GetMethod("GetTotalCount");
                var totalCount = (int)getTotalCount.Invoke(group, new object[0]);
                var getCustomCount = group.GetType().GetMethod("GetCustomCount");
                var customCount = (int)getCustomCount.Invoke(group, new object[0]);
                var index = (int?)null;
                for (int i = 0; i < totalCount; ++i)
                {
                    var getTargetGameViewSize = group.GetType().GetMethod("GetGameViewSize");
                    var targetGameViewSize = getTargetGameViewSize.Invoke(group, new object[] { i });
					var baseText = (string)targetGameViewSize.GetType().GetProperty("baseText").GetValue(targetGameViewSize, new object[0]);
                    if (baseText == maskType.ToString())
                    {
                        index = i;
                    }
                }

                if (!index.HasValue)
                {
                    // サイズを追加
                    var addCustomSize = getGroup.ReturnType.GetMethod("AddCustomSize");
                    var gameViewSize = typeof(Editor).Assembly.GetType("UnityEditor.GameViewSize");
                    var constructor = gameViewSize.GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int), typeof(string) });
                    var newSize = constructor.Invoke(new object[] { (int)resolutionAttribute.GameViewSizeType, resolutionAttribute.Width, resolutionAttribute.Height, maskType.ToString() });
                    addCustomSize.Invoke(group, new object[] { newSize });
                }

                // 設定した解像度をGameViewに反映
                var gameView = typeof(Editor).Assembly.GetType("UnityEditor.GameView");
                var gameViewWindow = EditorWindow.GetWindow(gameView);
                var setSize = gameView.GetMethod("SizeSelectionCallback",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                setSize.Invoke(gameViewWindow, new object[] { index.HasValue ? index.Value : totalCount /* 最後に追加してるのでtotalCount-1+1ということ */, null });
            }

            // 生成
            var instance = Object.Instantiate(UnityEngine.Resources.Load<UnityDeviceMaskObject>("UnityDeviceMask"));
            instance.Initialize();
        }
    }
}