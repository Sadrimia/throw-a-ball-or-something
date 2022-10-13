using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _ballPosition;
    private void OnTriggerEnter2D(Collider2D other) {
        _ballPosition = other.transform.position.y;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.position.y < _ballPosition){
        GameManager.gm.AddScoreCoins();
        Destroy(this.gameObject);
        }
    }
}
