//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
	public RectTransform joystick;
	public RectTransform secondZone;
	public Slider sliderJSize;
	public Slider sliderJZoneSize;

	private void Start()
	{
		sliderJSize.value = PlayerPrefs.GetFloat("Joystick size");
		sliderJZoneSize.value = PlayerPrefs.GetFloat("Joystick second zone size");
	}

	public void LoadTestScene()
	{
		SceneManager.LoadScene("Play_test");
	}

	public void JoysticksSize(float sliderValue)
	{
		joystick.localScale = new Vector2(sliderValue, sliderValue);
		PlayerPrefs.SetFloat("Joystick size", sliderValue);
	}

	public void SecondZoneSize(float sliderValue)
	{
		secondZone.localScale = new Vector2(sliderValue, sliderValue);
		PlayerPrefs.SetFloat("Joystick second zone size", sliderValue);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
