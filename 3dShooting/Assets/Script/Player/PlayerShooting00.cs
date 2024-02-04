using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの弾発射処理
/// </summary>
public class PlayerShooting00 : MonoBehaviour
{
    /// <summary>
    /// bulletのゲームオブジェクト
    /// </summary>
    public GameObject bullet;

    /// <summary>
    /// エフェクト(発射)
    /// </summary>
    public GameObject m_EffectFire;

    /// <summary>
    /// 弾丸発射点 
    /// </summary>
    public Transform muzzle;

    /// <summary>
    /// 弾丸の速度 
    /// </summary>
    public float speed = 1500;

    /// <summary>
    /// fire1キーが押下状態
    /// </summary>
    private float m_fire1 = 0.0f;

    /// <summary>
    /// 弾の発射のインターバル
    /// </summary>
    private int m_fireInterval = 0;

    /// <summary>
    /// 弾を打った状態
    /// </summary>
    public bool m_fire1_flg { get; private set; }

    /// <summary>
    /// Rigidbodyのコンポーネント
    /// </summary>
    private Rigidbody rBody;

    /// <summary>
    /// Playerのゲームオブジェクト
    /// </summary>
    GameObject refObj;

    /// <summary>
    /// Playerのコンポーネント
    /// </summary>
    Player player;

    /// <summary>
    /// サウンドファイル
    /// </summary>
    public AudioClip sound1;

    /// <summary>
    /// AudioSourceのコンポーネント
    /// </summary>
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10000;

        audioSource = GetComponent<AudioSource>();

        rBody = this.GetComponent<Rigidbody>();
        rBody.useGravity = false; //最初にrigidBodyの重力を使わなくする

        //プレイヤーのオブジェクト取得
        refObj = GameObject.Find("Player");
        player = refObj.GetComponent<Player>();

        m_fire1_flg = false;

        m_fireInterval = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_fire1 = Input.GetAxisRaw("Fire1");
    }

    void FixedUpdate()
    {
        //死亡時は弾を打たない
        if(player.m_PlayerDead == true)
        {
            return;
        }

        if (1.0f == m_fire1 && 0 == m_fireInterval % 4)
        {
            m_fire1_flg = true;


            var toRot = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;

            Vector3 force;

            force = (this.gameObject.transform.forward + new Vector3(0.0f, 0.0f, 0.0f)) * speed;

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整(Playerの座標+指定y座標)
            bullets.transform.position = muzzle.position + new Vector3(0.0f, 0.0f, 0.0f);

            //弾丸の向きを時機の向きに合わせる
            bullets.transform.rotation = Quaternion.LookRotation(transform.forward);

            //サウンドの再生
            if (sound1 != null)
            {
                AudioSource.PlayClipAtPoint(sound1, gameObject.transform.position);
            }
                
        }

        else if (0.0f == m_fire1)
        {
            m_fire1_flg = false;
            m_fireInterval = 0;
        }

        m_fireInterval++;


    }
}
