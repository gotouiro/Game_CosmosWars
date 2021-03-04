using UnityEngine;
using UnityEngine.UI;

public class SampleScene : GameSystem
{
    void Start()
    {
        Init();
    }

    void Update()
    {
        Main();
        UISystem();
    }

    //---public------------------------------------------------------------------
    #region 全てのパネルで使用できる関数...
    /// <summary>
    /// パネル切替                                                           <br></br>
    /// int n : 10の桁が非表示にするパネルの番号、1の桁が表示するパネルの番号<br></br>
    /// </summary>
    public void ChangePanel(int n)
    {
        //selectCountをリセット
        selectCount = 0;

        //パネル切替・selectMax設定
        switch(n)
        {
            case 12:
                ui_Panel1.SetActive(false);
                ui_Panel2.SetActive(true);
                selectMax = selectItems2.Length;
                break;

            case 13:
                ui_Panel1.SetActive(false);
                ui_Panel3.SetActive(true);
                selectMax = selectItems3.Length;
                break;

            case 21:
                ui_Panel2.SetActive(false);
                ui_Panel1.SetActive(true);
                selectMax = selectItems1.Length;
                break;

            case 23:
                ui_Panel2.SetActive(false);
                ui_Panel3.SetActive(true);
                selectMax = selectItems3.Length;
                break;

            case 31:
                ui_Panel3.SetActive(false);
                ui_Panel1.SetActive(true);
                selectMax = selectItems1.Length;
                break;

            case 32:
                ui_Panel3.SetActive(false);
                ui_Panel2.SetActive(true);
                selectMax = selectItems2.Length;
                break;

            default:
                Debug.Log("本関数の引数nの値が適切ではありません");
                break;
        }
    }
    #endregion

    #region Panel1内で実行する関数...
    /// <summary>
    /// 「Color」の色を変える    <br></br>
    /// int n : SelectColorの番号<br></br>
    /// </summary>
    public void ChangeColor(int n = 0)
    {
        switch(n)
        {
            case 1:
                ui_Panel1_Color.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                break;

            case 2:
                ui_Panel1_Color.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                break;

            case 3:
                ui_Panel1_Color.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                break;

            case 4:
                ui_Panel1_Color.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                break;

            case 5:
                ui_Panel1_Color.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                break;

            default:
                Debug.Log("本関数の引数nの値が1～5に設定されていません");
                break;
        }
    }
    #endregion

    //---private-----------------------------------------------------------------
    #region Unity上で設定するUIオブジェクト...
    //最上位オブジェクト
    [SerializeField] private GameObject ui_Panel1;
    [SerializeField] private GameObject ui_Panel2;
    [SerializeField] private GameObject ui_Panel3;

    //Panel1
    [SerializeField] private GameObject ui_Panel1_Color;

    //選択項目
    /// <summary>Panel1</summary>
    [SerializeField] private GameObject[] selectItems1;

    /// <summary>Panel2</summary>
    [SerializeField] private GameObject[] selectItems2;

    /// <summary>Panel3</summary>
    [SerializeField] private GameObject[] selectItems3;
    #endregion

    #region 変数...
    /// <summary>選択している項目の番号</summary>
    private int selectCount = 0;

    /// <summary>選択項目の最大数</summary>
    private int selectMax;
    #endregion

    #region Main関数で実行する関数...
    /// <summary>
    /// プレイヤー操作
    /// </summary>
    private void PlayerControl()
    {
        //***キーボード+マウス***************************************************
        //【W/A】UI選択(前)
        if(selectCount > 0 && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A))) selectCount--;

        //【S/D】UI選択(後)
        if(selectCount < selectMax - 1 && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))) selectCount++;
        //***********************************************************************
    }
    #endregion

    //---protected---------------------------------------------------------------
    protected override void Init()
    {
        #region UI初期化...
        //Unity上でできてなかったら、パネルを表示/非表示
        if(!ui_Panel1.activeSelf) ui_Panel1.SetActive(true);
        if(ui_Panel2.activeSelf) ui_Panel2.SetActive(false);
        if(ui_Panel3.activeSelf) ui_Panel3.SetActive(false);
        #endregion

        #region 変数初期化...
        selectMax = selectItems1.Length;
        #endregion
    }

    protected override void Main()
    {
        PlayerControl();
    }

    protected override void UISystem()
    {
        #region UIを選択...
        //Panel1
        if(ui_Panel1.activeSelf)
        {
            if(selectItems1[selectCount].GetComponent<Button>()) selectItems1[selectCount].GetComponent<Button>().Select();
        }

        //Panel2
        if(ui_Panel2.activeSelf)
        {
            if(selectItems2[selectCount].GetComponent<Button>()) selectItems2[selectCount].GetComponent<Button>().Select();
        }

        //Panel3
        if(ui_Panel3.activeSelf)
        {
            if(selectItems3[selectCount].GetComponent<Button>()) selectItems3[selectCount].GetComponent<Button>().Select();
        }
        #endregion
    }
}