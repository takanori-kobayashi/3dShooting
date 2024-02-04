using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵5のメッシュの動作
/// </summary>
public class Enemy05Mesh : MonoBehaviour
{
    /// <summary>
    /// Playerのゲームオブジェクト
    /// </summary>
    GameObject m_refObj;

    /// <summary>
    /// Playerのコンポーネント
    /// </summary>
    Player m_player;

    /// <summary>
    /// 目的地点
    /// </summary>
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのオブジェクト取得
        m_refObj = GameObject.Find("Player");
        m_player = m_refObj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //プレイヤーの座標取得
        destination = new Vector3(m_player.transform.position.x, m_player.transform.position.y, m_player.transform.position.z);
        //プレイヤーの方向を向く
        transform.LookAt(new Vector3(destination.x, destination.y, destination.z));
    }
}
