using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵5の動作
/// </summary>
public class Enemy05 : MonoBehaviour
{
    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;

    /// <summary>
    /// 移動スピード
    /// </summary>
    private float m_Speed;

    /// <summary>
    /// 待機時間
    /// </summary>
    private int m_WaitTime;

    private readonly int WAIT_TIME = 300;

    /// <summary>
    /// 反転フラグ
    /// </summary>
    private bool m_return;


    // Start is called before the first frame update
    void Start()
    {
        m_EnemyApper = GetComponent<EnemyAppear>();

        if (m_Speed == 0)
        {
            m_Speed = -0.8f;
        }
        else if (0 < m_Speed)
        {
            m_Speed *= -1;
        }

        m_WaitTime = 0;

        m_return = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (m_EnemyApper.m_in == false)
        {
            return;
        }

        if (transform.position.z < 10)
        {
            m_return = true;
        }

        if (m_return == true)
        {
            if (m_WaitTime < WAIT_TIME)
            {
                m_WaitTime++;
                m_Speed = 0.0f;

            }
            else
            {
                m_Speed = 1.0f;
            }

            //反転時に画面外に移動したら削除
            if (40 <= transform.position.z)
            {
                Object.Destroy(this.gameObject);//敵の削除
            }

        }

        transform.Translate(0f, 0f, m_Speed);
    }
}
