using UnityEngine;

public abstract class GameSystem : MonoBehaviour
{
    //---protected-------------------------------------------------------------
    /// <summary>
    /// メイン処理
    /// </summary>
    protected abstract void MainSystem();

    /// <summary>
    /// UI描画
    /// </summary>
    protected abstract void UISystem();
}