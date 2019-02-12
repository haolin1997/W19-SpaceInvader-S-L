using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public void StartButton()
    {
        EnemyMovement.destroy_count = 0;
        PlayerMovement.life = 3;
        PlayerMovement.bullet_out = false;
        EnemyGrid.bullet_out = false;
        SceneManager.LoadScene("Level1");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ResumeButton()
    {
        /*
        if (PauseTrigger.IsPaused)
        {
            Time.timeScale = 1;
            PauseTrigger.PauseMenu.SetActive(false);
        }
        */
        //PauseTrigger.TriggerPause();
                    
    }

}
