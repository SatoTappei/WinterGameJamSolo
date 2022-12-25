using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using DG.Tweening;

/// <summary>
/// �V�[���Ŏg�p����T�E���h��o�^����R���|�[�l���g
/// Singleton
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Serializable]
    public struct SoundData
    {
        [Tooltip("Play()���\�b�h�ŌĂяo���ۂ̃L�[")]
        [SerializeField] private string name;
        [Tooltip("Play()���\�b�h�ŌĂяo����")]
        [SerializeField] private AudioClip clip;
        [Tooltip("�Đ����̉���")]
        [SerializeField] private float volume;

        public string Name { get => name; }
        public AudioClip Clip { get => clip; }
        public float Volume { get => volume; }
    }

    public static SoundManager Instance;

    /// <summary>AudioSource�R���|�[�l���g��t���鐔<summary>
    readonly int SourcesLength = 10;

    [Header("���̃V�[���Ŏg������o�^����")]
    [SerializeField] SoundData[] _sounds;

    AudioSource[] _sources;
    Dictionary<string, SoundData> _dic;

    void Awake()
    {
        // �����V�[������2�ȏ�u���z������Ă��Ȃ��̂�if���ɂ�镪��͒[�܂��Ă���
        Instance = this;

        _sources = new AudioSource[SourcesLength];
        for (int i = 0; i < SourcesLength; i++)
            _sources[i] = gameObject.AddComponent<AudioSource>();

        _dic = _sounds.ToDictionary(soundData => soundData.Name, soundData => soundData);
    }

    /// <summary>�������key���w�肵��SE���Đ�</summary>
    public void PlaySE(string key)
    {
        // ����炷�Ԋu�̐ݒ�����Ă��Ȃ��̂ŘA�����ĉ�����悤�ɂȂ��Ă���
        SoundData? data = GetSoundData(key);
        AudioSource source = GetAudioSource();

        // ���Ɩ��g�p��AudioSource�����݂���ꍇ�̂ݍĐ�����
        if (data != null && source != null)
        {
            source.clip = data?.Clip;
            source.volume = (float)(data?.Volume);
            source.Play();
        }
    }

    /// <summary>�������Key���w�肵��BGM���Đ�</summary>
    public void PlayBGM(string key)
    {
        SoundData? data = GetSoundData(key);

        if (data != null)
        {
            // ����炷�Ԋu�̐ݒ�����Ă��Ȃ��̂ŘA�����ĉ�����悤�ɂȂ��Ă���
            AudioSource source = _sources[SourcesLength - 1];
            source.clip = data?.Clip;
            source.volume = (float)(data?.Volume);
            source.loop = true;
            source.Play();
        }
    }

    /// <summary>BGM���t�F�[�h�A�E�g������</summary>
    public void FadeOutBGM(float duration = 0.5f)
    {
        _sources[SourcesLength - 1].DOFade(0, duration).SetLink(gameObject);
    }

    /// <summary>�L�[�ɑΉ�����SoundData��Ԃ�</summary>
    SoundData? GetSoundData(string key)
    {
        if (_dic.TryGetValue(key, out SoundData data))
        {
            return data;
        }
        else
        {
            Debug.LogWarning("�����o�^����Ă��܂���:" + key);
            return null;
        }
    }

    /// <summary>�g�p���Ă��Ȃ�AudioSource��Ԃ�</summary>
    AudioSource GetAudioSource()
    {
        // ��Ԍ���AudioSource��BGM�p�Ɏ���Ă���
        for (int i = 0; i < SourcesLength - 1; i++)
            if (!_sources[i].isPlaying)
                return _sources[i];

        Debug.LogWarning("AudioSource������܂���");
        return null;
    }
}
