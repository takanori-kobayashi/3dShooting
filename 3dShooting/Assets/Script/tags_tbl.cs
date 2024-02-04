using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトのタブテーブルリスト
/// </summary>
public class tags_tbl : MonoBehaviour
{
    /// <summary>
    /// 敵がダメージを受けた時
    /// </summary>
    static readonly string[] ENEMY_DAMAGE_TAG_TBL =
    {
        "PlayerBullet",
    };

    /// <summary>
    /// 敵がステージのオブジェクトに接触したとき
    /// </summary>
    static readonly string[] ENEMY_TOUCH_STOBJ_TAG_TBL =
    {
        "StageObject",
    };

    /// <summary>
    /// プレイヤーがアイテムに接触したとき
    /// </summary>
    static readonly string[] PLAYER_ITEM_TOUCH_TAG_TBL =
    {
        "ItemLifeUp",
    };

    /// <summary>
    /// プレイヤーがダメージを受けたとき
    /// </summary>
    static readonly string[] PLAYER_DAMAGE_TAG_TBL =
    {
        "EnemyBullet",
        "Enemy",
        "trap",
    };

    /// <summary>
    /// プレイヤーの弾がオブジェクトに接触したとき
    /// </summary>
    static readonly string[] BULLET_HIT_TAG =
    {
        //"Enemy",//プレイヤーの弾側で行うと敵が出現前の状態で接触して消えてしまう
        "StageObject"
    };

    /// <summary>
    /// アイテムがオブジェクトに接触したとき
    /// </summary>
    static readonly string[] ITEM_TOUCH_TAG_TBL =
    {
        "Player",
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// プレイヤーの弾が接触したときのタグチェック
    /// </summary>
    /// <param name="tagname"></param>
    /// <returns></returns>
    public static bool PlayerBulletHit(string tagname)
    {
        for (int i = 0; i < BULLET_HIT_TAG.Length; i++)
        {
            if (BULLET_HIT_TAG[i] == tagname)
            {
                return true;
            }
        }

        return false;
    }


    /// <summary>
    /// プレイヤーのアイテム接触したときのタグチェック
    /// </summary>
    /// <param name="tagname"></param>
    /// <returns></returns>
    public static bool PlayerItemTouch(string tagname)
    {
        for (int i = 0; i < PLAYER_ITEM_TOUCH_TAG_TBL.Length; i++)
        {
            if (PLAYER_ITEM_TOUCH_TAG_TBL[i] == tagname)
            {
                return true;
            }
        }

        return false;
    }


    /// <summary>
    /// 敵がプレイヤーの弾に接触したときのタグチェック
    /// </summary>
    /// <param name="tagname"></param>
    /// <returns></returns>
    public static bool EnemyDamage(string tagname)
    {
        for (int i = 0; i < ENEMY_DAMAGE_TAG_TBL.Length; i++)
        {
            if (ENEMY_DAMAGE_TAG_TBL[i] == tagname)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 敵がステージオブジェクトに接触したときのタグチェック
    /// </summary>
    /// <param name="tagname"></param>
    /// <returns></returns>
    public static bool EnemyStageObjTouch(string tagname)
    {
        for (int i = 0; i < ENEMY_TOUCH_STOBJ_TAG_TBL.Length; i++)
        {
            if (ENEMY_TOUCH_STOBJ_TAG_TBL[i] == tagname)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// プレイヤーがダメージを受ける接触をした時のタグチェック
    /// </summary>
    /// <param name="tagname"></param>
    /// <returns></returns>
    public static bool PlayerDamage(string tagname)
    {
        for (int i = 0; i < PLAYER_DAMAGE_TAG_TBL.Length; i++)
        {
            if (PLAYER_DAMAGE_TAG_TBL[i] == tagname)
            {
                return true;
            }
        }

        return false;
    }
    
    /// <summary>
    /// アイテムがプレイヤーに接触した場合のタグチェック
    /// </summary>
    /// <param name="tagname"></param>
    /// <returns></returns>
    public static bool ItemPlayertouch(string tagname)
    {
        for (int i = 0; i < ITEM_TOUCH_TAG_TBL.Length; i++)
        {
            if (ITEM_TOUCH_TAG_TBL[i] == tagname)
            {
                return true;
            }
        }

        return false;
    }



}
