using System.Collections;
using UnityEngine;

public class Enemy : Charactor
{
    void Start()
    {
        Init();
    }

    void Update()
    {
        if(gameObject)
        {
            EnemyMove();
            DeadProcessing();
        }
    }

    //---public----------------------------------------------------------------
    /// <summary>
    /// オブジェクトの縦横の長さ(width, height)
    /// </summary>
    public Vector2 _length
    {
        get { return length; }
    }

    //---private---------------------------------------------------------------
    private Vector2 length = new Vector2(32, 32); //オブジェクトの縦横の長さ(width, height)

    #region 敵の弾クラス設定...
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

        void OnCollisionEnter2D(Collision2D collision)
        {
            //敵もしくは敵の弾に当たった場合オブジェクト削除
            //敵に当たった場合ダメージを与える
            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.GetComponent<Player>()) enemy.Damage(collision.gameObject.GetComponent<Player>());
                Destroy(gameObject);
            }
        }

        //---public----------------------------------------------------------------
        /// <summary>
        /// 敵
        /// </summary>
        public Enemy _enemy
        {
            get { return enemy; }
            set { enemy = value; }
        }

        /// <summary>
        /// 弾の移動速度[px/s]
        /// </summary>
        public float _speed
        {
            get { return speed; }
            set { speed = value; }
        }

        //---private---------------------------------------------------------------
        private Enemy enemy; //敵
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
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }

        /// <summary>
        /// ウィンドウ外によるオブジェクト削除処理
        /// </summary>
        private void DeleteProcessing()
        {
            if (transform.position.y < -600) Destroy(gameObject);
        }

        //---protected-------------------------------------------------------------

    }
    #endregion

    /// <summary>
    /// 敵の移動
    /// </summary>
    private void EnemyMove()
    {
        //ウィンドウ外に出たときオブジェクト削除
        if (transform.position.y < -600) Destroy(gameObject);

        //通常移動
        else transform.position += new Vector3(0, -1, 0) * charactorStatus.speed * Time.deltaTime;
    }

    //---protected-------------------------------------------------------------
    protected override void Init()
    {
        charactorStatus = new CharactorStatus(6000, 300, 800, 0.7f, 20, 300, Attribute.Tree, Attribute.None);
        attribute = new Attribute[2];
        attribute[0] = charactorStatus.attribute_main;
        attribute[1] = charactorStatus.attribute_sub;
        StartCoroutine("Attack");
    }

    protected override IEnumerator Attack()
    {
        while (true)
        {
            GameObject bul = Instantiate(bullet, transform.position + new Vector3(0, -length.y / 2, 0), new Quaternion(0,0,180,0));
            bul.AddComponent<Bullet>();
            bul.GetComponent<Bullet>()._speed = charactorStatus.speed * 2;
            bul.GetComponent<Bullet>()._enemy = gameObject.GetComponent<Enemy>();
            yield return new WaitForSeconds(1 / charactorStatus.at_speed);
        }
    }
}