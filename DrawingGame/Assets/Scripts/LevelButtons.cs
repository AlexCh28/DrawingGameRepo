using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _hintButton;
    [SerializeField]
    private GameObject _hintLine1;
    [SerializeField]
    private GameObject _hintLine2;
    [SerializeField]
    private GameObject _hintLine3;

    private void Awake() {
        _restartButton.onClick.AddListener(()=>{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        _hintButton.onClick.AddListener(()=>{
            SwitchHintLine(_hintLine1);
            SwitchHintLine(_hintLine2);
            SwitchHintLine(_hintLine3);
        });
    }

    private void SwitchHintLine(GameObject hintLine){
        if (hintLine == null) return;

        hintLine.SetActive(!hintLine.activeInHierarchy);
    }
}
