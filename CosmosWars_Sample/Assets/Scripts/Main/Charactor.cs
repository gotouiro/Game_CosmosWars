using UnityEngine;

public abstract class Charactor : MonoBehaviour
{
    //---public----------------------------------------------------------------
    /// <summary>
    /// ステータス
    /// </summary>
    public CharactorStatus _charactorStatus
    {
        get { return charactorStatus; }
    }

    /// <summary>
    /// 属性(0：現在の属性　1：次に切り替える属性)
    /// </summary>
    public Attribute[] _currentAttribute
    {
        get { return attribute; }
    }

    //---private---------------------------------------------------------------


    //---protected-------------------------------------------------------------
    [SerializeField] protected GameObject bullet; //弾

    protected CharactorStatus charactorStatus; //ステータス
    protected Attribute[] attribute;           //属性(0：現在の属性　1：次に切り替える属性)

    /// <summary>
    /// 初期化
    /// </summary>
    protected abstract void Init();
}