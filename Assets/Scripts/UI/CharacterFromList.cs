//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterFromList : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	public GameObject[] characters = new GameObject[5];
	private	int curCharacter;
	public GameObject inventoryDisplay;
	public GameObject inventoryButton;
	void Start()
	{
		curCharacter = 0;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		GameObject pressedGameObject = eventData.pointerCurrentRaycast.gameObject;
		Vector2 pos;

		if (pressedGameObject)
			if (pressedGameObject.name == "CharactersList")
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(gameObject.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
					if (pressedGameObject.transform.GetChild((int)(pos.y / (-55))).gameObject.activeSelf)
						if (curCharacter != (int)(pos.y / (-55)) & characters[(int)(pos.y / (-55))].GetComponent<PlayerHealth>().GetHealth() > 0)
						{
							characters[curCharacter].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;		//Исправить после добавления ИИ
							characters[curCharacter].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);				//Same ^
							characters[curCharacter].GetComponent<MoveController>().enabled = false;
							characters[curCharacter].GetComponent<ShootController>().enabled = false;
							characters[curCharacter].transform.GetChild(1).gameObject.SetActive(false);
							curCharacter = (int)(pos.y / (-55));
							characters[curCharacter].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;		//Исправить после добавления ИИ
							characters[curCharacter].GetComponent<MoveController>().enabled = true;
							characters[curCharacter].GetComponent<ShootController>().enabled = true;
							characters[curCharacter].transform.GetChild(1).gameObject.SetActive(true);

							inventoryDisplay.GetComponent<DisplayInventory>().inventory = characters[curCharacter].GetComponent<PlayerInventory>().inventory;
							inventoryButton.GetComponent<GetLootedInventory>().currentCharacter = characters[curCharacter];
						}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
