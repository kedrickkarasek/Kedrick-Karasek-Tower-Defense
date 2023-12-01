using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject controlsCanvas;
    public GameObject creditsCanvas;
    public GameObject mainMenuCanvas;



    public void loadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ControlsCanvas()
    {
        if (!controlsCanvas.gameObject.activeSelf)
        {
            controlsCanvas.SetActive(true);
            mainMenuCanvas.SetActive(false);
        }
        else
        {
            controlsCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
    }

    public void CreditsCanvas()
    {
        if (!creditsCanvas.gameObject.activeSelf)
        {
            creditsCanvas.SetActive(true);
            mainMenuCanvas.SetActive(false);
        }
        else
        {
            creditsCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
    }

    public void OpenLink()
    {
        Application.OpenURL("https://docs.google.com/document/d/1AmSv2MEYbSw8hirDPAf8Fpy4McQo2SdHzSHQ8dyGtZQ/edit?usp=sharing");
    }
}
