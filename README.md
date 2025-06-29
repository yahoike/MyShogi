﻿# コンソールからSVG画像を作成する自分用の改造です。

## バッチファイル

```
@echo off
MyShogi.exe "ln1g2s+Rl/1r1sk1+P2/p1pppp2p/6p2/9/Pp1b5/1PPPPPP1P/1B3S3/LNSGKG1NL b GNP 1" "target.svg"
python svg2img.py target.svg
pause
```

このように使う予定です。

## プロジェクト設定：GUIからコンソールアプリに変更する

この改造では Program.cs を追加してコマンドラインで動作する機能を実装しているため、Visual Studio のプロジェクト設定を以下のように変更する必要があります。

変更手順（Visual Studio GUI）

MyShogi プロジェクトを右クリック → 「プロパティ（Properties）」を選択

左側の「アプリケーション」を選択

「出力の種類（Output type）」を 「コンソール アプリケーション」 に変更

保存して再ビルド

注意：

デフォルトでは「Windows アプリケーション」になっているため、コンソール画面が表示されません。

出力をコマンドラインで確認したい場合や Console.WriteLine() を使いたい場合は、必ずこの設定変更が必要です。

# About this project

MyShogi is an open source GUI for computer Shogi engine.

MyShogiは、オープンソースの将棋ソフト用GUIです。
2018年にマイナビ出版さんから発売する商用版のやねうら王用のGUIとして開発が始まりました。

# スクリーンショット

- やねうら王の公式Twitterの画像をそのまま貼り付けたため、縦横の比率がおかしいです。

|||
|---|---|
|<img src="https://pbs.twimg.com/media/Dez3gZxVAAASWWY.jpg" width="400" height="254" alt="対局設定">|<img src="https://pbs.twimg.com/media/Dg6DMjYUcAAol41.jpg" width="400" height="254" alt="盤面編集">|
|<img src="https://pbs.twimg.com/media/DhP9uLkUEAAue8I.jpg" width="400" height="254" alt="対局画面">|<img src="https://pbs.twimg.com/media/Dez3hKnUcAANNd9.jpg" width="400" height="254" alt="成り不成">|
|<img src="https://pbs.twimg.com/media/DhmEiQ-UYAATJQF.jpg" width="400" height="254" alt="エンジン選択">|<img src="https://pbs.twimg.com/media/Dem5sS2U0AEjgC7.jpg" width="400" height="254" alt="利きマーカー">|
<img src="https://pbs.twimg.com/media/Deb12RyV0AA7ZCw.jpg" width="400" height="254" alt="英字駒">|<img src="https://pbs.twimg.com/media/Deb13B4VMAAYAfZ.jpg" width="400" height="254" alt="1文字駒">|
<img src="https://pbs.twimg.com/media/DpCA9CSUwAAmUWW.jpg" width="400" height="254" alt="設定ダイアログ 駒表示">|<img src="https://pbs.twimg.com/media/DpCA9BvUcAEU1Qx.jpg" width="400" height="254" alt="設定ダイアログ 盤面表示">|


# 特徴

- オープンソース
- エンジン設定などがユーザーフレンドリー
- 思考エンジン開発者のデバッグに役立つような優しい作り
- コアな部分は、pure C#で書かれている。(ほぼフルスクラッチ)
- View以外は実行環境への依存低めに書いてあるので移植性に優れている
- Viewも環境依存、かなり低め。(対局画面はBitmapの矩形転送と文字描画のみ)
- Headlessモード(GUIなしモード)搭載で、pythonなどから呼び出して対局させることが出来る
- レスポンシブな画面デザイン(ウィンドウサイズ可変、幅を狭めると縦長の駒台になるなど)

…になる予定

# 実装済みの機能、細かな特徴など

- たくさんあって書ききれないのでこちらをどうぞ。→　[実装済みの機能](MyShogi/docs/実装済みの機能.md)

# 初回リリースで実装する予定の機能

- わかりやすいエンジン設定(エンジン共通設定・個別設定、自動メモリマネージメント、自動スレッドマネージメント)
- コンピューターの段位選択機能
- CPU自動判定
- 通常対局機能(駒落ち対局含む)
- 詰将棋エンジンの利用
- 検討機能(KI2,KIF,CSA,Sfen形式を選択可能)、ミニ盤面
- 盤面編集機能
- KIF/KI2/CSA/SFEN/PSN/[PSN2](MyShogi/docs/PSN2format.md)/JSON/JKF/LiveJSON形式の棋譜の入出力機能。分岐棋譜対応。
- 局面図のSVG形式での出力
- 入玉宣言勝ちの条件変更(24点法、27点法、トライルール)
- 連続対局
- 棋譜の自動保存
- 対局結果一覧の表示
- 形勢グラフ
- 棋譜解析機能

