using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private AudioSource _as;
    private void OnTriggerEnter2D(Collider2D other) {
        _as.Play();
        _losePanel.SetActive(true);
        if(!Vibrator.vibrationIsOff){
            Vibrator.Vibrate(300);
        }
    }
}
