using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージのスクロールのカウント
/// </summary>
public class StageScrollCount : MonoBehaviour
{
    /// <summary>
    /// スクロールカウントのオフセット値(デバッグ時は値を変える)
    /// </summary>
    private const float SCROLL_CNT_OFFSET = 0;
    //private const float SCROLL_CNT_OFFSET = 750; //Area4
    //private const float SCROLL_CNT_OFFSET = 1000; //Area5
    //private const float SCROLL_CNT_OFFSET = 1250; //Area6
    //private const float SCROLL_CNT_OFFSET = 1500; //Area6
 
    /// <summary>
    /// スクロールのスピード
    /// </summary>
    private readonly float SCROLL_SPEED_DEFULT = 0.2f;

    /// <summary>
    /// スクロールのスピードLV2
    /// </summary>
    private readonly float SCROLL_SPEED_LEVEL2 = 0.4f;

    /// <summary>
    /// スクロールのカウント
    /// </summary>
    public static float m_ScrollCnt { get; private set; } = SCROLL_CNT_OFFSET;

    /// <summary>
    /// スクロールのスピード
    /// </summary>
    public static float m_ScrollSpeed { get; private set; } = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        m_ScrollSpeed = SCROLL_SPEED_DEFULT;
        m_ScrollCnt = SCROLL_CNT_OFFSET;

    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public static void init()
    {
        m_ScrollCnt = SCROLL_CNT_OFFSET;
    }

    private void FixedUpdate()
    {
        //スクロールスピードの加算
        m_ScrollCnt += m_ScrollSpeed;

        //ボス戦時のスクロールスピード
        if (1600 <= m_ScrollCnt)
        {
            if (m_ScrollSpeed < SCROLL_SPEED_LEVEL2)
            {
                m_ScrollSpeed += 0.0001f;
            }
            else
            {
                m_ScrollSpeed = SCROLL_SPEED_LEVEL2;
            }

        }
    }
}
