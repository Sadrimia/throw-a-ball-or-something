using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private float _ballPosition;
    [SerializeField] private AudioSource _as;

    private void OnTriggerEnter2D(Collider2D other) {
        _ballPosition = other.transform.position.y;
        _as.Play();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.position.y < _ballPosition){
            if(!Vibrator.vibrationIsOff){
                Vibrator.Vibrate(100);
            }
            Spawner.spawner.SpawnBasket();
            Spawner.spawner.SpawnBall();
            GameManager.gm.AddScoreThrows();
            if(GameManager.gm.scoreThrows % 15 == 0 && GameManager.gm.scoreThrows > 14){
                GameManager.gm.AddExtraCoins();
            }
        }
    }
}
