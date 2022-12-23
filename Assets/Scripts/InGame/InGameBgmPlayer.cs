using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// インゲームのBGMを再生するコンポーネント
/// </summary>
public class InGameBgmPlayer : MonoBehaviour
{
    public void Play()
    {
        SoundManager.Instance?.PlayBGM("インゲームBGM");
    }
}
