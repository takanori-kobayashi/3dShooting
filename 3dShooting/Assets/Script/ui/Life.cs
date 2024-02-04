using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// (UI)ライフの表示
/// </summary>
public class Life : MonoBehaviour
{
    /// <summary>
    /// ライフゲージ(画像オブジェクト)
    /// </summary>
    public GameObject[] m_lifegauge;

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    public GameObject m_PlayerObj;

    /// <summary>
    /// プレイヤークラス
    /// </summary>
    private Player m_Player;

    /// <summary>
    /// イメージクラス
    /// </summary>
    private Image[] m_imgae;

    /// <summary>
    /// ライフの色(R)
    /// </summary>
    private float m_lifecR;

    /// <summary>
    /// ライフの色(G)
    /// </summary>
    private float m_lifecG;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = m_PlayerObj.GetComponent<Player>();

        m_imgae = new Image[m_lifegauge.Length];

        for (int i = 0; i < m_lifegauge.Length; i++)
        {
            m_imgae[i] = m_lifegauge[i].GetComponent<Image>();
        }

        m_lifecR = 0;
        m_lifecG = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        for (int i = 0; i < m_lifegauge.Length; i++)
        {
            if (i < m_Player.m_PlayerLife)
            {
                m_lifegauge[i].SetActive(true);
            }
            else
            {
                m_lifegauge[i].SetActive(false);
            }

            //ライフゲージの色
            switch(m_Player.m_PlayerLife)
            {
                case 0:
                    m_lifecR = 0;
                    m_lifecG = 0;
                    break;
                case 1:
                    m_lifecR = 1.0f;
                    m_lifecG = 0.1f;
                    break;
                case 2:
                    m_lifecR = 1.0f;
                    m_lifecG = 0.3f;
                    break;
                case 3:
                    m_lifecR = 1.0f;
                    m_lifecG = 0.9f;
                    break;
                case 4:
                    m_lifecR = 0.1f;
                    m_lifecG = 0.8f;
                    break;
                case 5:
                    m_lifecR = 0;
                    m_lifecG = 1.0f;
                    break;
                default:
                    m_lifecR = 0;
                    m_lifecG = 0;
                    break;
            }

            m_imgae[i].color = new Color(m_lifecR, m_lifecG, 0);
        }


    }
}
