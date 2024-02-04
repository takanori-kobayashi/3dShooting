using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵7のメッシュの動作
/// </summary>
public class Enemy07Mesh : MonoBehaviour
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
        transform.Rotate(new Vector3(5, 3, 10));
    }
}
