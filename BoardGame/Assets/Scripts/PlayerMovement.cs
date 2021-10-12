using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Inspector values
    [SerializeField] private List<Player> _players;
    public float _speed;

    [SerializeField] private Board _board;
    [SerializeField] private Text _text;

    //Positional values
    Vector2 _currentPos;
    Vector2 _nextPos;

    //Time values
    float _totalTime;
    float _deltaT;

    //Game turn data
    bool _isMoving;
    bool _gameIsOver;
    bool _turnStarted;

    //Current turn information

    int _currentPlayer = 0;
    int _tileMovementAmount;

    //Our die
    Die _die = new Die();

    // Start is called before the first frame update1

    void Start()
    {
        _board.InitTilePositions();
        _text.text = "Press 'Space' to roll the dice";
    }

    void CheckWin()
    {
        if (_gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("BoardGame");
        }

        if ((_players[0].GetCurrentTile() == 100) && !_isMoving)
        {
            _gameIsOver = true;
            _text.text = $"Game Over! You win! Press 'Space' to play again";
        }
    }

    void MoveOneTile()
    {
        _nextPos = _board.GetTilePositions()[_players[_currentPlayer].GetCurrentTile()];

        _totalTime = (_nextPos - _currentPos / _speed).magnitude;
        //_totalTime = 0.1f;
        _isMoving = true;
        _players[_currentPlayer].SetCurrentTile(_players[_currentPlayer].GetCurrentTile() + 1);
    }

    void UpdatePosition()
    {
        _deltaT += Time.deltaTime / _totalTime;

        if (_deltaT < 0f)
        {
            _deltaT = 0f;
        }
        if (_deltaT >= 1f || _nextPos == _currentPos)
        {
            _isMoving = false;
            _tileMovementAmount--;
            _deltaT = 0f;
        }

        _players[_currentPlayer].SetPosition(Vector2.Lerp(_currentPos, _nextPos, _deltaT));



    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
        if (!_gameIsOver)
        {
            _currentPos = _players[_currentPlayer].GetPosition();


            if (Input.GetKeyDown(KeyCode.Space) && _tileMovementAmount == 0)
            {
                _tileMovementAmount = _die.RollDice();
                _text.text = $"You Rolled a {_tileMovementAmount.ToString()}";
                _turnStarted = true;
            }

            if (_tileMovementAmount > 0 && !_isMoving)
            {
                MoveOneTile();
            }


            if (_isMoving)
            {

                UpdatePosition();

            }


            if (_tileMovementAmount == 0 && !_isMoving)
            {
                _text.text = "Press 'Space' to roll the dice!";
                if (_turnStarted)
                {
                    _turnStarted = false;

                }
            }
        }
    }
}