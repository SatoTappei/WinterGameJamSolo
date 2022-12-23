using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UniRx;
using MessagePipe;
using VContainer;
using VContainer.Unity;

/// <summary>
/// CinemachineにFollowするオブジェクトを設定するコンポーネント
/// </summary>
public class VcamTargetFollower : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _vcam;
    [Inject] ISubscriber<StickData> _subscriber;

    [Header("カメラの追従に合わせて動かしたいオブジェクト")]
    [SerializeField] Transform[] _reservedChild;

    float _currentPosY;

    void Start()
    {
        // このオブジェクトをカメラは追従する
        GameObject follower = new GameObject();
        follower.name = "VcamFollower";

        // _reservedChildの中身を子として登録する
        foreach (Transform t in _reservedChild)
            t.SetParent(follower.transform);

        _vcam.Follow = follower.transform;

        // 購読したメッセージのデータのY座標が現在設定されている値より高ければ
        // VcamFollowerのY座標を更新する
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
