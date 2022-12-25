using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの位置を示す半透明のバーのコンポーネント
/// </summary>
public class TranslucentBar : MonoBehaviour
{
    [SerializeField] Transform _target;

    void Update()
    {
        // バーの大きさの半分だけずらす
        Vector3 pos = _target.position;
        pos.y += 50;

        transform.position = pos;
    }
}
