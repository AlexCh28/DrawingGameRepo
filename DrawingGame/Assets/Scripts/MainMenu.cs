using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;

    private void Awake() {
        _playButton.onClick.AddListener(()=>{
            SceneManager.LoadScene("Level_1");
        });
    }
}
