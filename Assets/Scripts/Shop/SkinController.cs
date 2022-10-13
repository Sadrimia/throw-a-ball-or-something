using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    [SerializeField] private Sprite[] _skins;

	private void Start()
	{
		ShopItem.OnChangeSkin.AddListener(ChangeSkin);
		ChangeSkin();
	}

	private void ChangeSkin()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		switch (GameManager.gm._currentSkin)
		{
			case GameManager.SkinType.Basketball:
				sr.sprite = _skins[0];
				break;
			case GameManager.SkinType.Billiards:
				sr.sprite = _skins[1];
				break;
			case GameManager.SkinType.Bowling:
				sr.sprite = _skins[2];
				break;
			case GameManager.SkinType.Cricet:
				sr.sprite = _skins[3];
				break;
			case GameManager.SkinType.Eye:
				sr.sprite = _skins[4];
				break;
			case GameManager.SkinType.Fish:
				sr.sprite = _skins[5];
				break;
			case GameManager.SkinType.Golf:
				sr.sprite = _skins[6];
				break;
			case GameManager.SkinType.Moon:
				sr.sprite = _skins[7];
				break;
			case GameManager.SkinType.Orange:
				sr.sprite = _skins[8];
				break;
			case GameManager.SkinType.Soccer:
				sr.sprite = _skins[9];
				break;
			case GameManager.SkinType.Tennis:
				sr.sprite = _skins[10];
				break;
			case GameManager.SkinType.Tennis2:
				sr.sprite = _skins[11];
				break;
			case GameManager.SkinType.Volleyball:
				sr.sprite = _skins[12];
				break;
			case GameManager.SkinType.Wheel1:
				sr.sprite = _skins[13];
				break;
			case GameManager.SkinType.Wheel2:
				sr.sprite = _skins[14];
				break;
			case GameManager.SkinType.Wheel3:
				sr.sprite = _skins[15];
				break;
			case GameManager.SkinType.Wheel4:
				sr.sprite = _skins[16];
				break;
		}
	}
}
