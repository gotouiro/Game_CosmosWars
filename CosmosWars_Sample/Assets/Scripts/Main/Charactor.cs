using System.Collections;
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

    /// <summary>
    /// 攻撃
    /// </summary>
    protected abstract IEnumerator Attack();

    /// <summary>
    /// ダメージを与える                                  <br></br>
    /// Charactor charactor : ダメージを受けるキャラクター<br></br>
    /// </summary>
    protected virtual void Damage(Charactor charactor)
    {
        //ダメージ算出
        int damage = Random.Range(charactorStatus.at_min, charactorStatus.at_max + 1) - charactor.charactorStatus.df;
        if (damage < 1) damage = 1;

        //ダメージを与える
        charactor.charactorStatus.hp_remaining -= damage;
        if (charactor.charactorStatus.hp_remaining < 0) charactor.charactorStatus.hp_remaining = 0;
    }

    /// <summary>
    /// 死亡処理
    /// </summary>
    protected virtual void DeadProcessing()
    {
        //残り体力が0になったら4
        if (charactorStatus.hp_remaining <= 0) Destroy(gameObject);
    }
}