﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseTrigger : MonoBehaviour
{

    public GameObject PauseMenu;
    bool IsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TriggerPause();
        }
    }

    void TriggerPause()
    {
        IsPaused = !IsPaused;
        if (IsPaused){
            Time.timeScale = 0;
            //PauseMenu.SetActive = true;
        }
        else{
            Time.timeScale = 1;
            //PauseMenu.SetActive = false;
        }
    }
}

