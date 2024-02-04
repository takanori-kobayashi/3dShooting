using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵7の動作
/// </summary>
public class Enemy07 : MonoBehaviour
{
    /// <summary>
    /// エフェクト(撃墜)
    /// </summary>
    public GameObject m_EffectShootDown;

    /// <summary>
    /// 加算スコア
    /// </summary>
    public uint m_AddScore;

    /// <summary>
    /// 存在時間
    /// </summary>
    private const float LIVING_TIME = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(this.gameObject, LIVING_TIME);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// EnemyDamage.csではなく単体で処理を行う
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (true == tags_tbl.EnemyDamage(other.transform.tag))
        {
            //爆発エフェクト
            if (null != m_EffectShootDown)
            {
                GameObject EffectShootDown = Instantiate(m_EffectShootDown) as GameObject;

                //座標
                EffectShootDown.transform.position = transform.position;
                Destroy(EffectShootDown, 1.0f);

            }
            GameState.ScoreAdd(m_AddScore);
            Object.Destroy(this.gameObject);//敵の削除
        }

        //ステージのオブジェクトに接触したときは消す
        else if(true == tags_tbl.EnemyStageObjTouch(other.transform.tag))
        {
            Object.Destroy(this.gameObject);//敵の削除
        }
    }

    private void FixedUpdate()
    {

        //敵の位置をスクロールに合わせる(デバッグ時0以外の時)
        transform.Translate(0f, 0f, -StageScrollCount.m_ScrollSpeed);
    }
}
