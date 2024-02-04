using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 回復アイテムのメッシュの動作
/// </summary>
public class LifUpMesh : MonoBehaviour
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
        //回転
        transform.Rotate(new Vector3(0, 2, 0));
    }
}
