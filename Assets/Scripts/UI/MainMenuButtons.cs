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
	public Dropdown viewController;
	public GameObject joystickSettings;
	public GameObject swipeViewSettings;
	public Text viewSettingsToggleText;

	private void Start()
	{
		sliderJSize.value = PlayerPrefs.GetFloat("Joystick size", 1f);
		sliderJZoneSize.value = PlayerPrefs.GetFloat("Joystick second zone size", 0.7f);
		viewController.value = PlayerPrefs.GetInt("View control type", 0);
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

	public void ViewControlChoose(int value)
	{
		PlayerPrefs.SetInt("View control type", value);
		viewSettingsToggleText.transform.parent.GetComponent<Toggle>().isOn = false;
	}

	public void ShowControlTypeSettings(bool isOn)
	{
		if (isOn)
		{
			if (PlayerPrefs.GetInt("View control type", 0) == 0)
			{
				joystickSettings.SetActive(true);
				joystick.gameObject.SetActive(true);
			}
			else
				swipeViewSettings.SetActive(true);
			viewSettingsToggleText.text = "Скрыть";
		}
		else
		{
			viewSettingsToggleText.text = "Настроить";
			joystickSettings.SetActive(false);
			swipeViewSettings.SetActive(false);
			joystick.gameObject.SetActive(false);
		}
	}

	public void Exit()
	{
		Application.Quit();
	}
}
