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
    bool _battle;
    bool _enemyCreate;

    //Current turn information
    int _currentPlayer = 0;
    int _tileMovementAmount;
    int _counter = 0;

    //Enemy Initialiation info
    int enemyHealth;
    int enemyDamage;

    //Defines class references
    Card _card = new Card();
    Enemies _enemies = new Enemies();
    Die _die = new Die();

    // Start is called before the first frame update1

    void Start()
    {
        _board.InitTilePositions();
        _text.text = "Press 'Space' to roll the dice";
        _players[_currentPlayer]._playerHealth = 100;
    }

    void CheckWin()
    {
        if (_gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene("BoardGame");
            _text.text = $"Game Over! You lose! Press 'Space' to play again";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if ((_players[0].GetCurrentTile() == 88) && !_isMoving)
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

    void enemyBattle()
    {
        if (!_enemyCreate)
        {
            _enemies._enemyIndex = Random.Range(0, 4);
            //_enemies.getEnemySprite();
            //enemyHealth = _enemies.getEnemyHealth();
            enemyHealth = 30;
            //enemyDamage = _enemies.getEnemyDamage;
            enemyDamage = 10;

            _enemyCreate = true;
        }

        _text.text = $"{_enemies.getEnemyName()} approaches\n{enemyHealth} Health" +
        $"\nType space to attack\n\n\nHealth; {_players[_currentPlayer]._playerHealth}";

        if (Input.GetKeyDown("space"))
        {
            Debug.Log($"enemy health; {enemyHealth}");
            enemyHealth -= 10;

            _players[_currentPlayer]._playerHealth -= enemyDamage;
        }

        if (enemyHealth <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            _battle = false;
            _enemyCreate = false;
            _counter = 0;
        }

        else if (_players[_currentPlayer]._playerHealth <= 0)
        {
            _battle = false;
            _enemyCreate = false;
            _gameIsOver = true;
            _counter = 0;
        }
    }

    void bossBattle()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
        if (!_gameIsOver)
        {
            _currentPos = _players[_currentPlayer].GetPosition();

            if (Input.GetKeyDown(KeyCode.Space) && _tileMovementAmount == 0 && !_isMoving)
            {
                if (!_battle)
                {
                    ++_counter;
                    Debug.Log($"turn counter; {_counter}");
                }

                if (_counter == 5)
                {
                    _battle = true;
                    enemyBattle();
                }
                
                if (!_battle)
                {
                    _tileMovementAmount = _die.RollDice();
                    _text.text = $"You Rolled a {_tileMovementAmount.ToString()}";
                    _turnStarted = true;
                }
                
            }

            if (_tileMovementAmount > 0 && !_isMoving && !_battle)
            {
                MoveOneTile();
            }

            if (_isMoving && !_battle)
            {
                UpdatePosition();
            }

            if (_tileMovementAmount == 0 && !_isMoving && !_battle)
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