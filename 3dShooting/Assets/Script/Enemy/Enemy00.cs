using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵0の動き
/// </summary>
public class Enemy00 : MonoBehaviour
{
    /// <summary>
    /// カウント値
    /// </summary>
    private readonly float INTERVAL_COUNT = 0.017f;

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
    /// 動き開始
    /// </summary>
    private bool m_start;

    /// <summary>
    /// リフトの最初の位置
    /// </summary>
    private Vector3 origin;

    float add = 0.0f;

    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;

    /// <summary>
    /// ターン時の向き
    /// </summary>
    float m_truen_x = 2;

    // Start is called before the first frame update
    void Start()
    {
        var tmp = GetComponent<Rigidbody>().position;
        origin = tmp;

        m_start = false;

        m_EnemyApper = GetComponent<EnemyAppear>();

        //ターン時の向き
        if (0 < transform.position.x)
        {
            m_truen_x = -2;
        }
        else
        {
            m_truen_x = 2;
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

        if (m_start == false)
        {
            var tmp = GetComponent<Rigidbody>().position;
            origin = tmp;

            m_start = true;
        }

        IntervalCount += INTERVAL_COUNT;

        var x = 0.0f;
        var y = 0.0f;
        var z = 0.0f;



        if (move_x == true)
        {
            x = Mathf.Sin(IntervalCount * 1);
        }
        if (move_y == true)
        {
            y = Mathf.Sin(IntervalCount * 1);
        }
        if (move_z == true)
        {
            z = Mathf.Sin(IntervalCount * 1);
        }

        add += 0.1f;
        x = add;


        x = IntervalCount * m_truen_x;

        Vector3 offset = new Vector3(x, y, z);

        offset.x *= distance_x + 1;
        offset.y *= distance_y;
        offset.z *= distance_z;


        Vector3 pos = transform.position;

        transform.position = origin + offset;

        if (transform.position.z <= -4.0f)
        {
            Object.Destroy(this.gameObject);//敵の削除
        }
    }
}
