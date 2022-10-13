using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static UnityEvent OnChangeScoreValue = new UnityEvent();
    public int scoreThrows {get; private set;}
    public int[] bestScoreThrows {get; private set;} = new int[3];
    public int scoreCoins {get; private set;}
    public SkinType _currentSkin {get;set;}

    private void Awake() {
        if(gm == null){
            gm = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        scoreCoins = PlayerPrefs.GetInt("Coins", 0);
        bestScoreThrows[0] = PlayerPrefs.GetInt("FirstBestScore", 0);
        bestScoreThrows[1] = PlayerPrefs.GetInt("SecondBestScore", 0);
        bestScoreThrows[2] = PlayerPrefs.GetInt("ThirdBestScore", 0);
        _currentSkin = (SkinType)PlayerPrefs.GetInt("CurrentSkin");
        OnChangeScoreValue.Invoke();
    }

    public void AddScoreThrows(){
        scoreThrows += 1;
        OnChangeScoreValue.Invoke();
    }
    public void AddScoreCoins(){
        scoreCoins += 1;
        OnChangeScoreValue.Invoke();
        PlayerPrefs.SetInt("Coins", scoreCoins);
    }
    public void AddExtraCoins(){
        scoreCoins += 10;
        OnChangeScoreValue.Invoke();
        PlayerPrefs.SetInt("Coins", scoreCoins);
    }

    public void DeleteCoins(int deleteValue){
        scoreCoins -= deleteValue;
        OnChangeScoreValue.Invoke();
        PlayerPrefs.SetInt("Coins", scoreCoins);
    }

    public void SetBestScore(){
        if(scoreThrows > bestScoreThrows[0] && bestScoreThrows[0] == 0){
            bestScoreThrows[0] = scoreThrows;
        }else if(scoreThrows > bestScoreThrows[1] && bestScoreThrows[0] != 0){
            bestScoreThrows[1] = scoreThrows;
        }else if(scoreThrows > bestScoreThrows[2] && bestScoreThrows[0] != 0 && bestScoreThrows[1] != 0){
            bestScoreThrows[2] = scoreThrows;
        }
        PlayerPrefs.SetInt("FirstBestScore", bestScoreThrows[0]);
        PlayerPrefs.SetInt("SecondBestScore", bestScoreThrows[1]);
        PlayerPrefs.SetInt("ThirdBestScore", bestScoreThrows[2]);
        scoreThrows = 0;
    }

    public void SortingBestScore(){
        Array.Sort(bestScoreThrows);
        Array.Reverse(bestScoreThrows);
        PlayerPrefs.SetInt("FirstBestScore", bestScoreThrows[0]);
        PlayerPrefs.SetInt("SecondBestScore", bestScoreThrows[1]);
        PlayerPrefs.SetInt("ThirdBestScore", bestScoreThrows[2]);
    }

	public enum SkinType
	{
        Basketball,
        Billiards,
        Bowling,
        Cricet,
        Eye,
        Fish,
        Golf,
        Moon,
        Orange,
        Soccer,
        Tennis,
        Tennis2,
        Volleyball,
        Wheel1,
        Wheel2,
        Wheel3,
        Wheel4
	}
}
