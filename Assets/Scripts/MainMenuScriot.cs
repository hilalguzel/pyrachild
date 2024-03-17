using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScriot : MonoBehaviour
{
    public string sceneName;
    public GameObject creditsMenu;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit bro");
    }
    public void GoToCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void BackFromCredits()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
