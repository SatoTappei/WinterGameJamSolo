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

    [Header("�����ӏ��̍��E�̒[")]
    [SerializeField] Transform _borderLeft;
    [SerializeField] Transform _borderRight;

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

            // �����ӏ��������_���ō��E�ɐU��
            float rx = Random.Range(_borderLeft.position.x, _borderRight.position.x);
            Vector3 pos = transform.position;
            pos.x += rx;

            // ��ނƃ{���ǂ���𐶐����邩�����_���Ō��肵
            // ��ނ̏ꍇ�͂ǂ̋�ނ𐶐����邩�����_���Ō��肷��
            GameObject go = Random.Range(0, 100) < _bomRate ? _bom : _items[Random.Range(0, _items.Length)];
            _resolver.Instantiate(go, pos, Quaternion.identity);

            // �����y�[�X�Ƀ����_��������������
            float rt = Random.Range(0.9f, 1.1f);
            await UniTask.Delay(System.TimeSpan.FromSeconds(_distance * rt));
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
