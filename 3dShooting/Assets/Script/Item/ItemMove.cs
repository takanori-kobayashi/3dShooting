using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの動作処理
/// </summary>
public class ItemMove : MonoBehaviour
{
    /// <summary>
    /// アイテムの出現位置(デフォルト)
    /// </summary>
    static readonly float DEFAULT_APPEAR_Z = 40;

    /// <summary>
    /// レンダラークラス
    /// </summary>
    Renderer m_rend;

    /// <summary>
    /// 出現フラグ
    /// </summary>
    public bool m_in { get; private set; }

    /// <summary>
    /// アルファ地のカウント
    /// </summary>
    float m_AlphaCount;

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    private GameObject m_Player;
    
    /// <summary>
    /// 出現位置
    /// </summary>
    public float m_Appear_z;

    int debug4;

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

        m_Player = GameObject.Find("Player");

        //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollCnt);

        if (m_Appear_z == 0)
        {
            m_Appear_z = DEFAULT_APPEAR_Z;
        }

        debug4 = DebugText.AddText("", 500, 450, 100, 100);
    }

    void OnTriggerEnter(Collider other)
    {
        if (true == tags_tbl.ItemPlayertouch(other.transform.tag))
        {
            Object.Destroy(this.gameObject);
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
            }

            if (m_rend.enabled == true)
            {
                Color color = m_rend.material.color;
                color.a = m_AlphaCount;
                m_AlphaCount += 0.05f;
                m_rend.material.color = color;

                if (1 <= m_AlphaCount)
                {
                    m_in = true;
                }

            }

        }

        else
        {

            float add_x = 0.0f;
            float add_y = 0.0f;

            //アイテムがプレイヤーに吸い込まれる動作
            if (m_Player != null)
            {
                float dis = Vector3.Distance(m_Player.transform.position, transform.position);

                if (dis <= 2)
                {
                    if (m_Player.transform.position.x <= transform.position.x)
                    {
                        add_x = -0.1f;
                    }
                    else
                    {
                        add_x = 0.1f;
                    }

                    if (m_Player.transform.position.y <= transform.position.y)
                    {
                        add_y = -0.1f;
                    }
                    else
                    {
                        add_y = 0.1f;
                    }
                }

               // DebugText.SetText("" + dis, 500, 400, 100, 50, debug4);
            }

            transform.Translate(add_x, add_y, -StageScrollCount.m_ScrollSpeed);


        }

    }
}
