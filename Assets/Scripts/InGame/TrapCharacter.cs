using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// お邪魔キャラを制御するコンポーネント
/// </summary>
public class TrapCharacter : MonoBehaviour
{
    /// <summary>到達したら消える画面外のX座標</summary>
    readonly float _toEscapePosX = -20;

    [Header("登場時に鳴らすSE")]
    [SerializeField] string _toCenterSeName;
    [Header("画面中央に来るまでにかかる時間")]
    [SerializeField] float _toCenterDuration;
    [Header("画面中央にとどまる時間")]
    [SerializeField] float _waitScreenCenter;
    [Header("画面中央に移動する際のイージング")]
    [SerializeField] Ease _toCenterEase;
    [Space(10)]
    [Header("画面外に消える時に鳴らすSE")]
    [SerializeField] string _toEscapeSeName;
    [Header("画面外に消えるまでにかかる時間")]
    [SerializeField] float _toEscapeDuration;
    [Header("画面外に移動する際のイージング")]
    [SerializeField] Ease _toEscapeEase;

    Sequence _seq;

    void Start()
    {
        SoundManager.Instance?.PlaySE(_toCenterSeName);

        _seq = DOTween.Sequence()
              .Append(transform.DOMoveX(0, _toCenterDuration).SetEase(_toCenterEase))
              .Append(transform.DOMoveX(_toEscapePosX, _toEscapeDuration).SetEase(_toEscapeEase).SetDelay(_waitScreenCenter))
              .InsertCallback(_toCenterDuration + _waitScreenCenter, () => SoundManager.Instance?.PlaySE(_toEscapeSeName))
              .AppendCallback(() => Destroy(gameObject));
    }

    void OnDestroy()
    {
        _seq?.Kill();
    }
}
