using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのメッシュの動作処理
/// </summary>
public class PlayerWizardMesh : MonoBehaviour
{
    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    /// <summary>
    /// 親のプレイヤーコンポーネント
    /// </summary>
    Player m_Player;

    /// <summary>
    /// オブジェクトの表示非表示
    /// </summary>
    Renderer m_Rend;

    /// <summary>
    /// メッシュの色
    /// </summary>
    Color m_Color;

    /// <summary>
    /// オブジェクトのデフォルトの色保持
    /// </summary>
    Color m_DefultColor;

    /// <summary>
    /// 無敵時間の点滅カウント
    /// </summary>
    float m_ColorCnt;

    /// <summary>
    /// 無敵時間のカウントフラグ
    /// </summary>
    bool m_ColorCntSw;

    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクト取得
        m_root = transform.root.gameObject;
        //親コンポーネント取得
        m_Player = m_root.GetComponent<Player>();

        //オブジェクトの表示非表示
        m_Rend = GetComponent<Renderer>();
        m_Rend.enabled = true;

        //オブジェクトの透明
        m_DefultColor = m_Rend.material.color;
        m_Color = m_Rend.material.color;

        m_ColorCnt = 0;
        m_ColorCntSw = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (m_Player.m_PlayerDead == true)
        {
            m_Rend.enabled = false;
        }

        if(m_Player.m_NoDamageFlg == true)
        {
            m_Color.r = m_ColorCnt;
            m_Color.g = m_ColorCnt;
            m_Color.b = m_ColorCnt;
            m_Rend.material.color = m_Color;

            //点滅処理
            if (1.0f <= m_ColorCnt)
            {
                m_ColorCntSw = true;
            }
            else if(m_ColorCnt <= 0.0f)
            {
                m_ColorCntSw = false;
            }

            if(m_ColorCntSw == false)
            {
                m_ColorCnt += 0.1f;
            }
            else
            {
                m_ColorCnt -= 0.1f;
            }
        }
        else
        {
            m_Rend.material.color = m_DefultColor;
        }

    }
}
