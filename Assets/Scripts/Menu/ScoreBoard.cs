using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _firstBestScore;
    [SerializeField] private TextMeshProUGUI _secondBestScore;
    [SerializeField] private TextMeshProUGUI _thirdBestScore;

    private void Awake() {
        _firstBestScore.text = "1. " + PlayerPrefs.GetInt("FirstBestScore", 0).ToString();
        _secondBestScore.text = "2. " + PlayerPrefs.GetInt("SecondBestScore", 0).ToString();
        _thirdBestScore.text = "3. " + PlayerPrefs.GetInt("ThirdBestScore", 0).ToString();
    }
}
