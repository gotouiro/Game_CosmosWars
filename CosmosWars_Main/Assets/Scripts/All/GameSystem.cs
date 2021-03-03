using UnityEngine;

public abstract class GameSystem : MonoBehaviour
{
    //---public------------------------------------------------------------------


    //---private-----------------------------------------------------------------


    //---protected---------------------------------------------------------------
    /// <summary>
    /// 初期化(UIの初期化もここで)
    /// </summary>
    protected abstract void Init();

    /// <summary>
    /// メイン処理
    /// </summary>
    protected abstract void Main();

    /// <summary>
    /// UIの設定・描画はここで
    /// </summary>
    protected abstract void UISystem();
}