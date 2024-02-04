using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスの本体のメッシュの動作
/// </summary>
public class BossBodyMesh : MonoBehaviour
{
    /// <summary>
    /// ボスのオブジェクト
    /// </summary>
    public GameObject m_BossObj;

    /// <summary>
    /// 敵の出現
    /// </summary>
    BossAppear m_BossAppear;

    /// <summary>
    /// オブジェクトの表示非表示
    /// </summary>
    Renderer m_rend;

    /// <summary>
    /// アルファ値
    /// </summary>
    float m_AlphaCnt;

    // Start is called before the first frame update
    void Start()
    {
        if (m_BossObj != null)
        {
            m_BossAppear = m_BossObj.GetComponent<BossAppear>();
        }

        //オブジェクトの表示非表示
        m_rend = GetComponent<Renderer>();
        m_rend.enabled = false;

        //オブジェクトの透明
        Color color = m_rend.material.color;
        color.a = 0.0f;
        m_rend.material.color = color;

        m_AlphaCnt = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (m_BossAppear.m_in == true)
        {
            if (m_AlphaCnt <= 1)
            {
                Color color = m_rend.material.color;
                m_AlphaCnt += 0.02f;
                if (1 <= m_AlphaCnt)
                {
                    m_AlphaCnt = 1.0f;
                }
                color.a = m_AlphaCnt;
                m_rend.material.color = color;
            }

            m_rend.enabled = true;
        }
    }
}
