using UnityEngine;
using UnityEngine.UI;

public class BallSelectionPages : MonoBehaviour
{
    [SerializeField] private GameObject[] _pages;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    private int i = 0;

    private void Awake() {
        _leftButton.onClick.AddListener(SwipeLeft);
        _rightButton.onClick.AddListener(SwipeRight);
    }

    private void SwipeLeft(){
        _pages[i].SetActive(false);
        i -= 1;
        if(i < 0){
            i = 2;
        }
        _pages[i].SetActive(true);
    }

    private void SwipeRight(){
        _pages[i].SetActive(false);
        i += 1;
        if(i > 2){
            i = 0;
        }
        _pages[i].SetActive(true);
    }
}
