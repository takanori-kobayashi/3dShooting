using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスパーツの弾ヒット処理
/// </summary>
public class BossPartsHit : MonoBehaviour
{
    /// <summary>
    /// ヒットSE
    /// </summary>
    public AudioClip sound1;

    /// <summary>
    /// AudioSourceクラス
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    /// <summary>
    /// ボス出現クラス
    /// </summary>
    private BossAppear m_BossAppear;

    /// <summary>
    /// エフェクト(ヒット)
    /// </summary>
    public GameObject m_EffectHit;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        //親コンポーネント取得
        m_root = transform.parent.gameObject;
        m_BossAppear = m_root.GetComponent<BossAppear>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (true == tags_tbl.EnemyDamage(other.transform.tag) && m_BossAppear.m_in == true)
        {
            //ヒットエフェクト
            if (null != m_EffectHit)
            {
                GameObject EffectHit = Instantiate(m_EffectHit) as GameObject;

                //座標
                EffectHit.transform.position = transform.position;
                Destroy(EffectHit, 1.0f);

            }

            //再生
            if (audioSource != null && sound1 != null)
            {
                audioSource.PlayOneShot(sound1, 0.2f);
            }

            //プレイヤーの弾
            if (other.gameObject.tag == "PlayerBullet")
            {
                Object.Destroy(other.gameObject);//弾の削除
            }
        }
    }
}
