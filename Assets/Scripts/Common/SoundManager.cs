using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using DG.Tweening;

/// <summary>
/// シーンで使用するサウンドを登録するコンポーネント
/// Singleton
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Serializable]
    public struct SoundData
    {
        [Tooltip("Play()メソッドで呼び出す際のキー")]
        [SerializeField] private string name;
        [Tooltip("Play()メソッドで呼び出す音")]
        [SerializeField] private AudioClip clip;
        [Tooltip("再生時の音量")]
        [SerializeField] private float volume;

        public string Name { get => name; }
        public AudioClip Clip { get => clip; }
        public float Volume { get => volume; }
    }

    public static SoundManager Instance;

    /// <summary>AudioSourceコンポーネントを付ける数<summary>
    readonly int SourcesLength = 10;

    [Header("このシーンで使う音を登録する")]
    [SerializeField] SoundData[] _sounds;

    AudioSource[] _sources;
    Dictionary<string, SoundData> _dic;

    void Awake()
    {
        // 同じシーン内に2つ以上置く想定をしていないのでif文による分岐は端折っている
        Instance = this;

        _sources = new AudioSource[SourcesLength];
        for (int i = 0; i < SourcesLength; i++)
            _sources[i] = gameObject.AddComponent<AudioSource>();

        _dic = _sounds.ToDictionary(soundData => soundData.Name, soundData => soundData);
    }

    /// <summary>文字列でkeyを指定してSEを再生</summary>
    public void PlaySE(string key)
    {
        // 音を鳴らす間隔の設定をしていないので連続して音が鳴るようになっている
        SoundData? data = GetSoundData(key);
        AudioSource source = GetAudioSource();

        // 音と未使用のAudioSourceが存在する場合のみ再生する
        if (data != null && source != null)
        {
            source.clip = data?.Clip;
            source.volume = (float)(data?.Volume);
            source.Play();
        }
    }

    /// <summary>文字列でKeyを指定してBGMを再生</summary>
    public void PlayBGM(string key)
    {
        SoundData? data = GetSoundData(key);

        if (data != null)
        {
            // 音を鳴らす間隔の設定をしていないので連続して音が鳴るようになっている
            AudioSource source = _sources[SourcesLength - 1];
            source.clip = data?.Clip;
            source.volume = (float)(data?.Volume);
            source.loop = true;
            source.Play();
        }
    }

    /// <summary>BGMをフェードアウトさせる</summary>
    public void FadeOutBGM(float duration = 0.5f)
    {
        _sources[SourcesLength - 1].DOFade(0, duration).SetLink(gameObject);
    }

    /// <summary>キーに対応したSoundDataを返す</summary>
    SoundData? GetSoundData(string key)
    {
        if (_dic.TryGetValue(key, out SoundData data))
        {
            return data;
        }
        else
        {
            Debug.LogWarning("音が登録されていません:" + key);
            return null;
        }
    }

    /// <summary>使用していないAudioSourceを返す</summary>
    AudioSource GetAudioSource()
    {
        // 一番後ろのAudioSourceはBGM用に取っておく
        for (int i = 0; i < SourcesLength - 1; i++)
            if (!_sources[i].isPlaying)
                return _sources[i];

        Debug.LogWarning("AudioSourceが足りません");
        return null;
    }
}
