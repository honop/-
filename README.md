[![Latest Release](https://img.shields.io/github/release/sfc-sdp/GameCanvas-Unity.svg)](https://github.com/sfc-sdp/GameCanvas-Unity/releases/latest)　[![GameCanvas API v2.1](https://img.shields.io/badge/GameCanvas%20API-v2.1-yellow.svg)](https://sfc-sdp.github.io/GameCanvas-Unity/api/GameCanvas.Proxy.html)
[<img alt="GameCanvas" align="right" src="Assets/GameCanvas/Icons/icon_android_full.png"/>](https://github.com/sfc-sdp/GameCanvas-Unity/releases/latest)

## GameCanvas にようこそ！

**GameCanvas for Unity** は、慶應義塾大学『スマートデバイスプログラミング』にて  
教材として使われている 2Dゲームフレームワーク です。

プログラミング初心者でも、スマートデバイス向けアプリケーションを楽しく開発できる環境を目指して開発されました。

## 導入方法
1. [UnityHub](https://unity3d.com/jp/get-unity/download)を入手し、Unity 2019.3.11f1, Androidプラグイン, iOSプラグイン, 日本語言語パックを選択してインストールします  
※ 推奨バージョンは Unity 2019.3.11f1 です。9GB以上の空き容量が必要です  
※ インストール方法が分からない方は[こちらの記事](https://creive.me/archives/13376/)も参考にしてください

2. [最新の GameCanvas](https://github.com/sfc-sdp/GameCanvas-Unity/releases/latest) からソースコードを入手・解凍します。UnityHubの開くボタンから解凍したフォルダを選択すると、プロジェクトが開きます

3. プロジェクトビューから `Assets/Game.unity` を開き、再生ボタンを押します。サンプルが実行されれば導入完了です

4. [Assets/Game.cs](Assets/Game.cs) を編集して、自分だけのオリジナルアプリを作りましょう  
※ コードエディタは [VSCode](https://code.visualstudio.com/) がおすすめです。Unityとの連携方法は[公式導入ガイド(英語)](https://code.visualstudio.com/docs/other/unity)を参考にしてください

iOS や Android への書き出しなど、より詳しい解説は、[スマートデバイスプログラミング 講義ページ](http://web.sfc.keio.ac.jp/~wadari/sdp/) を参照してください

## API ドキュメント
最新の仕様は [GameCanvas for Unity API ドキュメント](https://sfc-sdp.github.io/GameCanvas-Unity/api/GameCanvas.Proxy.html) で確認できます

## 質問・バグ報告
GameCanvasに対する質問や提案、バグ報告は [![Issues](https://img.shields.io/github/issues/sfc-sdp/GameCanvas-Unity.svg)](https://github.com/sfc-sdp/GameCanvas-Unity/issues) で受け付けています

## ライセンス
Copyright (c) 2015-2020 Smart Device Programming.

This software is released under the MIT License, see [LICENSE](LICENSE).



## 2020年度春学期スマートデバイスプログラミング

★アプリ名：単位かき集めゲーム

★想定している端末の機種名、縦横の解像度：iphone11、720x1280

★動作確認方法（1：apkで実機確認、２：xcodeで実機用ファイルを作成して確認、３：UnityRemoteで確認、４：その他）：３のUnityRemoteで確認しました。

★作ったアプリの内容：
制限時間内(30秒)に、空から降ってくる単位やアイテムを拾い、総取得単位数>=124にすることで「大学卒業」を目指すゲームです。プレイヤー選択(男女二択)を行なったのち、ゲームで遊ぶことができます。「単位」「林檎」「虹鉱石」を拾うと単位数が増加するのに対し、「毒林檎」「毒薬」を拾うと単位数が減少します。また「退学届」を拾うと即「放塾（退学）ルート」に進みます。基本的に、制限時間内に総取得単位数>=124にすることができれば「卒業ルート」に、できなければ「放塾ルート」に進みます。

★工夫した点、苦労した点、ＰＲポイント（あれば）：
工夫した点は２つあります。 まず、初見のユーザーでもゲーム操作に手こずることなく遊べるようするために、ゲームのUIをわかりやすく且つ綺麗に整えることを意識しました。例えば「単位を拾うゲーム」のシーンでは、左右の矢印ボタンを配置したことで「そこを押せばプレイヤーアバターが左右に動く」と直感的にわかるようにしました。 ２つ目の工夫点としては、ゲームの可愛らしい雰囲気に合わせるために「親しみやすい優しい印象の角ゴシック」である「ぼくたちのゴシック２レギュラー(https://fontopo.com/?p=94) 」というフォントを使用した点が挙げられます。 苦労した点としては、２つあります。 １つ目としてはスタートボタンや矢印ボタンなどのボタン画像の範囲内に指が触れたりカーソルクリックがなされたりした場合のみゲームが進行するようにするために、gc.GetPointerXやgc.GetPointerYを使って細かく範囲指定した点が挙げられます。 ２つ目としては、空から降ってくるアイテムが草むらのところで丁度綺麗に消えるように座標調整した点が挙げられます。

★備考 流用したリソース、アセットがあれば記載してください。 （自作リソースで、来期以降の授業で使っても良い、という場合は、書いておいてください）

【参考にしたもの・使用した外部データなど】
1. アイテムが空から降ってくるプログラミング：「スマートデバイスプログラミング 第4回　Unityで開発してみよう（その３、表示編）(http://web.sfc.keio.ac.jp/~wadari/sdp/k04.html) 」の課題内容を改変しました。 
2. 自作のオレンジ矢印ボタン（Adobe Illustratorで作成）以外の全ての画像：「かわいいフリー素材集　いらすとや」(https://www.irasutoya.com/)
3. 使用したフォント：「ぼくたちのゴシック２レギュラー」(https://fontopo.com/?p=94)
4. 上記以外のプログラミング内容に関しては、適宜「Class Proxy GameCanvas API（https://sfc-sdp.github.io/GameCanvas-Unity/api/GameCanvas.Proxy.html) 」や「スマートデバイスプログラミング　授業テキスト(http://web.sfc.keio.ac.jp/~wadari/sdp/) 」の各回の「今週使う変数、メソッド」を参考にしました。

【使用したBGM一覧】 
1. Snd0:「しっぽフリフリ by すもち(https://dova-s.jp/bgm/play12668.html)」 
2. Snd1:「効果音ラボ『決定、ボタン押下音　深い響き』(https://soundeffect-lab.info/sound/button/)」 
3. Snd2:「かわいい効果音3 by 作田京輔(https://dova-s.jp/se/play685.html)」 
4. Snd3:「かわいい効果音 by 作田京輔(https://dova-s.jp/se/play680.html)」 
5. Snd4:「アイテム発見 by 作田京輔(https://dova-s.jp/se/play640.html)」 
6. Snd5:「効果音ラボ『キャンセル5 チュン』(https://soundeffect-lab.info/sound/button/)」 
7. Snd6:「焦り・失敗した時の音 by Yuno(https://dova-s.jp/se/play1234.html)」 
8. Snd7:「音人『ハープ01（上がり）』(https://on-jin.com/sound/listshow.php?pagename=ta&title=%E3%83%8F%E3%83%BC%E3%83%9701%EF%BC%88%E4%B8%8A%E3%81%8C%E3%82%8A%EF%BC%89&janl=%E3%81%9D%E3%81%AE%E4%BB%96%E9%9F%B3&bunr=%E5%BC%A6%E6%A5%BD%E5%99%A8%E7%B3%BB&kate=%E6%A5%BD%E5%99%A8%E7%B3%BB)」
