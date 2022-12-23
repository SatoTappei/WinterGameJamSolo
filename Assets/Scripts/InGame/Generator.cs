using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using MessagePipe;
using VContainer;
using VContainer.Unity;

/// <summary>
/// ��ރI�u�W�F�N�g�𐶐�����R���|�[�l���g
/// </summary>
public class Generator : MonoBehaviour, IManageable
{
    [Inject] IObjectResolver _resolver;

    [SerializeField] GameObject[] _items;
    [SerializeField] GameObject _bom;
    [Header("�{���𐶐�����m��(%)")]
    [SerializeField] int _bomRate;
    [Header("��������Ԋu")]
    [SerializeField] int _distance;

    CancellationTokenSource cts;

    async UniTaskVoid BootAsync(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();

            // ��ނƃ{���ǂ���𐶐����邩�����_���Ō��肵
            // ��ނ̏ꍇ�͂ǂ̋�ނ𐶐����邩�����_���Ō��肷��
            GameObject go = Random.Range(0, 100) < _bomRate ? _bom : _items[Random.Range(0, _items.Length)];
            _resolver.Instantiate(go);

            await UniTask.DelayFrame(_distance * 60);
        }
    }

    /// <summary>�������J�n����</summary>
    public void Boot() 
    {
        cts = new CancellationTokenSource();
        _ = BootAsync(cts.Token);
    }

    /// <summary>�������~�߂�</summary>
    public void Stop() => cts.Cancel();
}
