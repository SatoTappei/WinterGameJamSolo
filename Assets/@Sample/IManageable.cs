using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム開始時とゲームオーバー時にそれぞれ実行される処理のインターフェース
/// </summary>
public interface IManageable
{
    /// <summary>ゲーム開始時に呼ばれる処理</summary>
    public void Boot();
    /// <summary>ゲームオーバー時に呼ばれる処理</summary>
    public void Stop();
}
