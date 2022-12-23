using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    /// <summary>
    /// シーン上に配置されるIManageableインターフェースを実装したコンポーネントの数に応じて
    /// リストのキャパシティを設定しておく
    /// </summary>
    const int ManageableListCap = 2;
    List<IManageable> _manageableList = new List<IManageable>(ManageableListCap);

    void Start()
    {
        // MonoBehaviourを継承したクラスを検索して
        // IManageableにキャスト出来たら管理するためにリストに追加する
        foreach (MonoBehaviour c in FindObjectsOfType<MonoBehaviour>())
        {
            IManageable iManageable = c as IManageable;
            if (c as IManageable != null)
            {
                _manageableList.Add(iManageable);

                // オブジェクトの処理を開始する
                iManageable.Boot();
            }
        }
    }

    void Update()
    {
        // リスト内の要素全部にStop()を呼んでやることで止めることが出来る。
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _manageableList.ForEach(im => im.Stop());
        }
    }
}
