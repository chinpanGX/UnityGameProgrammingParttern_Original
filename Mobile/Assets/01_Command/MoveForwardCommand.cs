/*-------------------------------------------------------
 * 
 *  [MoveForwardCommand.cs]
 *  Author : 出合翔太 
 * 
 -------------------------------------------------------*/
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/// <summary>
/// 前方向に移動するコマンド
/// </summary>
public class MoveForwardCommand : Command
{
    private PlayerMove _playerMove;

    public MoveForwardCommand(PlayerMove playerMove)
    {
        _playerMove = playerMove;
    }

    public override void Execute()
    {
        _playerMove?.MoveForward();
    }

    public override void Undo()
    {
        _playerMove?.MoveForward();
    }
}
