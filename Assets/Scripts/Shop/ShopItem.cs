using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ShopItem : MonoBehaviour
{
    public static UnityEvent OnChangeSkin = new UnityEvent();

    [SerializeField] private SkinData _skin;
    [Header("Shop Item components")]
    [SerializeField] private Image _skinImage;
    [SerializeField] private TMP_Text _skinCost;
    [SerializeField] private Button _buyButton;
    [SerializeField] private GameManager.SkinType _type;
    [SerializeField] private AudioSource _as;

    private void Awake() {
        _skinImage.sprite = _skin.skinImage;
        _skinCost.text = _skin.cost.ToString();
        _buyButton.onClick.AddListener(Buy);

        if(_skin.cost == 0){
            _skin.isUnlocked = true;
            _buyButton.GetComponentInChildren<TMP_Text>().text = "Choose";
            PlayerPrefs.SetInt(_skin.skinName, _skin.isUnlocked?1:0);
        }

        if(PlayerPrefs.GetInt(_skin.skinName, 0) == 1){
            _skin.isUnlocked = true;
            _buyButton.GetComponentInChildren<TMP_Text>().text = "Choose";
            _buyButton.image.color = Color.yellow;
        }else{
            _skin.isUnlocked = false;
            _buyButton.GetComponentInChildren<TMP_Text>().text = _skin.cost.ToString();
        }
    }

    private void Update() {
        if(_skin.cost > GameManager.gm.scoreCoins && !_skin.isUnlocked){
            _buyButton.interactable = false;
            _buyButton.GetComponent<Image>().color = new Color(255f,255f,255f, 0.6f);
            _buyButton.transform.GetChild(0).GetComponent<Image>().color = new Color(255f,255f,255f, 0.6f);
        }
    }

    private void Buy(){
        if(_skin.isUnlocked && GameManager.gm._currentSkin != _type){
            GameManager.gm._currentSkin = _type;
            OnChangeSkin.Invoke();
		    PlayerPrefs.SetInt("CurrentSkin", (int)GameManager.gm._currentSkin);
        }
        if(!_skin.isUnlocked)
        {
            _buyButton.GetComponentInChildren<TMP_Text>().text = "Choose";
            _skin.isUnlocked = true;
            _as.Play();
            PlayerPrefs.SetInt(_skin.skinName, _skin.isUnlocked?1:0);
            GameManager.gm.DeleteCoins(_skin.cost);
        }
    }
}
