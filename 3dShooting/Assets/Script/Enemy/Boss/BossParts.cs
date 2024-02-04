using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスのパーツの動作
/// </summary>
public class BossParts : MonoBehaviour
{
    /// <summary>
    /// ボスのオブジェクト
    /// </summary>
    public GameObject m_BossObj;

    /// <summary>
    /// 前のパーツのオブジェクト
    /// </summary>
    public GameObject m_BeforePartsObj;

    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    private BossAppear m_BossAppear;

    /// <summary>
    /// エフェクト(撃墜)
    /// </summary>
    public GameObject m_EffectShootDown;

    /// <summary>
    /// 敵の出現
    /// </summary>
    Boss m_Boss;

    /// <summary>
    /// パーツのナンバー(1～セット)
    /// </summary>
    public int m_PartsNum;

    /// <summary>
    /// インターバルのカウント
    /// </summary>
    int m_intervalCnt;

    /// <summary>
    /// 動作するまでのインターバルの時間
    /// </summary>
    int m_interval;
    
    /// <summary>
    /// 座標のインデックス
    /// </summary>
    int index;

    /// <summary>
    /// 死んだ後のカウント
    /// </summary>
    int m_deadCount;


    /// <summary>
    /// 加算スコア
    /// </summary>
    public uint m_AddScore;

    // Start is called before the first frame update
    void Start()
    {
        if (m_BossObj != null)
        {
            m_Boss = m_BossObj.GetComponent<Boss>();
        }

        //親コンポーネント取得
        m_root = transform.parent.gameObject;
        m_BossAppear = m_root.GetComponent<BossAppear>();

        m_interval = m_PartsNum * 5;
        index = 0;

        m_deadCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool DeadCheck()
    {
        //死亡
        if (m_Boss.m_deadFlg == true)
        {
            m_deadCount++;

            if (m_PartsNum * 10 <= m_deadCount)
            {

                //爆発エフェクト
                if (null != m_EffectShootDown)
                {
                    GameObject EffectShootDown = Instantiate(m_EffectShootDown) as GameObject;

                    //座標
                    EffectShootDown.transform.position = transform.position;
                    Destroy(EffectShootDown, 1.0f);

                }

                GameState.ScoreAdd(m_AddScore);

                Object.Destroy(this.gameObject);//敵の削除
            }

            return true;
        }

        return false;
    }

    private void FixedUpdate()
    {
        if(DeadCheck() == true)
        {
            return;
        }

        if (m_BossAppear.m_in == false)
        {
            return;
        }

        if (m_Boss.m_LastMoveFlg == true && m_interval <= m_intervalCnt)        
        {
            Vector3 pos = m_Boss.transform.position;
            pos.x = m_Boss.ox[index];    // x座標へ0.01加算
            pos.y = m_Boss.oy[index];    // y座標へ0.01加算
            pos.z = m_Boss.oz[index];    // z座標へ0.01加算

           transform.position = pos;

            if (index < m_Boss.ox.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }


        if (m_intervalCnt < m_interval)
        {
            m_intervalCnt++;
        }
    }
}
