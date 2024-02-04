using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動作処理
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// 水平方向の入力
    /// </summary>
    float m_inputHorizontal;

    /// <summary>
    /// 垂直方向の入力
    /// </summary>
    float m_inputVertical;

    /// <summary>
    /// Rigidbodyのコンポーネント
    /// </summary>
    Rigidbody m_rb;

    /// <summary>
    /// プレイヤーの最大回転_X軸
    /// </summary>
    readonly float MAX_PLAYERROATATION_X = 30.0f;

    /// <summary>
    /// プレイヤーの最大回転_Y軸
    /// </summary>
    readonly float MAX_PLAYERROATATION_Y = 30.0f;

    /// <summary>
    /// プレイヤーの最大回転_Z軸
    /// </summary>
    readonly float MAX_PLAYERROATATION_Z = 10.0f;

    /// <summary>
    /// プレイヤー回転_X軸
    /// </summary>
    float PlayerRotation_x;

    /// <summary>
    /// プレイヤー回転_Y軸
    /// </summary>
    float PlayerRotation_y;

    /// <summary>
    /// プレイヤー回転_Z軸
    /// </summary>
    float PlayerRotation_z;

    /// <summary>
    /// プレイヤーの最大移動範囲
    /// </summary>
    readonly float MAX_PLAYERMOVE_X = 5.0f;

    /// <summary>
    /// プレイヤーの最小移動範囲
    /// </summary>
    readonly float MIN_PLAYERMOVE_X = -5.0f;

    /// <summary>
    /// プレイヤーの最大移動範囲
    /// </summary>
    readonly float MAX_PLAYERMOVE_Y = 1.5f;

    /// <summary>
    /// プレイヤーの最小移動範囲
    /// </summary>
    readonly float MIN_PLAYERMOVE_Y = -2.4f;

    /// <summary>
    /// bullet prefab 
    /// </summary>
    public GameObject m_bullet;


    /// <summary>
    /// プレイヤーの最大速度
    /// </summary>
    readonly float SPEEDING_MAX = 5.0f;

    /// <summary>
    /// プレイヤーの現在のスピード
    /// </summary>
    private float m_speeding = 0.0f;

    /// <summary>
    /// プレイヤーの動きのロック
    /// </summary>
    private bool m_MoveLock;

    /// <summary>
    /// プレイヤーの向きのロック
    /// </summary>
    private bool m_DirectionLock;

    /// <summary>
    /// マウスを使用した場合の動きの量
    /// </summary>
    private const float MOUSE_MOVE_MAX = 3;
    private const float MOUSE_MOVE_MIN = 1;
    private float m_MouseMove = MOUSE_MOVE_MIN;

    /// <summary>
    /// エフェクト(撃墜)
    /// </summary>
    public GameObject m_EffectShootDown;

    /// <summary>
    /// ダメージのSE
    /// </summary>
    public AudioClip m_DamageSE;

    /// <summary>
    /// ライフアップのSE
    /// </summary>
    public AudioClip m_LifeUpSE;
    

    /// <summary>
    /// オーディオコンポーネント
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// デバッグ文字用
    /// </summary>
    int debug1;
    int debug2;
    int debug3;
    int debug4;

    int DebugStageCount = 0;

    /// <summary>
    /// プレイヤーのライフ
    /// </summary>
    private const byte MAX_PLAYERLIFE = 5;
    public byte m_PlayerLife { get; private set; } = MAX_PLAYERLIFE;

    public bool m_PlayerDead { get; set; } = false;


    /// <summary>
    /// 無敵状態
    /// </summary>
    public bool m_NoDamageFlg { get; private set; } = false;

    /// <summary>
    /// 無敵時間
    /// </summary>
    private const int NODAMAGE_MAXTIME = 60 * 2;
    private int m_NoDamageInterval = 0;

    /// <summary>
    /// 向きの正面固定
    /// </summary>
    bool type = false;

    /// <summary>
    /// オブジェクトの表示非表示
    /// </summary>
    Renderer m_rend;

    Renderer[] m_rendChi = new Renderer[10];

    // Start is called before the first frame update
    void Start()
    {
        debug1 = DebugText.AddText(m_inputHorizontal.ToString() + "XX", 300, 300, 100, 50);
        debug2 = DebugText.AddText(m_inputVertical.ToString() + "YY", 300, 400, 100, 50);
        debug3 = DebugText.AddText(count.ToString(), 300, 400, 100, 50);
        debug4 = DebugText.AddText(count.ToString(), 300, 400, 100, 50);

        m_rb = GetComponent<Rigidbody>();

        PlayerRotation_x = 0.0f;
        PlayerRotation_y = 0.0f;
        PlayerRotation_z = 0.0f;

        m_MoveLock = false;
        m_DirectionLock = false;

        //オブジェクトの表示非表示
        m_rend = GetComponent<Renderer>();
        m_rend.enabled = true;


        m_MouseMove = MOUSE_MOVE_MIN;

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        //下に記述しないと後の処理まで行かない?
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //   m_rendChi[i] = transform.GetChild(i).GetComponent<Renderer>();
        //  m_rendChi[i].enabled = true; 
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //コントローラーやキーボードの入力時
        m_inputHorizontal = Input.GetAxisRaw("Horizontal");
        m_inputVertical = Input.GetAxisRaw("Vertical");

        m_MouseMove = MOUSE_MOVE_MIN;

        ////マウスの入力時
        //if (0 != Input.GetAxis("Mouse X") || 0 != Input.GetAxis("Mouse Y"))
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //    m_inputHorizontal = Input.GetAxis("Mouse X");
        //    m_inputVertical = Input.GetAxis("Mouse Y") * -1;
        //    //if (0.2 < Input.GetAxis("Mouse X"))
        //    // {
        //    //     m_inputHorizontal = 1;
        //    // }
        //    // else if(Input.GetAxis("Mouse X") < -0.2)
        //    //{
        //    //    m_inputHorizontal = -1;
        //    //}
        //    // if (0.2 < Input.GetAxis("Mouse Y"))
        //    // {
        //    //     m_inputVertical = 1;
        //    // }
        //    // else if(Input.GetAxis("Mouse Y") < -0.2)
        //    //{
        //    //    m_inputVertical = -1;
        //    //}
        //     m_MouseMove = MOUSE_MOVE_MAX;
        // }


        if (Input.GetButton("MoveLock"))
        {
            m_MoveLock = true;
        }
        else
        {
            m_MoveLock = false;
        }
        if (Input.GetButton("DirectionLock"))
        {
            m_DirectionLock = true;
        }
        else
        {
            m_DirectionLock = false;
        }

        //m_JumpKey = Input.GetAxisRaw("Jump");

       // DebugText.SetText(Input.priGetButton("fire1").ToString(), 10, 100, 100, 100, debug1);
        //DebugText.SetText(""+PlayerRotation_x+" "+PlayerRotation_y+" "+PlayerRotation_z, 10, 40, 500, 100,debug2);
        
        //fps表示
        var fps = 1f / Time.deltaTime;
        DebugText.SetText("TimeCount:" + DebugStageCount +" fps:" + fps + "ScrollCnt:"+ StageScrollCount.m_ScrollCnt, 10, 10, 100, 100, debug3);
        DebugStageCount++;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(type == false)
            { 
            type = true;
            }
            else
            {
                type =false;
            }
        }
    }

    /// <summary>
    /// プレイヤーの角度
    /// </summary>
    /// 
    int count = 0;
    private void PlayerRotation()
    {
        var RotateSpeedAdd = 0.0f;

        if(m_DirectionLock == true)
        {
            return;
        }

        //動きのロック時は回転のスピードをあげる
        if (m_MoveLock == true)
        {
            RotateSpeedAdd = 1.0f;
        }

        //if (count >= 200)
        //{
        //    gameObject.transform.rotation = Quaternion.identity;
        //    transform.localRotation = Quaternion.identity;
        //    transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //    return;
        //}
        //count++;
      // m_rb.isKinematic = false;
        var default_x = false;
        var default_y = false;
        var default_z = false;
#if true

        //x軸-------------------------------------------------
        if (0 < m_inputVertical && m_inputVertical <= 1)
        {
            if ( (-1 * MAX_PLAYERROATATION_X) <= PlayerRotation_x)
            {
                if ( -1 * m_inputVertical * MAX_PLAYERROATATION_X <= PlayerRotation_x)
                {
                    PlayerRotation_x -= 1.0f + RotateSpeedAdd;
                }
            }
           // PlayerRotation_x = -1 * m_inputVertical * 30;
        }

        //    case -1:
        else if (m_inputVertical < 0 && -1 <= m_inputVertical)
        {
            if (PlayerRotation_x <= MAX_PLAYERROATATION_X)
            {
                if (PlayerRotation_x <= -1 * m_inputVertical * MAX_PLAYERROATATION_X)
                {
                    PlayerRotation_x += 1.0f + RotateSpeedAdd;
                }
            }
        }

        else
        {
            float tmpx = Mathf.Round(transform.eulerAngles.x);
            if (0.0f != tmpx)
            {
                if (tmpx < 180)
                {
                    if (tmpx <= 1.0f)
                    {
                        // PlayerRotation_x -= transform.localEulerAngles.x;
                        default_x = true;
                    }

                    else
                    {
                        PlayerRotation_x -= 1.0f;
                    }


                }
                else if (180 < tmpx)
                {
                    if (tmpx <= -1.0f)
                    {

                        // PlayerRotation_x += transform.localEulerAngles.x;
                        default_x = true;
                    }
                    else
                    {
                        PlayerRotation_x += 1.0f;
                    }
                }
            }
            else
            {
                default_x = true;
            }
        }
        //x軸-------------------------------------------------end

        //y軸-------------------------------------------------
        if (0 < m_inputHorizontal && m_inputHorizontal <= 1)
        {
            if (PlayerRotation_y <= MAX_PLAYERROATATION_Y)
            {
                if (PlayerRotation_y <= m_inputHorizontal * MAX_PLAYERROATATION_Y)
                {
                    PlayerRotation_y += 1.0f + RotateSpeedAdd;
                }
            }
        }

        else if (m_inputHorizontal < 0 && -1 <= m_inputHorizontal)
        {
            if (-1 * MAX_PLAYERROATATION_Y <= PlayerRotation_y)
            {
                if (m_inputHorizontal * MAX_PLAYERROATATION_Y <= PlayerRotation_y)
                {
                    PlayerRotation_y -= 1.0f + RotateSpeedAdd;
                }
            }
        }
        else
        {
            float tmpy = transform.eulerAngles.y;
            if (0.0f != tmpy)
            {
                if (tmpy < 180)
                {
                    if (tmpy <= 1.0f)
                    {
                        default_y = true;
                    }

                    else
                    {
                        PlayerRotation_y -= 1.0f;
                    }


                }
                else if (180 < tmpy)
                {
                    if (tmpy <= -1.0f)
                    {
                        default_y = true;
                    }
                    else
                    {
                        PlayerRotation_y += 1.0f;
                    }
                }
            }
            else
            {
                default_y = true;
            }


        }
        //y軸-------------------------------------------------end


        //z軸-------------------------------------------------
        if( 0 < m_inputHorizontal && m_inputHorizontal <= 1)
        { 
                if (-1 * MAX_PLAYERROATATION_Z <= PlayerRotation_z)
                {
                    if (-1 * m_inputHorizontal * MAX_PLAYERROATATION_Z <= PlayerRotation_z)
                    {
                        PlayerRotation_z -= 1.0f + RotateSpeedAdd;
                    }
                }
        }
        else if (m_inputHorizontal < 0 && -1 <= m_inputHorizontal)
        { 
                if (PlayerRotation_z <= MAX_PLAYERROATATION_Z)
                {
                if (PlayerRotation_z <= -1 * m_inputHorizontal * MAX_PLAYERROATATION_Z)
                {
                    PlayerRotation_z += 1.0f + RotateSpeedAdd;
                }
                }
        }

        else
        { 
                float tmpz = transform.eulerAngles.z;
                if (0.0f != tmpz)
                {
                    if (tmpz < 180)
                    {
                        if (tmpz <= 1.0f)
                        {
                            default_z = true;
                        }

                        else
                        {
                            PlayerRotation_z -= 1.0f;
                        }


                    }
                    else if (180 < tmpz)
                    {
                        if (tmpz <= -1.0f)
                        {
                            default_z = true;
                        }
                        else
                        {
                            PlayerRotation_z += 1.0f;
                        }
                    }
                }
                else
                {
                    default_z = true;
                }                
        }
        //z軸-------------------------------------------------end



        transform.localRotation = Quaternion.Euler(PlayerRotation_x, PlayerRotation_y, PlayerRotation_z);

        var rotetmpx = transform.localEulerAngles.x;
        var rotetmpy = transform.localEulerAngles.y;
        var rotetmpz = transform.localEulerAngles.z;

        if (default_x == true)
        {

            rotetmpx = 0.0f;
        }
        if (default_y == true)
        {
            rotetmpy = 0.0f;
        }
        if (default_z == true)
        {
            rotetmpz = 0.0f;
        }

        if (type == false)
        {
            this.transform.rotation = Quaternion.Euler(rotetmpx, rotetmpy, rotetmpz);

            this.transform.eulerAngles = new Vector3(rotetmpx, rotetmpy, rotetmpz);
        }
        else
        {

            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

#else

        switch (m_inputHorizontal)
        {
            case 1:
                if (PlayerRotation_y < 30)
                {
                    PlayerRotation_y += 1.0f;// this.transform.localRotation.y + 1.0f;
                }
                break;
            case -1:
                if (-30 < PlayerRotation_y)
                { 
                    PlayerRotation_y -= 1.0f;
                }
                break;
            default:
                PlayerRotation_y = 0.0f;
                break;
        }

        //m_inputVertical *= -1;
        switch (m_inputVertical)
        {
            case 1:
                if (PlayerRotation_x < 30)
                {
                    PlayerRotation_x += 1.0f;
                }
                break;
            case -1:
                if (-30 < PlayerRotation_x)
                {
                    PlayerRotation_x -= 1.0f;
                }
                break;
            default:
                PlayerRotation_x = 0.0f;
                break;
        }

        Vector3 forward = new Vector3(PlayerRotation_x, PlayerRotation_y, PlayerRotation_z);
        //Vector3 forward = new Vector3(Mathf.Repeat(PlayerRotation_x,360), Mathf.Repeat(PlayerRotation_y, 360), Mathf.Repeat(PlayerRotation_z, 360));

        Quaternion rot = Quaternion.LookRotation(forward);
        var toRot = Quaternion.Euler(PlayerRotation_x, PlayerRotation_y, PlayerRotation_z);

        rot = Quaternion.Slerp(this.transform.localRotation, toRot, 0.1f);

        this.transform.rotation = rot;
#endif


    }

    private void PlayerMove()
    {
#if true

        if(m_MoveLock == true)
        {
            m_rb.velocity = new Vector3(0, 0, 0);
            return;
        }

        //時期の加速度
        if (m_inputVertical != 0 || m_inputHorizontal != 0)
        {
            if (m_speeding < SPEEDING_MAX)
            {
                m_speeding += 0.2f;
            }
            else if (SPEEDING_MAX <= m_speeding)
            {
                m_speeding = 3.0f;
            }
        }
        else
        {
            if (0 < m_speeding)
            {
                m_speeding -= 0.2f;
            }
            else
            {
                m_speeding = 0.0f;
            }
        }

        //最大移動範囲
        if (transform.position.x <= MIN_PLAYERMOVE_X)
        {
            if (m_inputHorizontal < 0)
            {
                m_inputHorizontal = 0;
            }
        }

        if(MAX_PLAYERMOVE_X <= transform.position.x)
        {
            if (0 < m_inputHorizontal)
            {
                m_inputHorizontal = 0;
            }
        }

        if (transform.position.y <= MIN_PLAYERMOVE_Y)
        {
            if (m_inputVertical < 0)
            {
                m_inputVertical = 0;
            }
        }

        if (MAX_PLAYERMOVE_Y <= transform.position.y)
        {
            if (0 < m_inputVertical)
            {
                m_inputVertical = 0;
            }
        }


        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(0, 1, 0)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = Camera.main.transform.right * m_inputHorizontal + Camera.main.transform.up * m_inputVertical;// + cameraForward * m_inputVertical;

       // Vector3 moveForward = Camera.main.transform.right * m_inputHorizontal * m_MouseMove + Camera.main.transform.up * m_inputVertical * m_MouseMove;// + cameraForward * m_inputVertical;


        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        m_rb.velocity = moveForward * m_speeding;// + new Vector3(m_rb.velocity.x, 0, 0);
        
#else

        switch(m_inputVertical)
        {
            case 1:
                transform.position += new Vector3(0,-0.05f,0);//transform.right * 10 * Time.deltaTime;
                break;
            case -1:
                transform.position += new Vector3(0,0.05f, 0);//transform.right * 10 * Time.deltaTime;
                break;
        }

        switch (m_inputHorizontal)
        {
            case 1:
                transform.position += new Vector3(0.05f, 0, 0);//transform.right * 10 * Time.deltaTime;
                break;
            case -1:
                transform.position += new Vector3(-0.05f, 0, 0);//transform.right * 10 * Time.deltaTime;
                break;
        }

#endif

        //Z軸がずれた場合は元の座標に戻す-------------------------------
        if (0 < transform.position.z)
        {
            var tmp = -0.1f;

            if (transform.position.z < 0.1f)
            {
                transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.0f);
            }

            else
            {
                transform.Translate(0, 0, tmp);
            }
        }
        else if (transform.position.z < 0)
        {
            var tmp = 0.1f;

            if (-0.1f < transform.position.z)
            {
                transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.0f);
            }

            else
            {
                transform.Translate(0, 0, tmp);
            }
        }
        //-------------------------------------------------------------------
    }

    void PlayerState()
    {
        //無敵時間カウント
        if(0 < m_NoDamageInterval)
        {
            m_NoDamageInterval--;
        }
        else
        {
            m_NoDamageFlg = false;
            m_NoDamageInterval = 0;
        }

        DebugText.SetText(m_NoDamageInterval +" "+ m_NoDamageFlg+ " "+ m_PlayerLife + " ", 300, 550, 100, 50, debug4);
    }

    /// <summary>
    /// プレイヤーのオブジェクト接触処理
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        //ダメージの処理
        Damage(other);

        //アイテム取得
        ItemGet(other);

    }

    /// <summary>
    /// ダメージを受けた場合
    /// </summary>
    /// <param name="other"></param>
    private void Damage(Collider other)
    {
        //ダメージを受けた場合
        if (m_NoDamageFlg == false)
        {
            if (true == tags_tbl.PlayerDamage(other.transform.tag))
            {
                m_NoDamageFlg = true;
                m_NoDamageInterval = NODAMAGE_MAXTIME;

                if (0 < m_PlayerLife)
                {
                    m_PlayerLife--;

                    //死亡
                    if (m_PlayerLife <= 0)
                    {
                        m_PlayerDead = true;
                        m_rend.enabled = false;

                        //爆発エフェクトのセット
                        if (null != m_EffectShootDown)
                        {
                            GameObject EffectShootDown = Instantiate(m_EffectShootDown) as GameObject;

                            //座標
                            EffectShootDown.transform.position = transform.position;
                            Destroy(EffectShootDown, 1.0f);
                        }

                    }

                    //ダメージSE
                    else
                    {
                        //再生
                        if (audioSource != null && m_DamageSE != null)
                        {
                            audioSource.PlayOneShot(m_DamageSE, 0.2f);
                        }
                    }
                }
            }
        }

    }

    /// <summary>
    /// アイテム取得
    /// </summary>
    /// <param name="other"></param>
    private void ItemGet(Collider other)
    {
        if (true == tags_tbl.PlayerItemTouch(other.transform.tag) && m_PlayerDead == false)
        {
            //ライフアップ
            if(other.transform.tag == "ItemLifeUp")
            {
                if (m_PlayerLife < MAX_PLAYERLIFE)
                {
                    m_PlayerLife++;
                }
                //ライフが最大ならスコアプラス
                else
                {
                    GameState.ScoreAdd(1000);
                }

                //SE再生
                if (audioSource != null && m_LifeUpSE != null)
                {
                    audioSource.PlayOneShot(m_LifeUpSE, 0.2f);
                }
            }
        }
    }


    private void FixedUpdate()
    {
        //上下反転
        m_inputVertical *= -1;

        //死亡時はすべてを受け付けない
        if(m_PlayerDead == true)
        {
            m_rb.velocity = new Vector3(0, 0, 0);
            return;
        }


        //プレイヤーの向き
        PlayerRotation();

        //動き
        PlayerMove();

        //プレイヤーの状態
        PlayerState();


    }
}
