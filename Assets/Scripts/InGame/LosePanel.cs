using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization.Settings;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreThrows;
    [SerializeField] private TextMeshProUGUI _bestScoreThrows;
    [SerializeField] private AudioSource _as;
    [SerializeField] private Button _backToMenu;

    void Start()
    {
        _backToMenu.onClick.AddListener(BackMenu);
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0]){
            _scoreThrows.text = "Score: " + GameManager.gm.scoreThrows.ToString();
            GameManager.gm.SetBestScore();
            GameManager.gm.SortingBestScore();
            _bestScoreThrows.text = "Best Score: " + GameManager.gm.bestScoreThrows[0].ToString();
        }else if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1]){
            _scoreThrows.text = "Счёт: " + GameManager.gm.scoreThrows.ToString();
            GameManager.gm.SetBestScore();
            GameManager.gm.SortingBestScore();
            _bestScoreThrows.text = "Лучший результат: " + GameManager.gm.bestScoreThrows[0].ToString();
        }
    }

    private void BackMenu(){
        SceneManager.LoadScene(0);
    }
}
