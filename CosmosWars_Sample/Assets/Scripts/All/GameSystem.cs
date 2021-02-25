using UnityEngine;

public abstract class GameSystem : MonoBehaviour
{
    //---protected-------------------------------------------------------------
    /// <summary>
    /// 初期化
    /// </summary>
    protected abstract void Init();
    /// <summary>
    /// メイン処理
    /// </summary>
    protected abstract void MainSystem();

    /// <summary>
    /// UI描画
    /// </summary>
    protected abstract void UISystem();
}