using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの地面接触時の煙エフェクトの処理
/// </summary>
public class PlayerSmokeEffect : MonoBehaviour
{
    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

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
        m_Player = m_root.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //地面に近い場合は砂埃のエフェクトを表示
        if (m_root.transform.position.y <= -2.3f && m_Player.m_PlayerDead == false)
        {
            m_particle.Play();
        }
        else
        {
            m_particle.Stop();
        }
    }
}
