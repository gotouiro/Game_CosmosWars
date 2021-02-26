using System.Collections;
using UnityEngine;

public class Player : Charactor
{
    void Start()
    {
        Init();
    }

    void Update()
    {
        PlayerController();
    }

    //---public----------------------------------------------------------------


    //---private---------------------------------------------------------------
    private Vector2 length = new Vector2(32, 32); //オブジェクトの縦横の長さ(width, height)

    /// <summary>
    /// キャラクターの弾クラス設定
    /// </summary>
    private class Bullet : MonoBehaviour
    {
        void Start()
        {
            Init();
        }

        void Update()
        {
            Move();
            DeleteProcessing();
        }

        //---public----------------------------------------------------------------
        /// <summary>
        /// 弾の移動速度[px/s]
        /// </summary>
        public float _speed
        {
            get { return speed; }
            set { speed = value; }
        }

        //---private---------------------------------------------------------------
        private float speed; //弾の移動速度[px/s]

        /// <summary>
        /// 初期化
        /// </summary>
        private void Init()
        {
            
        }

        /// <summary>
        /// 弾移動
        /// </summary>
        private void Move()
        {
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }

        /// <summary>
        /// ウィンドウ外によるオブジェクト削除処理
        /// </summary>
        private void DeleteProcessing()
        {
            if (transform.position.y > 600) Destroy(gameObject);
        }

        //---protected-------------------------------------------------------------

    }

    /// <summary>
    /// 攻撃
    /// </summary>
    private IEnumerator Attack()
    {
        while(true)
        {
            GameObject bul = Instantiate(bullet, transform.position + new Vector3(0, length.y / 2, 0), new Quaternion());
            bul.AddComponent<Bullet>();
            bul.GetComponent<Bullet>()._speed = charactorStatus.speed * 2;
            yield return new WaitForSeconds(1 / charactorStatus.at_speed);
        }
    }

    /// <summary>
    /// コントローラー
    /// </summary>
    private void PlayerController()
    {
        //【W/A/S/D】移動
        if (transform.position.y <  540 - length.y && Input.GetKey(KeyCode.W)) transform.position += new Vector3( 0,  1, 0) * charactorStatus.speed * Time.deltaTime;
        if (transform.position.y > -540 + length.y && Input.GetKey(KeyCode.S)) transform.position += new Vector3( 0, -1, 0) * charactorStatus.speed * Time.deltaTime;
        if (transform.position.x <  960 - length.x && Input.GetKey(KeyCode.D)) transform.position += new Vector3( 1,  0, 0) * charactorStatus.speed * Time.deltaTime;
        if (transform.position.x > -960 + length.x && Input.GetKey(KeyCode.A)) transform.position += new Vector3(-1,  0, 0) * charactorStatus.speed * Time.deltaTime;

        //【←/→】属性切替
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (attribute[0] == charactorStatus.attribute_main)
            {
                attribute[0] = charactorStatus.attribute_sub;
                attribute[1] = charactorStatus.attribute_main;
            }
            else
            {
                attribute[0] = charactorStatus.attribute_main;
                attribute[1] = charactorStatus.attribute_sub;
            }
        }

        //【Space】攻撃
        if (Input.GetKeyDown(KeyCode.Space)) StartCoroutine("Attack");
        if (Input.GetKeyUp(KeyCode.Space)) StopCoroutine("Attack");
    }

    //---protected-------------------------------------------------------------
    protected override void Init()
    {
        charactorStatus = new CharactorStatus(30000, 1000, 5000, 2, 600, 800, Attribute.Fire, Attribute.Water);
        attribute = new Attribute[2];
        attribute[0] = charactorStatus.attribute_main;
        attribute[1] = charactorStatus.attribute_sub;
    }
}