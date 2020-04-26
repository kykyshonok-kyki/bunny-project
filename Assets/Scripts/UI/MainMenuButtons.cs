//Made by kyki (neskajju@mail.ru) in April 2020

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void LoadTestScene()
    {
        SceneManager.LoadScene("Play_test");
    }

    public void OpenSettings()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
