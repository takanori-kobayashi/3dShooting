using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの弾の接触時の処理
/// </summary>
public class PlayerBulletCollisionObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //弾がオブジェクトに接触した場合の処理
        //(敵の接触はダメージが当たらない状態も消えてしまうためEnemyDamage側で行う)
        if (tags_tbl.PlayerBulletHit(other.gameObject.tag) == true)
        {
            //弾の削除
            Object.Destroy(this.gameObject);
        }

    }

}
