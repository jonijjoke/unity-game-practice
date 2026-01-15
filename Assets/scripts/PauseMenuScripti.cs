using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    GameObject pauseMenuUI;
    private bool pausedGame = false;
    void Start()
    {
        pauseMenuUI = GameObject.Find("PauseMenu");
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (pausedGame)
            {
                ContinueGame();
            }
            else
            {
                Pause();
            }
        }
    }

    void ContinueGame() // Jatka peliä jos pausella
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pausedGame = false;
    }

    void Pause() // Pelin pause
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pausedGame = true;
    }
}
