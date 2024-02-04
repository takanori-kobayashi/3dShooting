using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスのダメージ動作
/// </summary>
public class BossDamage : MonoBehaviour
{
    /// <summary>
    /// ダメージSE
    /// </summary>
    public AudioClip sound1;

    /// <summary>
    /// AudioSourceクラス
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// ヒットポイント
    /// </summary>
    /// 
    public int m_HitPoint;

    /// <summary>
    /// エフェクト(撃墜)
    /// </summary>
    public GameObject m_EffectShootDown;

    /// <summary>
    /// エフェクト(ダメージ)
    /// </summary>
    public GameObject m_EffectDamage;

    /// <summary>
    /// 加算スコア
    /// </summary>
    public uint m_AddScore;

    /// <summary>
    /// 死亡フラグ
    /// </summary>
    public bool m_deadFlg { get; private set; }

    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    /// <summary>
    /// ボスの出現クラス
    /// </summary>
    private BossAppear m_BossAppear;

    // Start is called before the first frame update
    void Start()
    {
        m_deadFlg = false;

        if (m_HitPoint == 0)
        {
            m_HitPoint = 1;
        }

        //親コンポーネント取得
        m_root = transform.parent.gameObject;
        m_BossAppear = m_root.GetComponent<BossAppear>();

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //破壊された時の処理
        if (m_HitPoint <= 0 && m_deadFlg == false)
        {

            //爆発エフェクト
            if (null != m_EffectShootDown)
            {
                GameObject EffectShootDown = Instantiate(m_EffectShootDown) as GameObject;

                //座標
                EffectShootDown.transform.position = transform.position;
                Destroy(EffectShootDown, 1.0f);

            }

            m_deadFlg = true;
            GameState.ScoreAdd(m_AddScore);
            Object.Destroy(this.gameObject,3);//敵の削除
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_deadFlg == false && m_BossAppear.m_in == true)
        {
            if (true == tags_tbl.EnemyDamage(other.transform.tag))
            {
                if (0 < m_HitPoint)
                {
                    m_HitPoint--;


                    //ヒットエフェクト
                    if (null != m_EffectDamage)
                    {
                        GameObject EffectDamage = Instantiate(m_EffectDamage) as GameObject;

                        //座標
                        EffectDamage.transform.position = transform.position;
                        Destroy(EffectDamage, 1.0f);

                    }

                    //再生
                    if (audioSource != null && sound1 != null)
                    {
                        audioSource.PlayOneShot(sound1, 0.2f);
                    }

                    //死亡
                    if(m_HitPoint <= 0)
                    {
                        GameState.m_GameState = GameState.GAME_STATE.BOSS_DESTROY;
                    }

                }
            }

            //プレイヤーの弾
            if (other.gameObject.tag == "PlayerBullet")
            {
                Object.Destroy(other.gameObject);//弾の削除
            }
        }
    }
}
