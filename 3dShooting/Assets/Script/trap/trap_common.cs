using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// トラップの共通動作
/// </summary>
public class trap_common : MonoBehaviour
{
    static readonly float DEFAULT_APPEAR_Z = 40;
    static readonly float DEFAULT_DISAPPEAR_Z = -4;

    /// <summary>
    /// オブジェクトの表示
    /// </summary>
    Renderer m_rend;

    /// <summary>
    /// 子オブジェクトの表示
    /// </summary>
    Renderer[] m_rendChi = new Renderer[10];

    public bool m_in { get; private set; }

    float m_AlphaCount;

    /// <summary>
    /// 出現位置
    /// </summary>
    public float m_Appear_z;


    /// <summary>
    /// トラップがスクロールで消える座標
    /// </summary>
    public float m_disappear_z;

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

        for (int i = 0; i < transform.childCount; i++)
        {
            //transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            m_rendChi[i] = transform.GetChild(i).GetComponent<Renderer>();
            m_rendChi[i].enabled = false;

            //オブジェクトの透明
            m_rendChi[i].material.color = color;
        }



        //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollCnt);

        //出現座標(0の時デフォルト値設定)
        if (m_Appear_z == 0)
        {
            m_Appear_z = DEFAULT_APPEAR_Z;
        }

        //消失座標(0の時デフォルト値設定)
        if (m_disappear_z == 0)
        {
            m_disappear_z = DEFAULT_DISAPPEAR_Z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ///出現前
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

                for (int i = 0; i < transform.childCount; i++)
                {
                    m_rendChi[i].enabled = true;
                }
            }

            if (m_rend.enabled == true)
            {
                Color color = m_rend.material.color;
                color.a = m_AlphaCount;
                m_AlphaCount += 0.05f;
                m_rend.material.color = color;

                for (int i = 0; i < transform.childCount; i++)
                {
                    m_rendChi[i].material.color = color;
                }

                if (1 <= m_AlphaCount)
                {
                    m_in = true;
                }

            }

        }

        //出現後
        else
        {
            if (transform.position.z <= m_disappear_z)
            {
                Object.Destroy(this.gameObject);//敵の削除
            }

        }
    }
}
