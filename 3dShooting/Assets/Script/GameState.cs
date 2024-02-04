using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームの状態
/// </summary>
public class GameState : MonoBehaviour
{
    /// <summary>
    //　ゲームの状態
    /// </summary>
    public enum GAME_STATE : byte
    {
        NORMAL,
        PAUSE,
        BOSS,
        BOSS_DESTROY,
        STAGE_CLEAR,
        GAMEVOER,
    }

    const int INTERVAL_BOSS_DESTROY = 60 * 5;
    const int INTERVAL_STAGE_CLEAR = 60 * 5;
    const int INTERVAL_GAMEOVER = 60 * 5;

    /// <summary>
    /// スコア
    /// </summary>
    public static uint m_score { get; private set; }

    /// <summary>
    /// デバッグ文字用
    /// </summary>
    int debug1;

    /// <summary>
    /// ゲームの状態
    /// </summary>
    public static GAME_STATE m_GameState;

    /// <summary>
    /// 前のゲームの状態保持
    /// </summary>
    public static GAME_STATE m_GameStateOld;

    /// <summary>
    /// 状態切り替え時のインターバル
    /// </summary>
    private static int m_interval;

    /// <summary>
    /// プレイヤーのオブジェクト
    /// </summary>
    private GameObject m_PlayerObj;

    /// <summary>
    /// プレイヤークラス
    /// </summary>
    private Player m_Player;

    // Start is called before the first frame update
    void Start()
    {
        debug1 = DebugText.AddText(m_score.ToString(), 0, 50, 100, 50);

        m_GameState = GAME_STATE.NORMAL;
        m_GameStateOld = GAME_STATE.NORMAL;

        m_score = 0;

        m_interval = 0;

        //自機のオブジェクトの取得
        m_PlayerObj = GameObject.Find("Player");
        m_Player = m_PlayerObj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (m_GameState != GAME_STATE.PAUSE)
            {
                GamePause();
            }
            else
            {
                GamePlayResume();
            }
        }
    }

    private void FixedUpdate()
    {
        DebugText.SetText(m_score.ToString(), 0, 50, 100, 50,debug1);

        switch(m_GameState)
        {
            case GAME_STATE.NORMAL:
                m_interval = 0;
                break;
            case GAME_STATE.BOSS_DESTROY:
                m_interval++;
                if (INTERVAL_BOSS_DESTROY < m_interval)
                {
                    m_interval = 0;
                    m_GameState = GAME_STATE.STAGE_CLEAR;
                }


                break;
            case GAME_STATE.STAGE_CLEAR:
                m_interval++;
                if (INTERVAL_STAGE_CLEAR < m_interval)
                {
                    DebugText.AllClear();
                    SceneManager.LoadScene("Title");
                    m_GameState = GAME_STATE.NORMAL;
                }
                break;
            case GAME_STATE.PAUSE:
                GamePause();
                break;
            case GAME_STATE.GAMEVOER:
                m_interval++;
                if (INTERVAL_GAMEOVER < m_interval)
                {
                    DebugText.AllClear();
                    SceneManager.LoadScene("Title");
                    m_GameState = GAME_STATE.STAGE_CLEAR;
                }
                break;
        }

        //ゲームオーバー判定
        if(m_Player != null)
        {
            if(m_Player.m_PlayerDead == true)
            {
                m_GameState = GAME_STATE.GAMEVOER;
            }
        }
            
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public static void init()
    {
        m_GameState = GAME_STATE.NORMAL;

        m_score = 0;

        m_interval = 0;
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    /// <param name="addscore"></param>
    public static void ScoreAdd(uint addscore)
    {
        m_score += addscore; 
    }


    /// <summary>
    /// ポーズ状態に切り替え
    /// </summary>
    public static void GamePause()
    {
        m_GameStateOld = m_GameState;
        m_GameState = GAME_STATE.PAUSE;
        Time.timeScale = 0f;
    }

    /// <summary>
    /// ポーズから前の状態に切り替え
    /// </summary>
    public static void GamePlayResume()
    {
        m_GameState = m_GameStateOld;
        Time.timeScale = 1f;
    }


    /// <summary>
    /// ゲーム終了
    /// </summary>
    public static void GameExit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

}
