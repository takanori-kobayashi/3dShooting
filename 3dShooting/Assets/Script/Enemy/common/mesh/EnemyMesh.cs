using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の共通のメッシュの動作
/// </summary>
public class EnemyMesh : MonoBehaviour
{
    /// <summary>
    /// オブジェクトの表示非表示
    /// </summary>
    Renderer m_rend;

    /// <summary>
    /// アルファ値のカウント
    /// </summary>
    float m_AlphaCnt;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの表示非表示
        m_rend = GetComponent<Renderer>();
        //m_rend.enabled = false;

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
        if(m_AlphaCnt <= 1)
        {
            Color color = m_rend.material.color;
            m_AlphaCnt += 0.02f;
            if(1 <= m_AlphaCnt)
            {
                m_AlphaCnt = 1.0f;
            }
            color.a = m_AlphaCnt;
            m_rend.material.color = color;
        }




    }
}
