using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;
public class GameBehavior : MonoBehaviour, IManager
{
    public bool showWinScreen = false;
    public string labelText = "Collect all 3 keys to unlock the boss chamber!";
    public int maxItems = 3;
    public bool showLossScreen = false;

    private int _itemsCollected = 0;
    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    public int Items
    {
        get { return _itemsCollected; }

        set
        {
            _itemsCollected = value;
            
            if(_itemsCollected >= maxItems)
            {
                labelText = "You've found all the keys! Head to the boss chamber for the final fight";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Key found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 10;

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            if(_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's gotta hurt.";
            }
        }
    }
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Manager initialized..";
        _state.FancyDebug();
        Debug.Log(_state);
    }
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Keys Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 -50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }
        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 -50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }
    }
}
