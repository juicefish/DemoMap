using UnityEngine;
using System;
using System.Collections.Generic;
using Demo105N1.Common;

// 展示用Controller
// 使用 partial class 進行分類
// 此部分主要用以進行讀取流程控制
public partial class DemoController : UIViewContainer
{
    private Queue<Action> stepQueue = new Queue<Action>();
    private Action currentMethod;
    private string currentMethodName;
    private float prevTime;

    // 執行讀取步驟
    private void ExcuteStepQueue(Action onComplete)
    {
        stepQueue.Enqueue(this.StepLoadConstData);
        stepQueue.Enqueue(this.StepInitPlayerDataModule);
        stepQueue.Enqueue(this.StepInitMapModule);
        stepQueue.Enqueue(onComplete);

        StepNext();
    }

    // 執行下一步
    private void StepNext()
    {
        float nowTime = Time.realtimeSinceStartup;

        // 試著印出這次執行所花的時間
        if (!string.IsNullOrEmpty(currentMethodName))
            Debug.Log(string.Format("COST::{0}, {1} sec", currentMethodName, (nowTime - prevTime)));

        // 重新設定計時
        prevTime = nowTime;

        // 依照步驟列表剩餘個數決定執行下一步或進行完成
        if (stepQueue.Count > 0)
        {
            currentMethod = stepQueue.Dequeue();
            currentMethodName = currentMethod.Method.Name;
            currentMethod();
        }
        else
        {
            StepComplete();
        }
    }

    // 執行完成動作
    private void StepComplete()
    {
        //暫不需要
    }

    //載入ConstData
    private void StepLoadConstData()
    {
        // 顯示讀取中
        UIManager.Instance.Open(UIName.Loading);

        TextAsset textAsset = Resources.Load("PCZ/" + Config.COMMON_CONST_DATA_NAME) as TextAsset;

        //載入ConstData檔
        if (ConstData.Instance.ReadStream(textAsset.bytes, true))
        {
            // 對ConstData進行初步變數Parse
            ConstData.Instance.LoadFloatVariableData();
            ConstData.Instance.LoadIntVariableData();
            Debug.Log("Load ConstData success");
        }
        else
        {
            Debug.LogError("Load Constdata failed");
        }

        // 隱藏讀取中
        UIManager.Instance.Close(UIName.Loading);

        // 進行下一步
        StepNext();
    }
    
    // 初始化玩家資料
    // 地圖據點開啟與玩家資料有關, 故需初始化
    private void StepInitPlayerDataModule()
    {
        PlayerDataModule.Instance.Initialize();
        PlayerDataModule.Instance.Startup();
        StepNext();
    }

    // 初始化地圖資料
    private void StepInitMapModule()
    {
        WorldModule.Instance.Initialize();
        WorldModule.Instance.Startup();
        StepNext();
    }
}
