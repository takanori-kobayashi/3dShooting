using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

/// <summary>
/// タイトルの動作処理
/// </summary>
public class TitleOperation : MonoBehaviour
{
    /// <summary>
    /// カーソルのオブジェクト
    /// </summary>
    public GameObject m_CursolObj;

    /// <summary>
    /// カーソルのオブジェクト2
    /// </summary>
    public GameObject m_CursolObj2;

    /// <summary>
    /// カーソルの画像
    /// </summary>
    private Image m_CursolImg;

    /// <summary>
    /// カーソルの画像2
    /// </summary>
    private Image m_CursolImg2;

    /// <summary>
    /// キャンバスのスタート文字
    /// </summary>
    public GameObject m_StrStart;

    /// <summary>
    /// キャンバスのエンド文字
    /// </summary>
    public GameObject m_StrEnd;

    /// <summary>
    /// カーソルの内容(ゲーム開始)
    /// </summary>
    const byte CURSOL_START = 0;


    /// <summary>
    /// カーソルの内容(ゲーム終了)
    /// </summary>
    const byte CURSOL_END = 1;

    /// <summary>
    /// カーソル
    /// </summary>
    private byte m_Cursol;

    /// <summary>
    /// カーソルの位置
    /// </summary>
    private Vector3[] m_CursolPos = new Vector3[2];

    /// <summary>
    /// 水平方向の入力
    /// </summary>
    float m_inputHorizontal;

    /// <summary>
    /// 垂直方向の入力
    /// </summary>
    float m_inputVertical;

    /// <summary>
    /// ボタンが押されいているかどうか
    /// </summary>
    bool m_push;


    // Start is called before the first frame update
    void Start()
    {
        m_Cursol = CURSOL_START;
        m_push = false;

        m_CursolImg = m_CursolObj.GetComponent<Image>();
        m_CursolImg2 = m_CursolObj2.GetComponent<Image>();

        m_CursolImg.enabled = false;
        m_CursolImg2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //コントローラーやキーボードの入力時
        m_inputHorizontal = Input.GetAxisRaw("Horizontal");
        m_inputVertical = Input.GetAxisRaw("Vertical");

        EspKeyQuit();
    }

    private void FixedUpdate()
    {

        switch (m_Cursol)
        {
            case CURSOL_START:
                GameStart();
                break;
            case CURSOL_END:
                Quit();
                break;
        }


        if (m_push == false && m_inputVertical != 0 && (m_inputVertical <= -0.5f || 0.5f <= m_inputVertical))
        {
            m_push = true;

            if (m_Cursol < CURSOL_END)
            {
                m_Cursol++;
            }
            else
            {
                m_Cursol = 0;
            }
        }
        else if(m_inputVertical == 0)
        {
            m_push = false;
        }

        if(m_Cursol == 0)
        {
            m_CursolImg.enabled = true;
            m_CursolImg2.enabled = false;
        }
        else
        {
            m_CursolImg.enabled = false;
            m_CursolImg2.enabled = true;
        }

        //rectTransform.position = m_CursolPos[m_Cursol];


    }

    /// <summary>
    /// ゲーム終了
    /// </summary>
    private void Quit()
    {
        if (Input.GetAxisRaw("Fire1") == 1)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
        }
    }

    /// <summary>
    /// ゲーム終了(Escキー押下)
    /// </summary>
    private void EspKeyQuit()
    {
        //if (Input.GetKeyDown("q"))
        if(Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
        }
    }

    /// <summary>
    /// ゲーム開始
    /// </summary>
    private void GameStart()
    {

        if (Input.GetAxisRaw("Fire1") == 1)
        {
            //初期化処理
            //ステージのスクロール
            StageScrollCount.init();

            //ゲーム開始
            SceneManager.LoadScene("SampleScene");
        }
    }
}
