using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
  public GameObject levelSelectMenu;
  public AudioClip buttonClickSound;
  private AudioSource audioSource;

    private void Start()
    {
        levelSelectMenu.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void quit()
    {
        Application.Quit();
    }

}
