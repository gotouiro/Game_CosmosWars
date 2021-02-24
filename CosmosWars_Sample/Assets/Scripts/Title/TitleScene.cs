using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : GameSystem
{
    void Start()
    {
        
    }

    void Update()
    {
        MainSystem();
        PlayerController();
        UISystem();
    }

    //---public----------------------------------------------------------------
    /// <summary>
    /// ゲームスタート
    /// </summary>
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    //---private---------------------------------------------------------------
    /// <summary>
    /// コントローラー
    /// </summary>
    private void PlayerController()
    {
        //【Esc】アプリケーション終了
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE
	            UnityEngine.Application.Quit();
            #endif
        }
    }

    //---protected-------------------------------------------------------------
    protected override void MainSystem()
    {
        
    }

    protected override void UISystem()
    {
        
    }
}