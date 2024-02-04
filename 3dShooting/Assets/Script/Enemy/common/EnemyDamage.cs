using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の共通のダメージ処理
/// </summary>
public class EnemyDamage : MonoBehaviour
{
    /// <summary>
    /// ヒット時のSE
    /// </summary>
    public AudioClip m_HitSE;

    /// <summary>
    /// AudioSourceクラス
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// ヒットポイント
    /// </summary>
    public int m_HitPoint;

    /// <summary>
    /// エフェクト(ダメージ)
    /// </summary>
    public GameObject m_EffectDamage;

    /// <summary>
    /// エフェクト(撃墜)
    /// </summary>
    public GameObject m_EffectShootDown;

    /// <summary>
    /// 加算スコア
    /// </summary>
    public uint m_AddScore;

    /// <summary>
    /// 打ち返し有無
    /// </summary>
    public bool m_CounterAttack;

    /// <summary>
    /// EnemyBulletのゲームオブジェクト
    /// </summary>
    public GameObject m_bullet;


    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;

    // Start is called before the first frame update
    void Start()
    {
        if(m_HitPoint == 0)
        {
            m_HitPoint = 1;
        }

        m_EnemyApper = GetComponent<EnemyAppear>();

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider other)
    {
        if(m_EnemyApper.m_in == true)
        {
            if (true == tags_tbl.EnemyDamage(other.transform.tag))
            {
                if (0 < m_HitPoint)
                {
                    m_HitPoint--;

                    //爆発エフェクト
                    if (null != m_EffectDamage)
                    {
                        GameObject EffectDamage = Instantiate(m_EffectDamage) as GameObject;

                        //座標
                        EffectDamage.transform.position = transform.position;
                        Destroy(EffectDamage, 1.0f);

                    }


                    //再生
                    if (audioSource != null && m_HitSE != null)
                    {
                        audioSource.PlayOneShot(m_HitSE, 0.2f);
                    }
                }
            }

            //プレイヤーの弾
            if(other.gameObject.tag == "PlayerBullet")
            {
                Object.Destroy(other.gameObject);//弾の削除
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    //音(sound1)を鳴らす
        //    audioSource.PlayOneShot(sound1);
        //}
    }



    private void FixedUpdate()
    {
       
        //破壊された時の処理
        if(m_HitPoint <= 0)
        {

            //爆発エフェクト
            if(null != m_EffectShootDown)
            {
                GameObject EffectShootDown = Instantiate(m_EffectShootDown) as GameObject;

                //座標
                EffectShootDown.transform.position = transform.position;
                Destroy(EffectShootDown, 1.0f);

            }

            // 打ち返し弾の複製
            if (m_bullet != null && 5 <= transform.position.z&&  m_CounterAttack == true)
            {
                GameObject bullets = Instantiate(m_bullet) as GameObject;

                // 弾丸の位置を調整(Playerの座標+指定y座標)
                bullets.transform.position = transform.position;
            }

            GameState.ScoreAdd(m_AddScore);
            Object.Destroy(this.gameObject);//敵の削除
        }
    }
}
