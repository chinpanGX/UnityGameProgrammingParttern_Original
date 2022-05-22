/*-------------------------------------------------------
 *  
 *  [GameController.cs]
 *  Author : 出合翔太
 * 
 -------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameController : MonoBehaviour
{
    private PlayerMove _playerMove;

    // キーボードの割り当てとコマンドを紐付ける
    private Command _commandBottonW;   
    private Command _commandBottonA;   
    private Command _commandBottonS;   
    private Command _commandBottonD;

    private Stack<Command> _undoCommands = new Stack<Command>();
    private Stack<Command> _redoCommands = new Stack<Command>();

    private bool _isReplaying = false;

    // リプレイ機能のために開始位置を保存しておく
    private Vector3 _startPosition;

    // 何が起きているか確認するために、各コマンド実行間隔をリプレイする
    private const float _replayPauseTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを取得
        _playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        
        // 開始位置
        _startPosition = _playerMove.transform.position;

        //コマンドにバインドする
        _commandBottonW = new MoveForwardCommand(_playerMove);
        _commandBottonS = new MoveBackwardCommand(_playerMove);
        _commandBottonA = new MoveLeftCommand(_playerMove);
        _commandBottonD = new MoveRightCommand(_playerMove);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    /// <summary>
    /// コマンドを実行
    /// </summary>
    public void ExecuteForwaod()
    {
        ExecuteNewCommand(_commandBottonW);
    }

    public void ExecuteBack()
    {
        ExecuteNewCommand(_commandBottonS);
    }

    public void ExecuteRight()
    {
        ExecuteNewCommand(_commandBottonD);
    }

    public void ExecuteLeft()
    {
        ExecuteNewCommand(_commandBottonA);
    }

    public void ExecuteRedo()
    {
        if(_redoCommands.Count == 0)
        {
            Debug.Log("やり直しできない");
        }
        else
        {
            Command nextCommand = _redoCommands.Pop();
            nextCommand.Execute();
            _undoCommands.Push(nextCommand);
        }
    }

    public void ExecuteUndo()
    {
        if (_undoCommands.Count == 0)
        {
            Debug.Log("戻せない");
        }
        else
        {
            Command lastCommand = _undoCommands.Pop();
            lastCommand.Undo();
            _redoCommands.Push(lastCommand);
        }
    }

    public void ExecuteSwapRightandLeft()
    {
        SwapCommand(ref _commandBottonA, ref _commandBottonD);
    }
    
    public void ExecuteStartReplay()
    {
        _isReplaying = true;
        StartCoroutine(Replay());        
    }

    /// <summary>
    /// リプレイ機能
    /// </summary>
    private IEnumerator Replay()
    {
        // スタート位置にオブジェクトを移動させる
        _playerMove.transform.position = _startPosition;

        // スタート位置で開始したことがわかるように一時停止する
        yield return new WaitForSeconds(_replayPauseTimer);

        // Stackと配列にする
        Command[] oldCommnads = _undoCommands.ToArray();

        // 配列の後ろから順にコマンドを実行する
        for(int i = oldCommnads.Length -1; i >= 0; i--)
        {
            Command command = oldCommnads[i];
            command.Execute();
            yield return new WaitForSeconds(_replayPauseTimer);
        }

        _isReplaying = false;
    }

    /// <summary>
    /// コマンドを実行するときに使うヘルパー関数
    /// </summary>
    /// <param name="command">実行したいコマンド </param>
    private void ExecuteNewCommand(Command command)
    {
        command.Execute();
        // 新しいコマンドをPushする        
        _undoCommands.Push(command);
        // Redoはコマンドは削除する
        _redoCommands.Clear();
    }
  
    /// <summary>
    /// コマンドを入れ替える
    /// refキーワード・・・参照渡しを示す
    /// </summary>
    private void SwapCommand(ref Command cmd1, ref Command cmd2)
    {
        Command tmp = cmd1;
        cmd1 = cmd2;
        cmd2 = tmp;
    }
}
