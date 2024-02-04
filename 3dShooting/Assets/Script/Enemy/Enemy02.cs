using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵2の動作
/// </summary>
public class Enemy02 : MonoBehaviour
{
    /// <summary>
    /// Rigidbodyのコンポーネント
    /// </summary>
    Rigidbody m_rb;

    /// <summary>
    /// 最大ジャンプ力
    /// </summary>
    public float m_MaxJumpPower = 0.0f;

    /// <summary>
    /// 最低ジャンプ力
    /// </summary>
    private const float m_MinJumpPower = -100;

    /// <summary>
    /// ジャンプ力
    /// </summary>
    private float m_JumpPower = 7.0f;

    /// <summary>
    /// スピード
    /// </summary>
    public float m_Speed;

    /// <summary>
    /// ジャンプ判定フラグ
    /// </summary>
    private bool m_jumpFlg;

    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;

    /// <summary>
    /// デバッグ表示
    /// </summary>
    int debug1;

    // Start is called before the first frame update
    void Start()
    {
        m_jumpFlg = false;
        m_rb = GetComponent<Rigidbody>();

        m_EnemyApper = GetComponent<EnemyAppear>();

        if (m_MaxJumpPower == 0)
        {
            m_MaxJumpPower = 20.0f;
        }

        if(m_Speed == 0)
        {
            m_Speed = 5.0f;
        }



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {

        m_jumpFlg = false;

        m_JumpPower = m_MaxJumpPower;
    }


    void FixedUpdate()
    {

        if (m_EnemyApper.m_in == false)
        {
            return;
        }

        //ジャンプ
        if (!m_jumpFlg)
        {
            m_jumpFlg = true;
        }

        if(m_MinJumpPower <= m_JumpPower)
        { 
            --m_JumpPower;
        }

        m_rb.velocity = new Vector3(0,1.0f,0.0f) * m_JumpPower + new Vector3(0, 0.0f, -1.0f) * m_Speed;


    }
}
