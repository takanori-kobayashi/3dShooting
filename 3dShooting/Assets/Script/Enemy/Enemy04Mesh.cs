using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵4のメッシュの動作
/// </summary>
public class Enemy04Mesh : MonoBehaviour
{
    /// <summary>
    /// 親オブジェクト
    /// </summary>
    public GameObject m_root;

    /// <summary>
    /// 敵4
    /// </summary>
    Enemy04 m_Enemy04;

    /// <summary>
    /// 回転変数_X
    /// </summary>
    private float m_rotateX;

    /// <summary>
    /// 回転変数_Y
    /// </summary>
    private float m_rotateZ;

    /// <summary>
    /// 最大回転サイズ
    /// </summary>
    readonly float MAX_ROTATE_XZ = 180;

    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクト取得
        //m_root = transform.root.gameObject;
        m_root = transform.parent.gameObject;
        //親コンポーネント取得
        m_Enemy04 = m_root.GetComponent<Enemy04>();

        m_rotateX = 0;
        m_rotateZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (m_Enemy04 != null)
        {
            ///メッシュの回転
            if (m_Enemy04.m_return == true)
            {
                var tmpX = 0.0f;
                var tmpZ = 0.0f;
                if (m_rotateX < MAX_ROTATE_XZ)
                {
                    m_rotateX += 5;
                    tmpX = -5;// m_rotateX;
                }
                else if (m_rotateZ < MAX_ROTATE_XZ)
                {
                    m_rotateZ += 5;
                    tmpZ = 5;// m_rotateY;
                }
                transform.Rotate(new Vector3(tmpX, 0.0f, tmpZ));
            }
        }
    }
}
