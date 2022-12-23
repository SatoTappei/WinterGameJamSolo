using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UniRx;
using MessagePipe;
using VContainer;
using VContainer.Unity;

/// <summary>
/// Cinemachine��Follow����I�u�W�F�N�g��ݒ肷��R���|�[�l���g
/// </summary>
public class VcamTargetFollower : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _vcam;
    [Inject] ISubscriber<StickData> _subscriber;

    [Header("�J�����̒Ǐ]�ɍ��킹�ē����������I�u�W�F�N�g")]
    [SerializeField] Transform[] _reservedChild;

    float _currentPosY;

    void Start()
    {
        // ���̃I�u�W�F�N�g���J�����͒Ǐ]����
        GameObject follower = new GameObject();
        follower.name = "VcamFollower";

        // _reservedChild�̒��g���q�Ƃ��ēo�^����
        foreach (Transform t in _reservedChild)
            t.SetParent(follower.transform);

        _vcam.Follow = follower.transform;

        // �w�ǂ������b�Z�[�W�̃f�[�^��Y���W�����ݐݒ肳��Ă���l��荂�����
        // VcamFollower��Y���W���X�V����
        _subscriber.AsObservable()
                   .Where(stickData => _currentPosY < stickData.Trans.position.y)
                   .Subscribe(stickData=> 
                   {
                       Vector3 pos = transform.position;
                       pos.y = stickData.Trans.position.y;

                       follower.transform.position = pos;

                       _currentPosY = pos.y;
                   }).AddTo(this);
    }
}
