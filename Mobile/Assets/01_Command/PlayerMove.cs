using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  プレイヤーの移動を制御する
/// </summary>
public class PlayerMove : MonoBehaviour
{
    private float _Speed = 1f; // 移動速度

    /// <summary>
    /// コマンドで実行されるメソッド
    /// </summary>
    public void MoveForward()
    {
        Move(Vector3.forward);
    }
    public void MoveBackward()
    {
        Move(Vector3.back);
    }

    public void MoveLeft()
    {
        Move(Vector3.left);
    }
    public void MoveRight()
    {
        Move(Vector3.right);
    }

    /// <summary>
    /// 移動処理のヘルパーメソッド
    /// </summary>
    /// <param name="Dir"> 移動する方向のベクトル </param>
    private void Move(Vector3 Dir)
    {
        transform.Translate(Dir * _Speed);
    }
}
