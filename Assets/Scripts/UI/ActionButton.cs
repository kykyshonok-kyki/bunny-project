//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
	private GameObject curGO;	//curGO - объект над которым производится действие

	void Start()
	{
		gameObject.SetActive(false);
	}

	public void Active(GameObject gameObj)
	{
		curGO = gameObj;
		if (gameObj.tag == "Door")
		{
			if (gameObj.GetComponent<DoorController>().doorState == 0)
				transform.GetChild(0).GetComponent<Text>().text = "Open door";
			else
				transform.GetChild(0).GetComponent<Text>().text = "Close door";
			gameObject.SetActive(true);
		}
	}

	public void Disable()
	{
		gameObject.SetActive(false);
	}

	public GameObject GetGameObject()
	{
		return curGO;
	}
}
