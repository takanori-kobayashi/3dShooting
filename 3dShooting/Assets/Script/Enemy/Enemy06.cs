using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵6の動作
/// </summary>
public class Enemy06 : MonoBehaviour
{
    /// <summary>
    /// 弾のX軸 Z軸
    /// </summary>
    static float[,] BulletTbl = new float[,]
    {
         {0.05f,0.00f},
        {-0.08f,0.01f},
        {0.04f,0.05f},
        {-0.08f,0.03f},
        {0.07f,0.08f},
        {-0.08f,0.01f},
        {0.05f,0.07f},
        {-0.00f,0.03f},
        {0.03f,0.00f},
        {-0.01f,0.01f},
        {0.04f,0.09f},
        {-0.00f,0.01f},
        {0.03f,0.00f},
        {-0.05f,0.05f},
        {0.06f,0.06f},
        {-0.06f,0.01f},
        {0.03f,0.04f},
        {-0.06f,0.00f},
        {0.08f,0.07f},
        {-0.03f,0.05f},
        {0.07f,0.08f},
        {-0.09f,0.09f},
        {0.01f,0.05f},
        {-0.02f,0.04f},
        {0.02f,0.08f},
        {-0.08f,0.07f},
        {0.09f,0.09f},
        {-0.03f,0.06f},
        {0.02f,0.02f},
        {-0.00f,0.08f},
        {0.00f,0.03f},
        {-0.00f,0.06f},
        {0.09f,0.00f},
        {-0.02f,0.02f},
        {0.06f,0.05f},
        {-0.07f,0.08f},
        {0.02f,0.04f},
        {-0.04f,0.07f},
        {0.09f,0.04f},
        {-0.01f,0.07f},
        {0.03f,0.05f},
        {-0.06f,0.07f},
        {0.03f,0.05f},
        {-0.02f,0.01f},
        {0.08f,0.04f},
        {-0.09f,0.05f},
        {0.03f,0.07f},
        {-0.06f,0.01f},
        {0.00f,0.04f},
        {-0.05f,0.06f},
        {0.09f,0.01f},
        {-0.09f,0.01f},
        {0.03f,0.06f},
        {-0.00f,0.04f},
        {0.06f,0.09f},
        {-0.08f,0.01f},
        {0.05f,0.08f},
        {-0.01f,0.01f},
        {0.04f,0.08f},
        {-0.05f,0.01f},
        {0.04f,0.07f},
        {-0.05f,0.02f},
        {0.07f,0.06f},
        {-0.04f,0.07f},
        {0.03f,0.01f},
        {-0.00f,0.08f},
        {0.06f,0.05f},
        {-0.01f,0.04f},
        {0.09f,0.09f},
        {-0.03f,0.05f},
        {0.03f,0.04f},
        {-0.03f,0.08f},
        {0.02f,0.04f},
        {-0.02f,0.09f},
        {0.05f,0.07f},
        {-0.07f,0.01f},
        {0.03f,0.08f},
        {-0.08f,0.05f},
        {0.09f,0.00f},
        {-0.00f,0.05f},
        {0.01f,0.05f},
        {-0.06f,0.08f},
        {0.01f,0.06f},
        {-0.01f,0.08f},
        {0.07f,0.01f},
        {-0.09f,0.03f},
        {0.03f,0.02f},
        {-0.07f,0.01f},
        {0.07f,0.08f},
        {-0.07f,0.06f},
        {0.01f,0.02f},
        {-0.00f,0.00f},
        {0.08f,0.08f},
        {-0.01f,0.02f},
        {0.00f,0.05f},
        {-0.04f,0.01f},
        {0.06f,0.07f},
        {-0.00f,0.05f},
        {0.02f,0.04f},
        {-0.02f,0.06f},
    };

    /// <summary>
    /// 弾の発射数カウント
    /// </summary>
    public byte m_BulletTblCnt;

    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;

    /// <summary>
    /// Enemy07tのゲームオブジェクト
    /// </summary>
    public GameObject m_Enemy07;

    /// <summary>
    /// 弾丸発射点 
    /// </summary>
    public Transform muzzle;

    /// <summary>
    /// 弾丸の速度 
    /// </summary>
    public float m_speed = 1500;

    /// <summary>
    /// インターバルのカウント
    /// </summary>
    public int m_fireInterval;

    // Start is called before the first frame update
    void Start()
    {
        m_fireInterval = 0;

        if (BulletTbl.Length <= m_BulletTblCnt)
        {
            m_BulletTblCnt = 0;
        }

        m_EnemyApper = GetComponent<EnemyAppear>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {


        if (m_EnemyApper.m_in == false)
        {
            return;
        }

        //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollSpeed);

        if (10 <= m_fireInterval)
        {
            // 弾丸の複製
            GameObject bullets = Instantiate(m_Enemy07) as GameObject;

            Vector3 force;

            force = (new Vector3(BulletTbl[m_BulletTblCnt, 0], 0.3f, BulletTbl[m_BulletTblCnt, 0])) * m_speed;

            if(m_BulletTblCnt < BulletTbl.Length)
            {
                m_BulletTblCnt++;
            }
            else
            {
                m_BulletTblCnt = 0;
            }

            // Rigidbodyに力を加えて発射
             bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾の位置を調整(オブジェクトの座標+指定y座標)
            bullets.transform.position = transform.position;

            m_fireInterval = 0;
        }
        else
        {
            m_fireInterval++;
        }

    }
}
