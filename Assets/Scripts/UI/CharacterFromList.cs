//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterFromList : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	public GameObject[] characters = new GameObject[5];
	private	int curCharacter;

	void Start()
	{
		curCharacter = 0;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		GameObject pressedGameObject = eventData.pointerCurrentRaycast.gameObject;
		GameObject laser;
		Vector2 pos;

		if (pressedGameObject)
			if (pressedGameObject.name == "CharactersList")
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(gameObject.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
					if (pressedGameObject.transform.GetChild((int)(pos.y / (-55))).gameObject.activeSelf)
						if (curCharacter != (int)(pos.y / (-55)) & characters[(int)(pos.y / (-55))].GetComponent<PlayerHealth>().GetHealth() > 0)
						{
							characters[curCharacter].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;     //Исправить после добавления ИИ
							characters[curCharacter].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);             //Same ^
							characters[curCharacter].GetComponent<MoveController>().enabled = false;
							characters[curCharacter].GetComponent<ShootController>().enabled = false;
							characters[curCharacter].transform.GetChild(1).gameObject.SetActive(false);
							laser = characters[curCharacter].transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
							curCharacter = (int)(pos.y / (-55));
							laser.transform.SetParent(characters[curCharacter].transform.GetChild(0).GetChild(0));
							laser.transform.position = laser.transform.parent.position;
							laser.transform.rotation = laser.transform.parent.rotation;
							characters[curCharacter].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;        //Исправить после добавления ИИ
							characters[curCharacter].GetComponent<MoveController>().enabled = true;
							characters[curCharacter].GetComponent<ShootController>().enabled = true;
							characters[curCharacter].transform.GetChild(1).gameObject.SetActive(true);
						}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
