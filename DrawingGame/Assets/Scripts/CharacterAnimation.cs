using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private LineDraw _lineDraw;

    private void Awake() {
        GameManager.singleton.OnAllPlayersReady += OnAllPlayersReady_TurnOnRunAnimation;

        _lineDraw = GetComponentInChildren<LineDraw>();
        _animator = GetComponent<Animator>();
    }

    private void OnDestroy() {
        GameManager.singleton.OnAllPlayersReady -= OnAllPlayersReady_TurnOnRunAnimation;
    }

    private void OnAllPlayersReady_TurnOnRunAnimation(){
        _animator.SetBool("IsRun", true);
    }
}
