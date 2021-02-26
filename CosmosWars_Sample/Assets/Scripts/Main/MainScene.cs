using UnityEngine;
using UnityEngine.UI;

public class MainScene : GameSystem
{
    void Start()
    {
        Init();
    }

    void Update()
    {
        MainSystem();
        UISystem();
    }

    //---public----------------------------------------------------------------


    //---private---------------------------------------------------------------
    [SerializeField] private GameObject ui_HPBar;
    [SerializeField] private GameObject ui_HPBar_Value;
    [SerializeField] private GameObject ui_Attribute_Current;
    [SerializeField] private GameObject ui_Attribute_Other;
    [SerializeField] private GameObject player;

    //---protected-------------------------------------------------------------
    protected override void Init()
    {
        
    }

    protected override void MainSystem()
    {

    }

    protected override void UISystem()
    {
        //HP
        ui_HPBar.GetComponent<Slider>().value = (float)player.GetComponent<Player>()._charactorStatus.hp_max / (float)player.GetComponent<Player>()._charactorStatus.hp_remaining;
        ui_HPBar_Value.GetComponent<Text>().text = player.GetComponent<Player>()._charactorStatus.hp_remaining + "/" + player.GetComponent<Player>()._charactorStatus.hp_max;

        //現在の属性
        if      (player.GetComponent<Player>()._currentAttribute[0] == Attribute.Fire)  ui_Attribute_Current.GetComponent<Image>().color = Color.red;
        else if (player.GetComponent<Player>()._currentAttribute[0] == Attribute.Water) ui_Attribute_Current.GetComponent<Image>().color = Color.blue;
        else if (player.GetComponent<Player>()._currentAttribute[0] == Attribute.Tree)  ui_Attribute_Current.GetComponent<Image>().color = Color.green;
        else if (player.GetComponent<Player>()._currentAttribute[0] == Attribute.Right) ui_Attribute_Current.GetComponent<Image>().color = Color.yellow;
        else if (player.GetComponent<Player>()._currentAttribute[0] == Attribute.Dark)  ui_Attribute_Current.GetComponent<Image>().color = new Color32(128, 0, 255, 255);
        else                                                                            ui_Attribute_Current.GetComponent<Image>().color = Color.gray;

        //次に切り替わる属性
        if      (player.GetComponent<Player>()._currentAttribute[1] == Attribute.None)  ui_Attribute_Other.GetComponent<Image>().color = Color.clear;
        else if (player.GetComponent<Player>()._currentAttribute[1] == Attribute.Fire)  ui_Attribute_Other.GetComponent<Image>().color = Color.red;
        else if (player.GetComponent<Player>()._currentAttribute[1] == Attribute.Water) ui_Attribute_Other.GetComponent<Image>().color = Color.blue;
        else if (player.GetComponent<Player>()._currentAttribute[1] == Attribute.Tree)  ui_Attribute_Other.GetComponent<Image>().color = Color.green;
        else if (player.GetComponent<Player>()._currentAttribute[1] == Attribute.Right) ui_Attribute_Other.GetComponent<Image>().color = Color.yellow;
        else if (player.GetComponent<Player>()._currentAttribute[1] == Attribute.Dark)  ui_Attribute_Other.GetComponent<Image>().color = new Color32(128, 0, 255, 255);
        else                                                                            ui_Attribute_Other.GetComponent<Image>().color = Color.gray;
    }
}