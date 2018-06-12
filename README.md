# UnityDeviceMask
iPhone Xとかのアールをエディタ上で検証したい

# 配置

UnityDeviceMaskというPrefabがあるので、それをシーンに配置するだけです。

![image](https://user-images.githubusercontent.com/1702680/41279931-b34291e4-6e68-11e8-8947-f733d1b8e814.png)

![image](https://user-images.githubusercontent.com/1702680/41279965-c75e94c0-6e68-11e8-97fa-d524a9965721.png)

# デバイスの追加とその他の編集

UnityDeviceMaskSettingsに一通りあります。
UnityDeviceMaskTypeを追加すると、デバイスが増えます。
enumに追加した値と同じ名前の画像をResources/Texturesに追加すると、その画像を読み込んで使います。

# 通しで見たい

UnityDeviceMaskというPrefabがあるので、アプリケーション起動時の初期化処理とかでResources.Loadで読み込んで、DontDestroyOnLoadしましょう。
