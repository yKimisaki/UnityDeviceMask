# UnityDeviceMask
iPhone Xとかのアールをエディタ上で検証したい

# 配置

UnityDeviceMaskというPrefabがあるので、それをシーンに配置するだけです。

![image](https://user-images.githubusercontent.com/1702680/41279931-b34291e4-6e68-11e8-8947-f733d1b8e814.png)

![image](https://user-images.githubusercontent.com/1702680/41279965-c75e94c0-6e68-11e8-97fa-d524a9965721.png)

# デバイスの追加とその他の編集

UnityDeviceMaskSettingsに一通りあります。

![image](https://user-images.githubusercontent.com/1702680/41350190-44ca8e52-6f4d-11e8-84d5-cacacdb2d9fa.png)

UnityDeviceMaskTypeを追加すると、デバイスが増えます。
この時、UnityDeviceResolution属性を付けておくと、エディタ上でマスクを適応した時に

![image](https://user-images.githubusercontent.com/1702680/41350286-9b2bc45a-6f4d-11e8-96bd-8cb2cdb7a20c.png)

自動で画面サイズが追加されます。

マスク画像は、enumに追加した値と同じ名前の画像をResources/Texturesに追加すると、その画像を読み込んで使います。

# 通しで見たい

UnityDeviceMaskというPrefabがあるので、アプリケーション起動時の初期化処理とかでResources.Loadで読み込んで、DontDestroyOnLoadしましょう。
