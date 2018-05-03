using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour {

  public void PlayGame()
  {
    Debug.Log("Opening game");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void QuitGame()
  {
    Debug.Log("Quiting game");
    Application.Quit();
  }
}
