using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// (UI)ステージクリア状態
/// </summary>
public class StageClear : MonoBehaviour
{
    /// <summary>
    /// テキストオブジェクト
    /// </summary>
    public GameObject m_StageClear_object = null;

    /// <summary>
    /// テキストクラス
    /// </summary>
    Text m_StageClear_text;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトからTextコンポーネントを取得
        m_StageClear_text = m_StageClear_object.GetComponent<Text>();

        m_StageClear_text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //ステージクリア時表示
        if (GameState.m_GameState == GameState.GAME_STATE.STAGE_CLEAR)
        {
            m_StageClear_text.enabled = true;
        }
    }
}
