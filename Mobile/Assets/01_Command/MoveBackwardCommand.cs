/*-------------------------------------------------------
 * 
 *  [MoveBackwardCommand.cs]
 *  Author : 出合翔太 
 * 
 -------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 後ろ方向に移動するコマンド
/// </summary>
public class MoveBackwardCommand : Command
{
    private PlayerMove _playerMove;

    public MoveBackwardCommand(PlayerMove playerMove)
    {
        _playerMove = playerMove;
    }

    public override void Execute()
    {
        _playerMove?.MoveBackward();
    }

    public override void Undo()
    {
        _playerMove?.MoveForward();
    }

}
