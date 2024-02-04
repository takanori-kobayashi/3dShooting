using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵3のメッシュの動作
/// </summary>
public class Enemy03Mesh : MonoBehaviour
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
        transform.Rotate(new Vector3(0, 0, 10));
    }
}
