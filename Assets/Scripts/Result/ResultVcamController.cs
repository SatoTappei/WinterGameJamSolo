using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

/// <summary>
/// 指定したオブジェクトの全体が映るようにCinemachineを操作するコンポーネント
/// </summary>
public class ResultVcamController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _vcam;

    void Start()
    {
        // 全体を映したいオブジェクトを階層下の物を含めて全て取得して配列に格納する
        GameObject go = GameObject.FindGameObjectWithTag(Utility.PlayerTag);
        Transform[] all = go.transform.GetComponentsInChildren<Transform>();

        // 階層下のものを全部検索したので、全体を調べるには
        // 一度配列に格納したものを走査しなくてはならない
        // 一番高い位置にあるオブジェクトのY座標を取得
        float y = 0;
        foreach (Transform t in all)
            y = Mathf.Max(y, t.position.y);

        // カメラのサイズを良い感じに調整
        _vcam.m_Lens.OrthographicSize = (y / 2) + 2;
        // 全体が映るようにカメラがFollowするオブジェクトの位置を真ん中に持ってくる
        GameObject follower = new GameObject();
        follower.transform.position = Vector3.up * (y / 2);

        _vcam.Follow = follower.transform;
    }
}
