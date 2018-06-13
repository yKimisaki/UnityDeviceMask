using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Object = UnityEngine.Object;

namespace Tonari.Unity.UnityDeviceMask
{
    public class UnityDeviceMaskObject : MonoBehaviour
    {
#if UNITY_EDITOR
        private static UnityDeviceMaskObject _instance;

        public Camera Camera;
        public Canvas Canvas;
        public CanvasScaler CanvasScaler;
        public Image MaskImage;

        private void Start()
        {
            // シングルトンとする
            if (_instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            this.Initialize();

            _instance = this;
        }

        public void Initialize()
        {
            if (UnityDeviceMaskSetting.UnityDeviceMaskType == UnityDeviceMaskType.None)
            {
                Destroy(this.gameObject);
                return;
            }

            var sprite = Resources.Load<Sprite>("Textures/" + UnityDeviceMaskSetting.UnityDeviceMaskType.ToString());
            if (sprite == null)
            {
                Debug.unityLogger.LogError("UnityDeviceMask", UnityDeviceMaskSetting.UnityDeviceMaskType.ToString() + "に該当するマスク画像が見つかりませんでした。");
            }

            this.RefreshTag();

            this.gameObject.tag = UnityDeviceMaskSetting.UnityDeviceMaskTag;
            this.gameObject.layer = UnityDeviceMaskSetting.UnityDeviceMaskLayer;

            this.Camera.cullingMask = 1 << UnityDeviceMaskSetting.UnityDeviceMaskLayer;
            this.Camera.depth = UnityDeviceMaskSetting.CanvasSoringOrder;

            this.Canvas.sortingOrder = UnityDeviceMaskSetting.CanvasSoringOrder;
            this.Canvas.gameObject.layer = UnityDeviceMaskSetting.UnityDeviceMaskLayer;

            this.CanvasScaler.referenceResolution = new Vector2(sprite.texture.width, sprite.texture.height);
            this.MaskImage.sprite = sprite;
            this.MaskImage.gameObject.layer = UnityDeviceMaskSetting.UnityDeviceMaskLayer;
        }

        private void RefreshTag()
        {
            var rawAsset = AssetDatabase.LoadAssetAtPath<Object>("ProjectSettings/TagManager.asset");
            if (rawAsset != null)
            {
                var serializedAsset = new SerializedObject(rawAsset);
                var tags = serializedAsset.FindProperty("tags");

                for (var i = 0; i < tags.arraySize; ++i)
                {
                    if (tags.GetArrayElementAtIndex(i).stringValue == UnityDeviceMaskSetting.UnityDeviceMaskTag)
                    {
                        return;
                    }
                }

                var index = tags.arraySize;
                tags.InsertArrayElementAtIndex(index);
                tags.GetArrayElementAtIndex(index).stringValue = UnityDeviceMaskSetting.UnityDeviceMaskTag;
                serializedAsset.ApplyModifiedProperties();
                serializedAsset.Update();
            }
        }
#else
        void Start()
        {
            Destroy(this.gameObject);
        }
#endif
    }
}
