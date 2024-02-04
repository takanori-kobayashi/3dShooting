using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの弾発射エフェクト
/// </summary>
public class PlayerShootingEffect : MonoBehaviour
{
    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    /// <summary>
    /// プレイヤーの弾発射クラス
    /// </summary>
    private PlayerShooting00 m_PlayerShooting00;

    /// <summary>
    /// プレイヤーのクラス
    /// </summary>
    private Player m_Player;

    /// <summary>
    /// パーティクルコンポーネント
    /// </summary>
    private ParticleSystem m_particle;

    // Start is called before the first frame update
    void Start()
    {
        //パーティクルコンポーネント取得
        m_particle = GetComponent<ParticleSystem>();

        //親オブジェクト取得
        m_root = transform.parent.gameObject;
        m_PlayerShooting00 = m_root.GetComponent<PlayerShooting00>();
        m_Player = m_root.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(m_PlayerShooting00.m_fire1_flg == true && m_Player.m_PlayerDead == false)
        {
            m_particle.Play();
        }
        else
        {
            m_particle.Stop();
        }
    }
}
