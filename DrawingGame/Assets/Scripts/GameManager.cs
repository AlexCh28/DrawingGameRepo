using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnAllPlayersReady;

    private CharacterInfo[] _players;

    private bool _testShouldBeStarted;
    private bool _winShouldBe;
    public static GameManager singleton;

    private void Awake() {
        singleton = this;

        _winShouldBe = true;
        _testShouldBeStarted = true;
        _players = FindObjectsOfType<CharacterInfo>();
    }

    private void FixedUpdate() {
        if (_players.Length <= 0) return;

        if (_testShouldBeStarted && CheckAllPathFinished()) {OnAllPlayersReady?.Invoke(); _testShouldBeStarted=false;}

        if (_winShouldBe && CheckAllMovementFinished()) {print("win"); _winShouldBe = false;}
    }

    private bool CheckAllPathFinished(){
        bool result = true;

        foreach(CharacterInfo player in _players){
            result = result && player.PathFinished;
        }

        return result;
    }

    private bool CheckAllMovementFinished(){
        bool result = true;

        foreach(CharacterInfo player in _players){
            result = result && player.MovementFinished;
        }

        return result;
    }
}
