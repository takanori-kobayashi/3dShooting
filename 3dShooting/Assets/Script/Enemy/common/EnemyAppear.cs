using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の共通の出現処理
/// </summary>
public class EnemyAppear : MonoBehaviour
{
    /// <summary>
    /// デフォルトの出現位置
    /// </summary>
    static readonly float DEFAULT_APPEAR_Z = 40;

    /// <summary>
    /// オブジェクトの表示非表示
    /// </summary>
    Renderer m_rend;

    /// <summary>
    /// 敵の出現フラグ
    /// </summary>
    public bool m_in { get; private set; }

    /// <summary>
    /// アルファ値のカウント
    /// </summary>
    float m_AlphaCount;

    /// <summary>
    /// 出現位置
    /// </summary>
    public float m_Appear_z;

    // Start is called before the first frame update
    void Start()
    {
        m_in = false;
        m_AlphaCount = 0;

        //オブジェクトの表示非表示
        m_rend = GetComponent<Renderer>();
        m_rend.enabled = false;

        //オブジェクトの透明
        Color color = m_rend.material.color;
        color.a = 0.0f;
        m_rend.material.color = color;
 
        //子オブジェクトの表示非表示、オブジェクトの透明
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);

        }


        //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollCnt);

        if (m_Appear_z == 0)
        {
            m_Appear_z = DEFAULT_APPEAR_Z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (m_in == false)
        {
            //画面外からの移動
            if (m_Appear_z < transform.position.z)
            {
                transform.Translate(0f, 0f, -StageScrollCount.m_ScrollSpeed);
            }

            if (transform.position.z <= m_Appear_z)
            {
                m_rend.enabled = true;

                //子オブジェクトの表示
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                    //  m_rendChi[i].enabled = true;
                }
            }

            if (m_rend.enabled == true)
            {
                Color color = m_rend.material.color;
                color.a = m_AlphaCount;
                m_AlphaCount += 0.05f;
                m_rend.material.color = color;

                //子オブジェクトの表示非表示、オブジェクトの透明
                for (int i = 0; i < transform.childCount; i++)
                {
                    //m_rendChi[i].material.color = color;

                }

                if (1 <= m_AlphaCount)
                {
                    m_in = true;
                }

            }

        }

    }
}
