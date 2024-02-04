using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージのフロアのループ(ボス戦)
/// </summary>
public class StageFloorLoop : MonoBehaviour
{
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
        if(transform.position.z <= -60)
        {
            //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
            transform.Translate(0f, 0f, 300.0f);
        }
    }
}
