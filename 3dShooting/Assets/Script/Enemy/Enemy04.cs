using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵4の動作
/// </summary>
public class Enemy04 : MonoBehaviour
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
    /// 反転時の上昇スピード
    /// </summary>
    private float m_Up;

    /// <summary>
    /// 反転フラグ
    /// </summary>
    public bool m_return { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        m_EnemyApper = GetComponent<EnemyAppear>();

        if (m_Speed == 0)
        {
            m_Speed = -0.5f;
        }
        else if(0 < m_Speed)
        {
            m_Speed *= -1;
        }

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

        if(transform.position.z < 10)
        {
            m_return = true;
        }

        if (m_return == true)
        {
            if (m_Speed < 0.5f)
            {
                m_Speed += 0.02f;
                m_Up = 0.08f;
            }
            else
            {
                m_Up = 0.0f;
            }



            //反転時に画面外に移動したら削除
            if (40 <= transform.position.z)
            {
                Object.Destroy(this.gameObject);//敵の削除
            }

        }

        transform.Translate(0f, m_Up, m_Speed);
    }
}
