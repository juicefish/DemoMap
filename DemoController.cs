using UnityEngine;

// 展示用Controller
public partial class DemoController : UIViewContainer
{
    public GameObject goWorld;
    public GameObject goArea01;
    public GameObject goArea02;

    public override string Title
    {
        get { return ""; }
    }
       
    // Demo Controller 進入點
    // 用以初始化展示所需的內容
    private void Start()
    {
        // 開始執行步驟列表
        this.ExcuteStepQueue(this.OnLoadStepComplete);
    }

    // 當所有讀取步驟完成
    private void OnLoadStepComplete()
    {
        // Demo用註冊腳本關聯
        WorldModule.Instance.demoControlller = this;
        // 開啟所有地圖節點
        WorldModule.Instance.UpdateProgress(1, 3300353, 3300353, 3300353);
        // 以第一Location為基底顯示
        WorldModule.Instance.LastRecord = WorldModule.Instance.GetLocationItem(1);

        // 顯示地圖介面
        UIManager.Instance.OpenNewPage(UIName.Map);
    }
}
