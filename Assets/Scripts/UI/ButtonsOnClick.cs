//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOnClick : MonoBehaviour
{
	public GameObject actionButton;

	public void Reset()
	{
		SceneManager.LoadScene(0);
	}

	public void Action()
	{
		GameObject gameObjectOfActivity;
		DoorController doorActions;

		gameObjectOfActivity = actionButton.GetComponent<ActionButton>().GetGameObject();
		if (gameObjectOfActivity.tag == "Door")
		{
			doorActions = gameObjectOfActivity.GetComponent<DoorController>();
			if (doorActions.doorState == 0)
				doorActions.OpenDoor(GameObject.FindGameObjectWithTag("Player").transform.position);
			else
				doorActions.CloseDoor();
		}
	}
}
