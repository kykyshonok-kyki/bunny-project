//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.UI;

public class ShowingCharactersList : MonoBehaviour
{
	public GameObject characterPrefab;
	private short charactersCount;

	void Start()
	{
		string playerName;

		playerName = GameObject.FindGameObjectWithTag("Player").transform.parent.name;
		transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = playerName;
		charactersCount = 1;
	}

	public void NewTeammate(GameObject teammate)
	{
		string characterName = teammate.transform.parent.name;
		Transform newCharacter;

		newCharacter = transform.GetChild(charactersCount);
		newCharacter.transform.GetChild(0).GetComponent<Text>().text = characterName;
		newCharacter.gameObject.SetActive(true);
		charactersCount++;
	}
}
