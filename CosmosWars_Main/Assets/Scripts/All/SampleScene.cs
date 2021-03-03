using UnityEngine;

public class SampleScene : GameSystem
{
    void Start()
    {
        Init();
    }

    void Update()
    {
        Main();
        UISystem();
    }

    //---public------------------------------------------------------------------


    //---private-----------------------------------------------------------------
    #region Unity上で設定するUIオブジェクト...
    [SerializeField] private GameObject ui_Panel1;
    [SerializeField] private GameObject ui_Panel2;
    [SerializeField] private GameObject ui_Panel3;
    #endregion

    //---protected---------------------------------------------------------------
    protected override void Init()
    {
        #region UI初期化...
        //Unity上でできてなかったら、パネルを表示/非表示
        if(!ui_Panel1.activeSelf) ui_Panel1.SetActive(true);
        if(ui_Panel2.activeSelf) ui_Panel2.SetActive(false);
        if(ui_Panel3.activeSelf) ui_Panel3.SetActive(false);
        #endregion
    }

    protected override void Main()
    {
        
    }

    protected override void UISystem()
    {
        
    }
}