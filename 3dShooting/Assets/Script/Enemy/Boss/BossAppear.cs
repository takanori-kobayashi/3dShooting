using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスの出現動作
/// </summary>
public class BossAppear : MonoBehaviour
{
    /// <summary>
    /// デフォルトの出現座標
    /// </summary>
    static readonly float DEFAULT_APPEAR_Z = 40;

    /// <summary>
    /// 出現フラグ
    /// </summary>
    public bool m_in { get; private set; }

    /// <summary>
    /// 出現位置
    /// </summary>
    public float m_Appear_z;


    // Start is called before the first frame update
    void Start()
    {
        m_in = false;

        //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollCnt);

        if (m_Appear_z == 0)
        {
            m_Appear_z = DEFAULT_APPEAR_Z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (m_in == false)
        {
            //画面外からの移動
            if (m_Appear_z < transform.position.z)
            {
                transform.Translate(0f, 0f, -StageScrollCount.m_ScrollSpeed);
            }
            else
            {
                m_in = true;
            }

        }
    }
}
