# UnityDeviceMask

最近流行りのiPhone XとかAndroidとかの角丸な画面をエディタ上で検証する何か。

できるだけシンプルな作りにしたので、エディタではわかりにくい指が届く範囲を示したりなどをするのにも使える、かもしれない。

# 配置

Tonari/UnityDeviceMaskの下に端末の一覧が出るので、それを選択するだけ。

![image](https://user-images.githubusercontent.com/1702680/41390350-373feb6e-6fd0-11e8-8e45-b43e73d8e155.png)

![image](https://user-images.githubusercontent.com/1702680/41350355-df57884e-6f4d-11e8-9030-933ecf5e4995.png)

# デバイスの追加とその他の編集

UnityDeviceMaskSettingsに一通りあります。

![image](https://user-images.githubusercontent.com/1702680/41390421-81408c28-6fd0-11e8-98c8-9f2a4713fa3a.png)

UnityDeviceMaskTypeを追加すると、デバイスが増えます。
この時、GameViewSize属性を付けておくと、エディタ上でマスクを適応した時に

![image](https://user-images.githubusercontent.com/1702680/41390444-94147404-6fd0-11e8-99c8-e5859f656f5e.png)

自動でGameViewに画面サイズが追加、選択されます。

マスク画像は、enumに追加した値と同じ名前の画像をResources/Texturesに追加すると、その画像を読み込んで使います。
ない場合、警告は出ますが動作に問題はありません。

![image](https://user-images.githubusercontent.com/1702680/41350405-04cd8ede-6f4e-11e8-9f7c-cf7ebed7207d.png)

# 通しで見たい

UnityDeviceMaskというPrefabがあるので、アプリケーション起動時の初期化処理とかでResources.Loadで読み込んで、DontDestroyOnLoadしましょう。
