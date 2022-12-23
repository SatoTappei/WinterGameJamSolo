using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// スタートボタンに処理を登録するコンポーネント
/// </summary>
public class StartButonRegister : MonoBehaviour
{
    [SerializeField] Button _startButton;

    void Start()
    {
        _startButton.onClick.AddListener(() => 
        {
            // ボタンのクリック音を再生してBGMをフェードアウトさせる
            SoundManager.Instance?.PlaySE("ボタンクリックSE");
            SoundManager.Instance?.FadeOutBGM();

            // 音が鳴り終わったタイミングでフェードアウトを開始する
            DOVirtual.DelayedCall(0.5f, () =>
            {
                FadeSystem.Instance?.FadeOut("InGame");
            });
        });
    }
}
