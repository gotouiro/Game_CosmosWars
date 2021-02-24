using UnityEngine;

public class MainScene : TitleScene
{
    void Start()
    {
        Init();
    }

    void Update()
    {
        MainSystem();
        PlayerController();
        UISystem();
    }

    //---public----------------------------------------------------------------


    //---private---------------------------------------------------------------
    /// <summary>
    /// 初期化
    /// </summary>
    private void Init()
    {

    }

    /// <summary>
    /// コントローラー
    /// </summary>
    private void PlayerController()
    {

    }

    //---protected-------------------------------------------------------------
    protected override void MainSystem()
    {

    }

    protected override void UISystem()
    {

    }
}