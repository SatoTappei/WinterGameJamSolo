using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IManageableインターフェースを実装したコンポーネントを管理するクラス
/// </summary>
public class ManageableManager
{
    List<IManageable> _manageableList;

    public ManageableManager(int capacity)
    {
        // シーン上に配置されるIManageableインターフェースを実装したコンポーネントの数に応じて
        // リストのキャパシティを設定しておく
        _manageableList = new List<IManageable>(capacity);
    }

    public void Start()
    {
        // 汎用的だがすごい重い処理なので保留
        // MonoBehaviourを継承したクラスを検索し、IManageableにキャスト出来たら管理するためにリストに追加する
        //foreach (Component c in Object.FindObjectsOfType<Component>())
        //{
        //    IManageable iManageable = c as IManageable;
        //    if (c as IManageable != null)
        //    {
        //        _manageableList.Add(iManageable);

        //        // オブジェクトの処理を開始する
        //        iManageable.Boot();
        //    }
        //}

        // インターフェースを実装したコンポーネントを手動で取得する
        // 限定的だがこっちのほうが軽いので今のところこれを使う
        // 取得&Boot()を呼ぶだけなので他のメソッドやコンポーネントに干渉していない
        Generator generator = Object.FindObjectOfType<Generator>();
        HorizontalController horiCon = Object.FindObjectOfType<HorizontalController>();
        generator.Boot();
        horiCon.Boot();
        _manageableList.Add(generator);
        _manageableList.Add(horiCon);
    }

    public void Stop()
    {
        _manageableList.ForEach(im => im.Stop());
    }
}
