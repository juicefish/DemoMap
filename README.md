# 概要
* [連結：地圖 WebGL](https://juicefish.github.io/MapDemoWebGL/index.html)
* [連結：地圖 WebPlayer (IE 啟用ActiveX)](https://juicefish.github.io/MapDemoWebPlayer/MapDemoWebPlayer.html)
* [連結：YouTube影片](https://youtu.be/aBdoGCPtTf4)
* 世界地圖操作(展示用)
* 圖片來源取自於網路，呈現品質可能較差，不影響主要功能

## 程式碼
* DemoController.cs：作為展示用的主流程控制器
* DemoController.LoadStep.cs：使用partial class區分主要流程及讀檔流程

## 模組/管理器
* UIManager：介面管理器，包含頁面跳轉流程等
* ConstData：靜態資料管理器
* PlayerDataModule：玩家資料模組，包含等級經驗等
* WorldModule：世界地圖及關卡資料模組
