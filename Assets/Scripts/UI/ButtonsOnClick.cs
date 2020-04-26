//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOnClick : MonoBehaviour
{
	public GameObject actionButton;

	public void Reset()
	{
		SceneManager.LoadScene("Main_menu");
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
		else if (gameObjectOfActivity.tag == "Neutral")
		{
			gameObjectOfActivity.tag = "Teammate";
			GameObject.FindGameObjectWithTag("CharactersList").GetComponent<ShowingCharactersList>().NewTeammate(gameObjectOfActivity);
		}
		actionButton.SetActive(false);			//Добавить плавность отключению
	}
}
