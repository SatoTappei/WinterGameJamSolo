using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

/// <summary>
/// フェードの処理を行うコンポーネント
/// Singleton
/// </summary>
public class FadeSystem : MonoBehaviour
{
    public static FadeSystem Instance;

    [SerializeField] RawImage _img;
    [Header("フェードにかかる時間")]
    [SerializeField] float _time;

    public bool IsFading { get; private set; }

    void Awake()
    {
        Instance = this;

        SceneManager.activeSceneChanged += FadeIn;
    }

    void OnDestroy()
    {
        SceneManager.activeSceneChanged -= FadeIn;
        Instance = null;
    }

    void FadeIn(Scene _, Scene __)
    {
        if (IsFading) return;

        _img.DOFade(0, _time)
            .OnStart(() =>
            {
                IsFading = true;
            })
            .OnComplete(() =>
            {
                IsFading = false;
                _img.enabled = false;
            });
    }

    /// <summary>
    /// DotWeenを使用したフェードアウト
    /// </summary>
    /// <param name="scene">次のシーン名</param>
    public void FadeOut(string scene)
    {
        if (IsFading) return;

        _img.DOFade(1, _time)
            .OnStart(() =>
            {
                IsFading = true;
                _img.enabled = true;
            })
            .OnComplete(() =>
            {
                IsFading = false;

                SceneManager.LoadScene(scene);
            });
    }
}
