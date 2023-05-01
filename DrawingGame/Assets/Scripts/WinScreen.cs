using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Levelsnfo _levelsInfo;

    private void Awake() {
        _restartButton.onClick.AddListener(()=>{
            SceneManager.LoadScene(_levelsInfo.CurrentLevelIndex);
        });
        _nextButton.onClick.AddListener(()=>{
            _levelsInfo.CurrentLevelIndex += 1;
            SceneManager.LoadScene(_levelsInfo.CurrentLevelIndex);
        });
    }
}
