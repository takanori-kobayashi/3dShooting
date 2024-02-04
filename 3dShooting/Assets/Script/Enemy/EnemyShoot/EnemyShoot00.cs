using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾発射パターン00(時期に一定時間で弾を発射してくる)
/// </summary>
public class EnemyShoot00 : MonoBehaviour
{
    /// <summary>
    /// EnemyBulletのゲームオブジェクト
    /// </summary>
    public GameObject bullet;

    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;

    /// <summary>
    /// 発射タイプ
    /// </summary>
    public int m_type;

    /// <summary>
    /// インターバルのカウント
    /// </summary>
    public int m_fireInterval;
    public int m_fireInterval2;
    public int m_fireInterval3;

    /// <summary>
    /// インターバルカウント
    /// </summary>   
    private int m_fireIntervalCnt = 0;

    /// <summary>
    /// 発射フラグ
    /// </summary>
    private bool m_fireFlg;

    // Start is called before the first frame update
    void Start()
    {
        m_EnemyApper = GetComponent<EnemyAppear>();

        if (m_fireInterval == 0)
        {
            m_fireInterval = 360;
        }

        if (m_fireInterval3 == 0)
        {
            m_fireInterval3 = 10;
        }

        m_fireFlg = false;

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

        //弾の発射種類
        switch (m_type)
        {
            case 0:
                ShootType00();
                break;
            case 1:
                ShootType01();
                break;
            case 2:
                ShootType02();
                break;
            default:
                ShootType00();
                break;
        }

    }

    /// <summary>
    /// 一定時間に一回の弾を発射
    /// </summary>
    private void ShootType00()
    {
        if (m_fireInterval <= m_fireIntervalCnt)
        {
            // 弾丸の複製
            if (bullet != null && 5 <= transform.position.z)
            {
                GameObject bullets = Instantiate(bullet) as GameObject;

                // 弾丸の位置を調整(Playerの座標+指定y座標)
                bullets.transform.position = transform.position;
            }
            m_fireIntervalCnt = 0;
        }
        else
        {
            m_fireIntervalCnt++;
        }
    }

    /// <summary>
    /// 一定時間たったら一定時間弾を発射する
    /// </summary>
    private void ShootType01()
    {
        if (m_fireFlg == false)
        {
            if (m_fireInterval <= m_fireIntervalCnt)
            {
                m_fireFlg = true;
                m_fireIntervalCnt = 0;
            }
            else
            {
                m_fireIntervalCnt++;
            }

        }
        else if (m_fireFlg == true)
        {
            if (m_fireInterval2 <= m_fireIntervalCnt)
            {
                m_fireFlg = false;
                m_fireIntervalCnt = 0;
            }
            else if (0 == m_fireIntervalCnt % m_fireInterval3)
            {
                // 弾丸の複製
                if (bullet != null && 5 <= transform.position.z)
                {
                    GameObject bullets = Instantiate(bullet) as GameObject;

                    // 弾丸の位置を調整(Playerの座標+指定y座標)
                    bullets.transform.position = transform.position;
                }
            }
            m_fireIntervalCnt++;


        }
        else
        {
            m_fireIntervalCnt++;
        }
    }

    /// <summary>
    /// 一定時間たったら一回だけ弾を発射
    /// </summary>
    private void ShootType02()
    {
        if (m_fireInterval == m_fireIntervalCnt)
        {
            // 弾丸の複製
            if (bullet != null && 5 <= transform.position.z)
            {
                GameObject bullets = Instantiate(bullet) as GameObject;

                // 弾丸の位置を調整(Playerの座標+指定y座標)
                bullets.transform.position = transform.position;
            }
            m_fireIntervalCnt++;
        }
        else if(m_fireIntervalCnt <= m_fireInterval)
        {
            m_fireIntervalCnt++;
        }
    }
}