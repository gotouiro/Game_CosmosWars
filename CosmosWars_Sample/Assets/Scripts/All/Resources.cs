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
    public Attribute attribute_main; //主属性
    public Attribute attribute_sub;  //副属性
    public int hp_max;               //最大体力
    public int hp_remaining;         //残り体力
    public int at_min;               //最小攻撃力
    public int at_max;               //最大攻撃力
    public float at_speed;           //攻撃速度[回/s]
    public int df;                   //防御力
    public float speed;              //移動速度[px/s]

    /// <summary>
    /// 初期化                          <br></br>
    /// int h           : 最大体力      <br></br>
    /// int a_min       : 最小攻撃力    <br></br>
    /// int a_max       : 最大攻撃力    <br></br>
    /// float a_sp      : 攻撃速度[回/s]<br></br>
    /// int d           : 防御力        <br></br>
    /// float sp        : 移動速度[px/s]<br></br>
    /// Attribute att_m : 主属性        <br></br>
    /// Attribute att_s : 副属性        <br></br>
    /// </summary>
    public CharactorStatus(int h, int a_min, int a_max, float a_sp, int d, float sp, Attribute att_m, Attribute att_s = Attribute.None)
    {
        hp_max = h;
        hp_remaining = hp_max;
        at_min = a_min;
        at_max = a_max;
        at_speed = a_sp;
        df = d;
        speed = sp;
        attribute_main = att_m;
        attribute_sub = att_s;
    }
}