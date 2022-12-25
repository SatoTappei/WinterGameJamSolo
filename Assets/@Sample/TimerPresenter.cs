using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// �c�莞�Ԃ̃^�C�}�[�p��Presenter
/// </summary>
public class TimerPresenter : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] InGameTimer _timer;
    [SerializeField] InGameStream _inGameStream;

    void Start()
    {
        _timer.Count.Subscribe(i => _text.text = Mathf.Max(0, i).ToString())
                    .AddTo(this);

        _text.text = _inGameStream?.TimeLimit.ToString();
    }
}
