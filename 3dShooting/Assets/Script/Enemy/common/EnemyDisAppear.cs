using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の共通の削除処理
/// </summary>
public class EnemyDisAppear : MonoBehaviour
{
    /// <summary>
    /// 敵の消失座標
    /// </summary>
    public float m_disappear_z;

    // Start is called before the first frame update
    void Start()
    {
        if(m_disappear_z == 0)
        {
            m_disappear_z = -4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.z <= m_disappear_z)
        {
            Object.Destroy(this.gameObject);//敵の削除
        }
    }
}
