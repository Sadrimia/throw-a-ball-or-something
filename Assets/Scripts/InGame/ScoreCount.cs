using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _throwsText;

     void Start()
    {
        UpdateText();
        GameManager.OnChangeScoreValue.AddListener(UpdateText);
    }

    void UpdateText()
    {
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0]){
            _coinsText.text ="Score coin: " + GameManager.gm.scoreCoins.ToString();
            _throwsText.text ="Score throws: " + GameManager.gm.scoreThrows.ToString();
        }else if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1]){
            _coinsText.text ="Колл-монет: " + GameManager.gm.scoreCoins.ToString();
            _throwsText.text ="Счёт бросков: " + GameManager.gm.scoreThrows.ToString();
        }

    }
}
