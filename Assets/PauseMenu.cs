using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
