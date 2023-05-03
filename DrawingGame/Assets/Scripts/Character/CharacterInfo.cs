using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField]
    private PlayerSkinInfo _playerSkinInfo;

    public PlayerSkinInfo PlayerSkinInfo => _playerSkinInfo;

    public bool PathFinished => GetComponentInChildren<LineDraw>().IsFinished;
    public bool MovementFinished => GetComponent<CharacterMovement>().MovementFinished;

    private void Awake() {
        GetComponent<SpriteRenderer>().sprite = _playerSkinInfo.Sprites[_playerSkinInfo.SkinIndex];
        GetComponent<Animator>().SetLayerWeight(_playerSkinInfo.SkinIndex, 1f);
    }
}
