//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.UI;

public class ShowingCharactersList : MonoBehaviour
{
	private short charactersCount;

	void Start()
	{
		string playerName;

		playerName = GameObject.FindGameObjectWithTag("Player").transform.parent.name;
		transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = playerName;
		transform.GetComponent<CharacterFromList>().characters[0] = GameObject.FindGameObjectWithTag("Player");
		charactersCount = 1;
	}

	public void NewTeammate(GameObject teammate)
	{
		string characterName = teammate.transform.parent.name;
		Transform newCharacter;

		if (charactersCount < 5)
		{
			newCharacter = transform.GetChild(charactersCount);
			newCharacter.transform.GetChild(0).GetComponent<Text>().text = characterName;
			transform.GetComponent<CharacterFromList>().characters[charactersCount] = teammate;
			newCharacter.GetComponent<Image>().color = teammate.GetComponent<SpriteRenderer>().color;
			newCharacter.gameObject.SetActive(true);
			charactersCount++;
		}
	}
}
