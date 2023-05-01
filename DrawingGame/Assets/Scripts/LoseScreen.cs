using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Levelsnfo _levelsInfo;

    private void Awake() {
        _restartButton.onClick.AddListener(()=>{
            SceneManager.LoadScene(_levelsInfo.CurrentLevelIndex);
        });
    }
}