# 商用版について

## 商用版にのみ搭載される機能

- 各思考エンジンのエンジンバナー
- 指し手の読み上げ(音声)、秒読み(音声)
- インターネット非公開の評価関数ファイル
- やねうら王の非公開定跡ファイル

## 商用版『やねうら王 2018』に搭載される予定のエンジン

- tanuki-(2018年版) : WCSC28版からR50ぐらいup
- tanuki-(SDT5 優勝バージョン)
- Qhapaq(2018年版)
- 読み太(2018年版)
- やねうら王(2018年版) : KPP_KKPT型 , depth 12の教師50億局面から学習

## 商用版に関する記事

- 商用版について詳しいことは、こちらの記事をどうぞ。→ [PC将棋ソフト「将棋神 やねうら王」に関してお答えします](http://yaneuraou.yaneu.com/2018/06/15/pc%E5%B0%86%E6%A3%8B%E3%82%BD%E3%83%95%E3%83%88%E3%80%8C%E5%B0%86%E6%A3%8B%E7%A5%9E-%E3%82%84%E3%81%AD%E3%81%86%E3%82%89%E7%8E%8B%E3%80%8D%E3%81%AB%E9%96%A2%E3%81%97%E3%81%A6%E3%81%8A%E7%AD%94/)

- バグ、要望等は、こちらの記事にどうぞ。→ [『将棋神やねうら王』Update3までの遊戯施設 / やねうら王ブログ](http://yaneuraou.yaneu.com/2018/10/06/%E3%80%8E%E5%B0%86%E6%A3%8B%E7%A5%9E%E3%82%84%E3%81%AD%E3%81%86%E3%82%89%E7%8E%8B%E3%80%8Fupdate3%E3%81%BE%E3%81%A7%E3%81%AE%E9%81%8A%E6%88%AF%E6%96%BD%E8%A8%AD/)


## 商用版に関する情報

- 無事マスターアップが終わり、2018年8月24日からダウンロード販売が開始されました。(パッケージ版の発売は8月末より)

- マイナビ公式のアップデート情報については、[マイナビ 将棋神やねうら王](https://book.mynavi.jp/ec/products/detail/id=92007)をご確認ください。
- 開発の作業進捗については、[WIP](MyShogi/docs/WIP.md)をご覧ください。


## 商用版に関するニュースリリース

- 2018.08.23 マイナビ将棋情報局 : [ついに発売！史上最強の将棋ソフト「将棋神 やねうら王」の全貌](https://book.mynavi.jp/shogi/detail/id=93490) 

- 2018.09.06 マイナビ将棋情報局 : [好評発売中「将棋神 やねうら王」　大規模アップデート配信開始！！](https://book.mynavi.jp/shogi/detail/id=93924)

- 2018.10.10 マイナビ将棋情報局 : [「自然な弱さ」を実現！「将棋神 やねうら王」アップデート第２弾リリース](https://book.mynavi.jp/shogi/detail/id=99063)


## 商用版に関するユーザーレビュー

- 2018.08.24 [「将棋神 やねうら王」買ったよ（1） インストール編](https://shogi.zukeran.org/2018/08/24/yaneuraoh-1/)
- 2018.08.25 [「将棋神 やねうら王」買ったよ（2） 対局編](https://shogi.zukeran.org/2018/08/25/yaneuraoh-2/)


# 将来的に実装するかも知れない機能

※　案を書いているだけで、対応を約束するものではありません。また、一部機能は商用版のみに搭載するかも知れません。予め、ご了承ください。

// 実装予定
- 2盤面同時表示、4盤面同時表示、8盤面同時表示、etc…
- 多面指し機能

// 対応を検討中

- 将棋所、ShogiGUIにある機能はだいたい実装していく予定です。

- 対局
	- 中断局の再開処理(中断するまでの最後の指し手の時間が加算されてその時の持ち時間のまま対局を再開出来るように)
	- 持ち時間が減る時の画面描画、最小矩形にして高速化する
	- 戦型判定～囲い完成時のエフェクト等
	- コンピュータの指す戦型を指定するモード(GUIだけでは限界があるような…)
	- 手加減モード , 接待モード等 , 指導対局
	- MultiPonder(ponderを複数のインスタンスに対して同時に行う)
	- クラスター探索機能

- 検討機能
	- 検討機能に悪手率の計測等
	- (人間の)棋力判定機能
	- 局面の自動抽出機能(検討モードで特定の条件に合致する局面図をファイルに書き出す)
	- 即席詰将棋機能、中盤終盤課題局面生成機能、評価値当てクイズetc…
	- 感想戦機能(日本語文書での棋譜の自動解説)
	- 棋戦の観戦機能
	- 局面の激しさ(思考を深めて行ったときの指し手の安定度等を)を何らか可視化
- 思考の可視化
	- 評価値グラフの縦軸をlogや期待勝率で表示する機能

- 定跡
	- 定跡編集機能
	- 定跡自動生成機能
	- 駒落ち定跡

- タブレット端末向け
	- 後手の駒の成り・不成のダイアログ、駒、キャンセルの文字を180度回して表示する機能。
	- 駒台を上下に表示する超縦長のモードがあってもいいのでは。

- 自己対局
	- 蠱毒(複数のソフトの自動対局、自動レーティング算出)
	- 並列自動対局(ソフトの自己対局を複数インスタンスで同時に行う)
	- 指定局面(フォルダのなかのKIFファイルすべてを対象とする)からの連続自動対局

- SNS対応
	- エンジンによる検討内容をツイート機能
	- スクリーンショットの撮影など

- 通信対局
	- 通信対局(1対1)
	- floodgate対応
	- AWSにエンジンを配置しての利用
	- オンライン対局

- 国際化
	- 多言語対応

- 移植
	- Mac/Linux対応。→ [2018/10/17] かなり動くところまで来ました。
	- スマホ版(iOS/Android)
	- ブラウザ版 , ブラウザ版によるオンライン対局

- 他ルール
	- 王手将棋
	- ついたて将棋等

- その他
	- メニューの下にあるボタン(toolstrip)のカスタマイズ機能
	- 音声認識対応(目隠し将棋が捗る)

- 開発用
	- ベンチマーク
	- Headlessモード(GUIなしモード)搭載。pythonなどから呼び出して対局させられるように。
	- 教師局面のクラスターを用いた生成
	- [USI2.0](MyShogi/docs/USI2.0.md)対応


# 本GUIが対応する思考エンジン

USIプロトコル対応のエンジンならば問題なく使えます。
[USI2.0](MyShogi/docs/USI2.0.md)をサポートしているのがベストなので、一番のお勧めは、やねうら王です。その次にお勧めなのは、やねうら王系のエンジンです。

- [やねうら王](https://github.com/yaneurao/YaneuraOu)
- [tanuki-](https://github.com/nodchip/tnk-)
- [読み太](https://github.com/TukamotoRyuzo/Yomita)

# 使い方

- USIプロトコル対応の将棋エンジンが使えます。
- GUIの操作説明については、[オンラインマニュアル](https://github.com/yaneurao/MyShogi/tree/master/MyShogi/docs/online_manual.md")をどうぞ。


# 本プロジェクトが提案するフォーマット

- [PSN2format](MyShogi/docs/PSN2format.md) : PSN形式から改良された棋譜ファイルフォーマット
- [USI2.0](MyShogi/docs/USI2.0.md) : USIプロトコルから改良されたプロトコル


# Mac、Linux向けのビルド情報

MyShogiはWindows向けに開発されていますが、機種依存するコードは最小限となっているので、他の環境でも頑張れば動くようです。Mac/Linux(Ubuntu18.04)で動作することを確認しています。

- [Mac、Linuxで動作させるには](MyShogi/docs/Mac、Linuxで動作させるには.md)


# 謝辞

本GUIを使ってくださる皆様、開発に関わってくださった皆様、誠にありがとうございます。

- 商用版を製作する機会を与えてくれたマイナビ出版(画像素材作成、音声素材を提供)
- tanuki-のエンジン開発者の野田さん、那須さん、たぬきチームのメンバー
- Qhapaqの澤田さん、読み太の塚本さん
- WhaleWatcherのソースコードを提供してくれた、えびふらいさん
- GUIの開発を協力してくれたMizarさん
- レーティング計測にご協力いただいたuuunuuunさん
- やねうら王に貢献してくださっている方々
- やねうら王のブログのコメント欄で要望などを教えていただいた皆さん
- Stockfishの開発チーム
- βテスターでご協力いただいた皆さん
  - うさ親さん , masaさん , kumaさん , 48さん , かず@なのはさん , tanuki-さん , Wandre-sakさん , tibigameさん
  - まふさん , suimonさん , uuunuuunさん ,  田中誠さん
  - ぐららるさん , yoiyoiさん , 和差積 商さん , Backgammonさん , tkponさん
- Mac/Linux移植協力
  - jnoryさん , ao-o10yanさん , fxst24さん

# ライセンス

- ソースコードはGPLv3
- ただし画面素材、音声素材の単体配布(二次利用等)は禁止(マイナビ出版に権利があるため)

