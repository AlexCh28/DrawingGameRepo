using DG.Tweening;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private void Awake() {
        GetComponentInChildren<LineDraw>().OnDrawingComplete += OnDrawingComplete_Movement;
    }

    private void OnDestroy() {
        GetComponentInChildren<LineDraw>().OnDrawingComplete -= OnDrawingComplete_Movement;
    }

    private void OnDrawingComplete_Movement(Vector3[] waypoints){
        transform.DOPath(waypoints, 5, PathType.Linear, PathMode.TopDown2D);
    }
}
