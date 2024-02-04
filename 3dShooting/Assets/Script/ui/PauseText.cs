using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// (UI)ポーズ時の表示
/// </summary>
public class PauseText : MonoBehaviour
{
    /// <summary>
    /// カーソルの位置(続ける)
    /// </summary>
    readonly int CURSOR_RESUME = 0;

    /// <summary>
    /// カーソルの位置(終了)
    /// </summary>
    readonly int CURSOR_EXIT = 1;

    /// <summary>
    /// カーソル
    /// </summary>
    int m_cursor;

    /// <summary>
    /// ボタンの押下状態
    /// </summary>
    bool inputpush;

    // Start is called before the first frame update
    void Start()
    {
        m_cursor = CURSOR_RESUME;
        inputpush = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ中
        if (GameState.m_GameState == GameState.GAME_STATE.PAUSE)
        {

            if (m_cursor == CURSOR_RESUME)
            {
                this.GetComponent<Text>().text = "PAUSE MENU\n> RETURN TO GAME\n   EXIT";
            }
            else if (m_cursor == CURSOR_EXIT)
            {
                this.GetComponent<Text>().text = "PAUSE MENU\n   RETURN TO GAME\n> EXIT";
            }

            //入力を取得-----------------------------------
            var inputVertical = Input.GetAxisRaw("Vertical");
            var inputFire1 = Input.GetAxisRaw("Fire1");
            //カーソルの動き
            if (inputVertical != 0.0f)
            {

                if (inputpush == false)
                {
                    inputpush = true;
                    m_cursor++;

                    if (1 < m_cursor)
                    {
                        m_cursor = 0;
                    }
                }
            }
            else
            {
                inputpush = false;
            }
            //攻撃ボタン

            if (inputFire1 != 0.0)
            {
                if (m_cursor == CURSOR_RESUME)
                {
                    GameState.GamePlayResume();
                }
                else if (m_cursor == CURSOR_EXIT)
                {
                    GameState.GameExit();
                }
            }
            //-----------------------------------------------

        }
        //通常時
        else
        {
            m_cursor = CURSOR_RESUME;
            this.GetComponent<Text>().text = "";
        }
    }
}
