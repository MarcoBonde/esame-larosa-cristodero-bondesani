﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Playgame()
    {
        SceneManager.LoadScene("INSTRUCTION");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
