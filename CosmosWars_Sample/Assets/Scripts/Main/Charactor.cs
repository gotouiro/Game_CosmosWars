using UnityEngine;

public abstract class Charactor : MonoBehaviour
{
    //---public----------------------------------------------------------------


    //---private---------------------------------------------------------------


    //---protected-------------------------------------------------------------
    [SerializeField] protected GameObject bullet; //弾

    protected CharactorStatus charactorStatus; //ステータス

    /// <summary>
    /// 初期化
    /// </summary>
    protected abstract void Init();
}