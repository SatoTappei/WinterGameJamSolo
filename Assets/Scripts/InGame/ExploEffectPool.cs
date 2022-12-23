using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using MessagePipe;
using VContainer;

/// <summary>
/// ���e�����������Ƃ��̃G�t�F�N�g�̃I�u�W�F�N�g�v�[��
/// </summary>
public class ExploEffectPool : MonoBehaviour
{
    [Inject] ISubscriber<ExploData> _subscriber;
    [SerializeField] ExploEffect _effectPrefab;
    [SerializeField] int _size;

    Stack<ExploEffect> _pool;

    void Awake()
    {
        _pool = new Stack<ExploEffect>();

        for (int i = 0; i < _size; i++)
        {
            ExploEffect ee = Instantiate(_effectPrefab);
            // �������ɂ��̃N���X�ւ̎Q�Ƃ�n���A�I�u�W�F�N�g������v�[���ɖ߂�悤�ɂ���
            ee.Init(this);

            _pool.Push(ee);
        }
    }

    void Start()
    {
        // �v�[�����c���Ă���΍w�ǂ������b�Z�[�W�̃f�[�^�̍��W��n����
        // �I�u�W�F�N�g���A�N�e�B�u�ɂ���
        _subscriber.AsObservable()
            .Where(_ => _pool.Count > 0)       
            .Subscribe(exploData =>
            {
                ExploEffect ee = _pool.Pop();
                ee.Active(exploData.Trans.position);
            }).AddTo(this);
    }

    /// <summary>�v�[���ɃI�u�W�F�N�g��߂�</summary>
    public void ReturnPool(ExploEffect ee) => _pool.Push(ee);
}
