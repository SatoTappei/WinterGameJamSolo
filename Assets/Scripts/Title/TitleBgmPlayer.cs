using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトルシーンのBGMを再生するコンポーネント
/// </summary>
public class TitleBgmPlayer : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance?.PlayBGM("タイトルBGM");
    }
}
