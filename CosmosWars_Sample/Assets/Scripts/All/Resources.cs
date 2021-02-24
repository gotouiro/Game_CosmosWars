/// <summary>
/// 属性
/// </summary>
public enum Attribute
{
    None,       //属性なし
    Fire,       //火属性
    Water,      //水属性
    Tree,       //木属性
    Right,      //光属性
    Dark,       //闇属性
    Transparent //無属性
}

/// <summary>
/// キャラクターステータス
/// </summary>
public struct CharactorStatus
{
    public Attribute attribute; //属性
    public int hp;              //体力
    public int at_min;          //最小攻撃力
    public int at_max;          //最大攻撃力
    public int at_speed;        //攻撃速度[回/s]
    public int df;              //防御力
    public int speed;           //移動速度[px/s]
}