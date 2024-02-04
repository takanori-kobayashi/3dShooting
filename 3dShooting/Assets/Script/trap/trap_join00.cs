using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 複合トラップの動作
/// </summary>
public class trap_join00 : MonoBehaviour
{
    /// <summary>
    /// 敵の出現
    /// </summary>
    trap_common m_trap_common;

    /// <summary>
    /// 回転の速さ
    /// </summary>
    public float m_RotateSpeed;

    /// <summary>
    /// 回転方向
    /// </summary>
    public bool m_RotateDirection;

    public float m_default_rotate;

    // Start is called before the first frame update
    void Start()
    {
        m_trap_common = GetComponent<trap_common>();

        if(m_RotateDirection == false)
        {
            m_RotateSpeed *= -1;
        }

        //最初の回転角度を戻す
        transform.eulerAngles = new Vector3(0.0f, 0.0f, m_default_rotate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(m_trap_common.m_in == false)
        {
            return;
        }


        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollSpeed);

        transform.Rotate(0f, 0f, m_RotateSpeed);
    }
}
