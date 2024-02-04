using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージのスクロール
/// </summary>
public class StageScrool : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollCnt);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollSpeed);
    }

}
