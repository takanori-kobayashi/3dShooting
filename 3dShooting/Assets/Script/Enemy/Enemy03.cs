using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵3の動作
/// </summary>
public class Enemy03 : MonoBehaviour
{

    /// <summary>
    /// カウンター
    /// </summary>
    private float IntervalCount; //Time.timeだとリセット時リフトがずれるのでの代わりにカウントに

    /// <summary>
    /// x軸の移動距離
    /// </summary>
    public float distance_x = 0.0f;

    /// <summary>
    /// y軸の移動距離
    /// </summary>
    public float distance_y = 0.0f;

    /// <summary>
    /// z軸の移動距離
    /// </summary>
    public float distance_z = 0.0f;

    /// <summary>
    /// x軸の移動許可
    /// </summary>
    public bool move_x = false;

    /// <summary>
    /// y軸の移動許可
    /// </summary>
    public bool move_y = false;

    /// <summary>
    /// z軸の移動許可
    /// </summary>
    public bool move_z = false;

    /// <summary>
    /// リフトの最初の位置
    /// </summary>
    private Vector3 origin;

    /// <summary>
    /// 弾の座標x
    /// </summary>
    public float m_x;

    /// <summary>
    /// 弾の座標y
    /// </summary>
    public float m_y;

    /// <summary>
    /// 回転中心の座標x
    /// </summary>
    public float m_cx;

    /// <summary>
    /// 回転中心の座標y
    /// </summary>
    public float m_cy;

    /// <summary>
    /// 弾の速度x
    /// </summary>
    public float m_vx;

    /// <summary>
    /// 弾の速度y
    /// </summary>
    public float m_vy;

    /// <summary>
    /// 半径
    /// </summary>
    public float m_r;

    /// <summary>
    /// 角度(ラジアン)
    /// </summary>
    public float m_theta;

    /// <summary>
    /// 一回の移動で変化する角度(ラジアン)
    /// </summary>
    public float m_omega;

    /// <summary>
    /// Zのスピード
    /// </summary>
    public float m_Zspeed;

    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;


    // Start is called before the first frame update
    void Start()
    {
        var tmp = GetComponent<Rigidbody>().position;
        origin = tmp;

        m_EnemyApper = GetComponent<EnemyAppear>();


        if (m_omega == 0)
        {
            m_omega = 0.05f;
        }

        if (m_r == 0)
        {
            m_r = 5.0f;
        }
        m_cx = 0;
        m_cy = 0;

        if (m_Zspeed == 0)
        {
            m_Zspeed = -0.05f;
        }
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


        m_theta += m_omega;

        m_x = m_cx + m_r * Mathf.Cos(m_theta);
        m_y = m_cy + m_r * Mathf.Sin(m_theta);

        m_vx = -m_r * m_omega * Mathf.Sin(m_theta);
        m_vy = m_r * m_omega * Mathf.Cos(m_theta);

        transform.Translate(m_vx, m_vy, m_Zspeed);
        
    }
}
