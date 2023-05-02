using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private LineDraw _lineDraw;

    private void Start() {
        GameManager.singleton.OnAllPlayersReady += OnAllPlayersReady_TurnOnRunAnimation;

        _lineDraw = GetComponentInChildren<LineDraw>();
        _animator = GetComponent<Animator>();
    }

    private void OnDestroy() {
        GameManager.singleton.OnAllPlayersReady -= OnAllPlayersReady_TurnOnRunAnimation;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.StartsWith("Character")){
            _animator.SetTrigger("Disappear");
        }
    }

    private void OnAllPlayersReady_TurnOnRunAnimation(){
        _animator.SetBool("IsRun", true);
    }
    public void LoseGameAfterDisappear(){
        GameManager.singleton.LoseShouldBe = true;
    }
}
