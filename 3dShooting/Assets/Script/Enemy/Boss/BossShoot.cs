using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボス用の弾発射クラス
/// </summary>
public class BossShoot : MonoBehaviour
{
    /// <summary>
    /// EnemyBulletのゲームオブジェクト
    /// </summary>
    public GameObject bullet;

    /// <summary>
    /// ボスクラス
    /// </summary>
    Boss m_Boss;

    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;

    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    /// <summary>
    /// 発射タイプ
    /// </summary>
    public int m_type;

    /// <summary>
    /// 発射カウント
    /// </summary>
    public int m_fireCnt;

    /// <summary>
    /// インターバルカウント1
    /// </summary>
    private int m_fireIntervalCnt1 = 0;

    /// <summary>
    /// インターバルカウント2
    /// </summary>
    private int m_fireIntervalCnt2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        //親コンポーネント取得
        m_Boss = GetComponent<Boss>();

        m_fireCnt = 0;

        m_fireIntervalCnt1 = 0;
        m_fireIntervalCnt2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        
        // 弾丸の複製
        if (bullet != null && 5 <= transform.position.z && 30 < m_fireIntervalCnt1)
        {
            if (m_Boss.m_return == false && m_fireCnt < 5 && m_fireIntervalCnt2 % 10 == 0)
            {
                GameObject bullets = Instantiate(bullet) as GameObject;

                // 弾丸の位置を調整(Playerの座標+指定y座標)
                bullets.transform.position = transform.position;

                m_fireCnt++;
            }
        }

        if(m_Boss.m_return == true)
        {
            m_fireCnt = 0;
            m_fireIntervalCnt1 = 0;
            m_fireIntervalCnt2 = 0;
        }
        else
        {
            m_fireIntervalCnt1++;
            m_fireIntervalCnt2++;
        }
    }
}
