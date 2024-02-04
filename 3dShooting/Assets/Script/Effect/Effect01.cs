using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エフェクト1の動作
/// </summary>
public class Effect01 : MonoBehaviour
{
    /// <summary>
    /// SE
    /// </summary>
    public AudioClip sound1;

    /// <summary>
    /// AudioSourceクラス
    /// </summary>
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        //再生
        if (audioSource != null && sound1 != null)
        {
            audioSource.PlayOneShot(sound1,0.2f);
        }

        //1秒後に削除
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
