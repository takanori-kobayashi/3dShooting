using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスのメッシュの動作
/// </summary>
public class BossMesh : MonoBehaviour
{

    /// <summary>
    /// ボスのオブジェクト
    /// </summary>
    public GameObject m_BossObj;

    /// <summary>
    /// 敵の出現
    /// </summary>
    Boss m_Boss;

    /// <summary>
    /// オブジェクトの表示非表示
    /// </summary>
    Renderer m_rend;

    /// <summary>
    /// アルファ値
    /// </summary>
    float m_AlphaCnt;

    public Vector3 lastPostion;

    // Start is called before the first frame update
    void Start()
    {

        if (m_BossObj != null)
        {
            m_Boss = m_BossObj.GetComponent<Boss>();
        }

        lastPostion = m_Boss.transform.position;

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
        //弾丸の向きを時機の向きに合わせる
        Vector3 diff = m_Boss.transform.position - lastPostion;   //前回からどこに進んだかをベクトルで取得
        lastPostion = transform.position;  //前回のPositionの更新

        if (diff != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }


        if(m_Boss.m_in == true)
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
