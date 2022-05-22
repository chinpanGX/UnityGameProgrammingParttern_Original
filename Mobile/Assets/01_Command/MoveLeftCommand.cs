/*-------------------------------------------------------
 * 
 *  [MoveLeftCommand.cs]
 *  Author : 出合翔太  
 * 
 -------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 左方向に移動するコマンド
/// </summary>
public class MoveLeftCommand : Command
{
    private PlayerMove _playerMove;

    public MoveLeftCommand(PlayerMove playerMove)
    {
        _playerMove = playerMove;
    }

    public override void Execute()
    {
        _playerMove?.MoveLeft();
    }

    public override void Undo()
    {
        _playerMove?.MoveRight();
    }
}
