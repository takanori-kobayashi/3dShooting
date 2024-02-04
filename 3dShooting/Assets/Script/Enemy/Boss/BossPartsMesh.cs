using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスパーツのメッシュの動作
/// </summary>
public class BossPartsMesh : MonoBehaviour
{

    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    /// <summary>
    /// ボス出現クラス
    /// </summary>
    private BossAppear m_BossAppear;

    /// <summary>
    /// 前のパーツのオブジェクト
    /// </summary>
    public GameObject m_BeforePartsObj;

    /// <summary>
    /// 前回(前フレーム)の位置
    /// </summary>
    public Vector3 lastPostion;

    // Start is called before the first frame update
    void Start()
    {
        lastPostion = m_BeforePartsObj.transform.position;

        //親コンポーネント取得
        m_root = transform.parent.gameObject;
        m_BossAppear = m_root.GetComponent<BossAppear>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(m_BossAppear.m_in == false)
        {
            return;
        }

        if (m_BeforePartsObj != null)
        {
            Vector3 diff = m_BeforePartsObj.transform.position - lastPostion;   //前回からどこに進んだかをベクトルで取得

            if (diff != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
            }
        }

        lastPostion = transform.position;  //前回のPositionの更新
    }
}
