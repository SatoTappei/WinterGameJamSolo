using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// トリガーに引っかかった具材を削除する
/// 未使用
/// </summary>
public class DestroyBorder : MonoBehaviour
{
    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(c => c.gameObject.CompareTag(Utility.PlayerTag))
            .Subscribe(c =>
            {

                Destroy(c.gameObject);
            });
    }
}