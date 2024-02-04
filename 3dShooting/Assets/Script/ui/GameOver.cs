using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// (UI)ゲームオーバー状態
/// </summary>
public class GameOver : MonoBehaviour
{
    /// <summary>
    /// テキストオブジェクト
    /// </summary>
    public GameObject m_GameOver_object = null;

    /// <summary>
    /// テキストクラス
    /// </summary>
    Text m_GameOver_text;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトからTextコンポーネントを取得
        m_GameOver_text = m_GameOver_object.GetComponent<Text>();

        m_GameOver_text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //ゲームオーバー時表示
        if(GameState.m_GameState == GameState.GAME_STATE.GAMEVOER)
        {
            m_GameOver_text.enabled = true;
        }
    }
}
