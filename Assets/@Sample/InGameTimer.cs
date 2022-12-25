using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

/// <summary>
/// �C���Q�[�����̎c�莞�Ԃ𐧌䂷��
/// </summary>
public class InGameTimer : MonoBehaviour
{
    ReactiveProperty<int> _count = new ReactiveProperty<int>();

    public IReadOnlyReactiveProperty<int> Count { get => _count; }

    int _penalty;

    void Start()
    {
        //_ = Timer(5, this.GetCancellationTokenOnDestroy());
    }

    /// <summary>
    /// 1�b���ƂɎ��Ԃ������Ă����^�C�}�[�A�J�E���g��0�ɂȂ�Ə����𔲂���
    /// </summary>
    public async UniTask Timer(int max, CancellationToken token)
    {
        _count.Value = max;

        await Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
                        .Select(count => 
                        {
                            token.ThrowIfCancellationRequested();

                            // _count.Value��0��菬�����Ȃ邱�Ƃ�����̂ōw�ǂ��鑤�Ŋۂ߂��ނ���
                            // �ő�l - ���ݒl - ���e�ɂԂ������y�i���e�B
                            int time = (int)(max - count);
                            _count.Value = time - _penalty;

                            return _count.Value;
                        })
                        .TakeWhile(i => i > 0);
    }

    /// <summary>���e�����������Ƃ��Ɏc�莞�Ԃ����炷</summary>
    public void SetPenalty(int value)
    {
        _penalty += value;
    }
}
