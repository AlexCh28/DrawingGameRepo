using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    [SerializeField]
    private PlayerSkinInfo _playerSkinInfo;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Button _leftButton;
    [SerializeField]
    private Button _rightButton;

    private int _skinIndex;

    private void Awake() {
        _playerSkinInfo.SkinIndex = _skinIndex;

        _leftButton.onClick.AddListener(()=>{
            _skinIndex = _skinIndex-1 < 0 ? _playerSkinInfo.Sprites.Count-1 : _skinIndex-1;
            _playerSkinInfo.SkinIndex = _skinIndex;
            _image.sprite = _playerSkinInfo.Sprites[_skinIndex];
        });

        _rightButton.onClick.AddListener(()=>{
            _skinIndex = _skinIndex+1 >= _playerSkinInfo.Sprites.Count ? 0 : _skinIndex+1;
            _playerSkinInfo.SkinIndex = _skinIndex;
            _image.sprite = _playerSkinInfo.Sprites[_skinIndex];
        });
    }
}
