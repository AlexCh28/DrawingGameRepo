using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public bool PathFinished => GetComponentInChildren<LineDraw>().IsFinished;
    public bool MovementFinished => GetComponent<CharacterMovement>().MovementFinished;
}
