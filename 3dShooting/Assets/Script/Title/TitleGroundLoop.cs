using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトルの床の動作
/// </summary>
public class TitleGroundLoop : MonoBehaviour
{
    /// <summary>
    /// 床の動作スピード
    /// </summary>
    const float TILTE_GROUND_SPEED = -0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(0f, 0f, TILTE_GROUND_SPEED);



        if (transform.position.z <= -60)
        {
            //ループ処理
            transform.Translate(0f, 0f, 300.0f);
        }
    }
}
