using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet00 : MonoBehaviour
{
    /// <summary>
    /// CharacterControllerのコンポーネント
    /// </summary>
    private CharacterController enemyController;

    /// <summary>
    /// 速度
    /// </summary>
    private Vector3 velocity;

    /// <summary>
    /// 移動方向
    /// </summary>
    private Vector3 direction;

    /// <summary>
    /// Playerのゲームオブジェクト
    /// </summary>
    GameObject refObj;

    /// <summary>
    /// Playerのコンポーネント
    /// </summary>
    Player player;

    /// <summary>
    /// MeshRendererのコンポーネント
    /// </summary>
    MeshRenderer meshrender;

    /// <summary>
    /// ヒット判定
    /// </summary>
    private bool m_hit;

    /// <summary>
    /// 弾の位置
    /// </summary>
    private Vector3 bullet_pos;


    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(this.gameObject, 0.5f);

        bullet_pos = GetComponent<Transform>().position;
    }

    void OnTriggerEnter(Collider other)
    {
        //弾がオブジェクトに接触した場合の処理
        //(敵の接触はダメージが当たらない状態も消えてしまうためEnemyDamage側で行う)
        //if(tags_tbl.PlayerBulletHit(other.gameObject.tag) == true)
        //{
        //    Object.Destroy(this.gameObject);//弾の削除
        //}

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if(60 <= transform.position.z)
        {
            Object.Destroy(this.gameObject);//弾の削除
        }
    }
}
