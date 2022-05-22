/*-------------------------------------------------------
 * 
 *  [command.cs]
 *  Author : 出合翔太
 * 
 -------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コマンドの抽象クラス
/// </summary>
public abstract class Command
{
    public abstract void Execute(); // コマンドを実行
    public abstract void Undo();    // コマンドを戻す
}
