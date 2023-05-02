using DG.Tweening;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3[] _waypoints;

    private bool _movementFinished;

    public bool MovementFinished => _movementFinished;


    private void Start() {
        GetComponentInChildren<LineDraw>().OnDrawingComplete += OnDrawingComplete_Movement;
        GameManager.singleton.OnAllPlayersReady += OnAllPlayersReady_Movement;

        _movementFinished = false;
    }

    private void OnDestroy() {
        GetComponentInChildren<LineDraw>().OnDrawingComplete -= OnDrawingComplete_Movement;
        GameManager.singleton.OnAllPlayersReady -= OnAllPlayersReady_Movement;
    }

    private void OnDrawingComplete_Movement(Vector3[] waypoints){
        _waypoints = waypoints;
    }

    private void OnAllPlayersReady_Movement(){
        transform.DOPath(_waypoints, 5, PathType.Linear, PathMode.TopDown2D).OnComplete(() => _movementFinished = true);
    }
}
