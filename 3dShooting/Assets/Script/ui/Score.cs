using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// (UI)スコア表示
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>
    /// テキストオブジェクト
    /// </summary>
    public GameObject m_score_object = null;

    /// <summary>
    /// テキストクラス
    /// </summary>
    Text m_score_text;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトからTextコンポーネントを取得
        m_score_text = m_score_object.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        // スコアの更新
        m_score_text.text = "SCORE:" + GameState.m_score;
        m_score_text.text = "SCORE:" + GameState.m_score;
    }
}
