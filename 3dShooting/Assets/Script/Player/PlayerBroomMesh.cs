using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの箒のメッシュの動作処理
/// </summary>
public class PlayerBroomMesh : MonoBehaviour
{
    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    /// <summary>
    /// 親コンポーネント
    /// </summary>
    Player m_Player;

    /// <summary>
    /// オブジェクトの表示非表示
    /// </summary>
    Renderer m_rend;

    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクト取得
        m_root = transform.root.gameObject;
        //親コンポーネント取得
        m_Player = m_root.GetComponent<Player>();

        //オブジェクトの表示非表示
        m_rend = GetComponent<Renderer>();
        m_rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(m_Player.m_PlayerDead == true)
        {
            m_rend.enabled = false;
        }
    }
}
