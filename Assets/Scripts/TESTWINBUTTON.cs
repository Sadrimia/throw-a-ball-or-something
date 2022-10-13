using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTWINBUTTON : MonoBehaviour
{
    public void TESTWIN(){
        Spawner.spawner.SpawnBasket();
        Spawner.spawner.SpawnBall();
        GameManager.gm.AddScoreThrows();
            if(GameManager.gm.scoreThrows % 15 == 0 && GameManager.gm.scoreThrows > 14){
                GameManager.gm.AddExtraCoins();
            }
    }
    public void TESTCOINS(){
        GameManager.gm.AddScoreCoins();
    }
}
