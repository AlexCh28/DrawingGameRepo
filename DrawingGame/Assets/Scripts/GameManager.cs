using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Levelsnfo _levelsInfo;
    public static GameManager singleton;
    public event Action OnAllPlayersReady;

    private CharacterInfo[] _players;

    private bool _testShouldBeStarted;
    private bool _winShouldBe;
    private bool _loseShouldBe;
    public bool LoseShouldBe { get{return _loseShouldBe;} set{_loseShouldBe = value;}}

    private void Awake() {
        singleton = this;

        _winShouldBe = true;
        _loseShouldBe = false;
        _testShouldBeStarted = true;
        _players = FindObjectsOfType<CharacterInfo>();

        _levelsInfo.CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void FixedUpdate() {
        if (_players.Length <= 0) return;

        if (_testShouldBeStarted && CheckAllPathFinished()) RunTest();

        if (_winShouldBe && CheckAllMovementFinished()) ActivateWinScene();

        if (_loseShouldBe) ActivateLoseScene();
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

    private void RunTest(){
        OnAllPlayersReady?.Invoke(); 
        _testShouldBeStarted=false;
    }

    private void ActivateWinScene(){ 
        _winShouldBe = false;
        SceneManager.LoadScene(0);
    }
    private void ActivateLoseScene(){ 
        _winShouldBe = false;
        _loseShouldBe = false;
        SceneManager.LoadScene(1);
    }
}
