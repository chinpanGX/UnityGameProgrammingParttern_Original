/*------------------------------------------------------
 * 
 *  [DoNothingCommand.cs]
 *  Author : 出合翔太
 * 
 ------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コマンドをNULLにする代わりに使うオブジェクト -> NULLオブジェクト
/// </summary>
public class DoNothingCommand : Command
{
    public override void Execute()
    {
        
    }

    public override void Undo()
    {
        
    }
}