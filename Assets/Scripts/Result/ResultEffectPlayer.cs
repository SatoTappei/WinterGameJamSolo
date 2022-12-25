using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// リザルト画面の演出を行うコンポーネント
/// </summary>
public class ResultEffectPlayer : MonoBehaviour
{
    void Start()
    {
        // フェードが終わるのを待ってSEを鳴らす
        DOVirtual.DelayedCall(0.5f, () => SoundManager.Instance?.PlaySE("ファンファーレSE"))
                 .SetLink(gameObject);
    }
}
