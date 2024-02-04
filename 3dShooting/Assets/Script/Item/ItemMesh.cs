using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムのメッシュの動作処理
/// </summary>
public class ItemMesh : MonoBehaviour
{
    /// <summary>
    /// オブジェクトの表示非表示
    /// </summary>
    Renderer m_rend;

    /// <summary>
    /// アルファ値
    /// </summary>
    float m_AlphaCnt;

    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    // Start is called before the first frame update
    void Start()
    {
        //親コンポーネント取得
        m_root = transform.parent.gameObject;

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
        //40より下の座標なら表示
        if (m_root.transform.position.z < 40)
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
        }
    }
}
