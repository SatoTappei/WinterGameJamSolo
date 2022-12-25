using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// ボタンにシーン遷移の処理を登録するコンポーネント
/// </summary>
public class LoadSceneButtonRegister : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] string _sceneName;
    [SerializeField] string _seName;

    void Start()
    {
        _button.onClick.AddListener(() => 
        {
            _button.interactable = false;

            // ボタンのクリック音を再生してBGMをフェードアウトさせる
            SoundManager.Instance?.PlaySE(_seName);
            SoundManager.Instance?.FadeOutBGM();

            // 音が鳴り終わったタイミングでフェードアウトを開始する
            DOVirtual.DelayedCall(0.5f, () =>
            {
                FadeSystem.Instance?.FadeOut(_sceneName);
            });
        });
    }
}
