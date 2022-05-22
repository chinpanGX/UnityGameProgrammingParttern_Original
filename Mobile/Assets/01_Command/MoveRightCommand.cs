/*-------------------------------------------------------
 * 
 *  [MoveRightCommand.cs]
 *  Author : 出合翔太
 * 
 -------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 右方向に移動するコマンド
/// </summary>
public class MoveRightCommand : Command
{
    private PlayerMove _playerMove;

    public MoveRightCommand(PlayerMove playerMove)
    {
        _playerMove = playerMove;
    }

    public override void Execute()
    {
        _playerMove?.MoveRight();
    }
    public override void Undo()
    {
        _playerMove?.MoveLeft();
    }
}
