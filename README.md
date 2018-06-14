# UnityDeviceMask

最近流行りのiPhone XとかAndroidとかの角丸な画面をエディタ上で検証する何か。

できるだけシンプルな作りにしたので、エディタではわかりにくい指が届く範囲を示したりなどをするのにも使える、かもしれない。

# 配置

UnityDeviceMaskというPrefabがあるので、それをシーンに配置するだけです。

![image](https://user-images.githubusercontent.com/1702680/41350388-f875073e-6f4d-11e8-9f7c-73ea947a8bdb.png)

![image](https://user-images.githubusercontent.com/1702680/41350355-df57884e-6f4d-11e8-9030-933ecf5e4995.png)

# デバイスの追加とその他の編集

UnityDeviceMaskSettingsに一通りあります。

![image](https://user-images.githubusercontent.com/1702680/41350190-44ca8e52-6f4d-11e8-84d5-cacacdb2d9fa.png)

UnityDeviceMaskTypeを追加すると、デバイスが増えます。
この時、UnityDeviceResolution属性を付けておくと、エディタ上でマスクを適応した時に

![image](https://user-images.githubusercontent.com/1702680/41350286-9b2bc45a-6f4d-11e8-96bd-8cb2cdb7a20c.png)

自動で画面サイズが追加、選択されます。

マスク画像は、enumに追加した値と同じ名前の画像をResources/Texturesに追加すると、その画像を読み込んで使います。

![image](https://user-images.githubusercontent.com/1702680/41350405-04cd8ede-6f4e-11e8-9f7c-cf7ebed7207d.png)

# 通しで見たい

UnityDeviceMaskというPrefabがあるので、アプリケーション起動時の初期化処理とかでResources.Loadで読み込んで、DontDestroyOnLoadしましょう。
