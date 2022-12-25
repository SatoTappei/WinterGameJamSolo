using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 次のシーンに持ち越すオブジェクトに付けるコンポーネント
/// </summary>
public class CarryOverToNextScene : MonoBehaviour
{
    [Header("次のシーンに持ち越す際に剥がすコンポーネント")]
    [SerializeField] MonoBehaviour[] _removeComponents;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneUnloaded += Reset;
    }

    void Reset(Scene _)
    {
        foreach (MonoBehaviour mb in _removeComponents)
        {
            Destroy(mb);
        }

        // 座標を初期化する
        transform.position = Vector3.zero;

        // このシーンから遷移したら削除されるように設定する
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        SceneManager.sceneUnloaded -= Reset;
    }
}
