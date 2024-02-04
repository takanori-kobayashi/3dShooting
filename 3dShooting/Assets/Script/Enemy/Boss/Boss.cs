using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスの動作
/// </summary>
public class Boss : MonoBehaviour
{
    /// <summary>
    /// デバッグ文字用
    /// </summary>
    int debug1;

    /// <summary>
    /// デバッグ文字用
    /// </summary>
    int debug2;

    /// <summary>
    /// デバッグ文字用
    /// </summary>
    int debug3;

    /// <summary>
    /// デバッグ文字用
    /// </summary>
    int debug4;

    static readonly float[,] MOVE_TBL =
    {
        // up side
//        {   0.2f,   0.3f },
//        {   0.1f,  -0.4f },
//        {  -0.3f,   0.1f },
//        {   0.1f,   0.1f },
//        {  -0.2f,  -0.3f },
//        {  -0.1f,   0.3f },
//        {   0.3f,  -0.2f },
//        {  -0.4f,   0.2f },
//        {   0.2f,   0.1f },
//        {   0.1f,  -0.3f },
//        {   0.3f,   0.1f },

          {   0.03f,   0.1f },
          {   0.03f,  -0.1f },
          {  -0.03f,   0.1f },
          {   0.03f,  -0.1f },
          {  -0.03f,   0.1f },
          {  -0.03f,  -0.1f },
          {   0.03f,   0.1f },
          {  -0.03f,  -0.1f },
          {   0.03f,   0.1f },
          {   0.03f,  -0.1f },
          {  -0.03f,   0.1f },
          {   0.03f,  -0.1f },
    };

    /// <summary>
    /// ボスの移動参照テーブルインデックス
    /// </summary>
    byte movetbl_index;

    /// <summary>
    /// X座標の履歴
    /// </summary>
    public float[] ox = new float[256];

    /// <summary>
    /// Y座標の履歴
    /// </summary>
    public float[] oy = new float[256];

    /// <summary>
    /// Z座標の履歴
    /// </summary>
    public float[] oz = new float[256];

    /// <summary>
    /// 前回の座標
    /// </summary>
    public Vector3 lastPostion;

    /// <summary>
    /// 前回移動があったかどうか
    /// </summary>
    public bool m_LastMoveFlg { get; private set; }


    /// <summary>
    /// ボスの移動履歴テーブルインデックス
    /// </summary>
    int index;

    /// <summary>
    /// 親オブジェクト
    /// </summary>
    private GameObject m_root;

    /// <summary>
    /// ボスの出現クラス
    /// </summary>
    private BossAppear m_BossAppear;

    /// <summary>
    /// ボスのダメージの状態
    /// </summary>
    BossDamage m_BossDamage;

    /// <summary>
    /// 移動スピード
    /// </summary>
    private float m_Speed;

    /// <summary>
    /// 反転時の上昇スピード
    /// </summary>
    private float m_Up;

    /// <summary>
    /// 横移動時のスピード
    /// </summary>
    private float m_Side;

    /// <summary>
    /// 反転フラグ
    /// </summary>
    public bool m_return { get; private set; }

    /// <summary>
    /// カウンター
    /// </summary>
    private float IntervalCount; //Time.timeだとリセット時ずれるのでの代わりにカウントに
    
    /// <summary>    
    /// カウント値    
    /// </summary>
    private readonly float INTERVAL_COUNT = 0.017f;

    /// <summary>
    /// 死亡判定
    /// </summary>
    public bool m_deadFlg { get; private set; }

    /// <summary>
    /// 出現フラグ
    /// </summary>
    public bool m_in { get; private set; }

    /// <summary>
    /// 出現フラグ
    /// </summary>
    private bool m_AppearanceFlg;

    // Start is called before the first frame update
    void Start()
    {

        m_BossDamage = GetComponent<BossDamage>();

        //親コンポーネント取得
        m_root = transform.parent.gameObject;
        m_BossAppear = m_root.GetComponent<BossAppear>();

        IntervalCount = 0;

        lastPostion = transform.position;

        m_LastMoveFlg = false;

        index = 0;

        movetbl_index = 0;
        ///
        if (m_Speed == 0)
        {
            m_Speed = -0.5f;
        }
        else if (0 < m_Speed)
        {
            m_Speed *= -1;
        }

        m_return = false;

        m_deadFlg = false;

        m_in = false;

        m_AppearanceFlg = false;

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

        m_in = true;

        //ボスが死んだ場合は動作を止める
        if (m_BossDamage.m_deadFlg == true)
        {
            m_deadFlg = true;

            Object.Destroy(this.gameObject);//敵の削除
            return;
        }

        m_LastMoveFlg = false;

        ox[index] = transform.position.x;
        oy[index] = transform.position.y;
        oz[index] = transform.position.z;

        if (index < ox.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
        //transform.Translate(0f, 0f, -StageScrollCount.ScrollSpeed);
        Move();

        if (lastPostion.x != transform.position.x)
        {
            m_LastMoveFlg = true;
        }
        else if (lastPostion.y != transform.position.y)
        {
            m_LastMoveFlg = true;
        }
        else if (lastPostion.z != transform.position.z)
        {
            m_LastMoveFlg = true;
        }

        lastPostion = transform.position;
    }

    private void Move()
    {
        IntervalCount += INTERVAL_COUNT;

        if (transform.position.z < 10 && m_return == false)
        {
            m_return = true;

            m_AppearanceFlg = true;

            if (movetbl_index < MOVE_TBL.GetLength(0) - 1)
            {

                movetbl_index++;
            }
            else
            {
                movetbl_index = 0;
            }
        }
        
        else if(40 <= transform.position.z && m_return == true)
        {
            m_return = false;
            if (movetbl_index < MOVE_TBL.GetLength(0) - 1)
            {
                movetbl_index++;
            }
            else
            {
                movetbl_index = 0;
            }
        }

        if (m_return == true)
        {
            m_Up = MOVE_TBL[movetbl_index, 0];
            m_Side = MOVE_TBL[movetbl_index, 1];

            if (m_Speed < 0.5f)
            {
                m_Speed += 0.02f;
            }



            //反転時に画面外に移動したら削除
            if (40 <= transform.position.z)
            {
                m_return = false;
                m_Speed *= -1;
                //Object.Destroy(this.gameObject);//敵の削除
            }

        }

        else
        {
            if (m_AppearanceFlg == false)
            {
                m_Up = -0.5f;
            }
            else
            {
                m_Up = MOVE_TBL[movetbl_index, 0];
            }
            m_Side = MOVE_TBL[movetbl_index, 1];

            if (-0.5f < m_Speed)
            {
                m_Speed -= 0.02f;

            }
            //else
            //{
             //   m_Up = 0.0f;
            //}

        }

        if( (5 <= transform.position.x && 0 <= m_Side ) ||
            (transform.position.x <= -5 && m_Side <= 0))
        {
            m_Side = 0;
        }

        if ((1.5 <= transform.position.y && 0 <= m_Up) ||
            (transform.position.y <= -1.5 && m_Up <= 0))
        {
            m_Up = 0;
        }

        transform.Translate(m_Side, m_Up, m_Speed);
    }
}