using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵1の動作
/// </summary>
public class Enemy01 : MonoBehaviour
{
    /// <summary>
    /// 敵の出現
    /// </summary>
    EnemyAppear m_EnemyApper;


    // Start is called before the first frame update
    void Start()
    {
        m_EnemyApper = GetComponent<EnemyAppear>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void FixedUpdate()
    {
        if(m_EnemyApper.m_in == false)
        {
            return;
        }

        //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollSpeed);

    }
}
