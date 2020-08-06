using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused = false;
    [SerializeField]
    private Canvas pauseCanvas;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            if(pauseCanvas != null)
            {
                pauseCanvas.gameObject.SetActive(true);
            }
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            if (pauseCanvas != null)
            {
                pauseCanvas.gameObject.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        /*PlayerController player = FindObjectOfType<PlayerController>();
        player.gameObject.transform.position = player.startPos;
        isPaused = !isPaused;*/

        SceneManager.LoadScene("GameScene");
    }

}
