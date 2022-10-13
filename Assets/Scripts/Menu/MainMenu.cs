using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _start;
    void Start()
    {
        _start.onClick.AddListener(StartGame);
    }

    private void StartGame(){
        SceneManager.LoadScene(1);
    }
}
