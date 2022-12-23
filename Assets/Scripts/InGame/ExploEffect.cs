using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 爆弾が爆発したときのエフェクトを制御するコンポーネント
/// 専用のオブジェクトプールにプーリングされている
/// </summary>
public class ExploEffect : MonoBehaviour
{
    Tween _tween;

    [SerializeField] AnimationClip _clip;

    public ExploEffectPool Pool { get; set; }

    /// <summary>生成時にプール側から呼ばれる初期化処理</summary>
    public void Init(ExploEffectPool pool)
    {
        Pool = pool;
        gameObject.SetActive(false);
    }

    /// <summary>表示され、アニメーション再生後に消える</summary>
    public void Active(Vector3 pos)
    {
        gameObject.SetActive(true);
        transform.position = pos;

        _tween = DOVirtual.DelayedCall(_clip.length, () => 
        {
            Pool.ReturnPool(this);
            gameObject.SetActive(false);
        });
    }

    void OnDestroy()
    {
        _tween?.Kill();
    }
}
