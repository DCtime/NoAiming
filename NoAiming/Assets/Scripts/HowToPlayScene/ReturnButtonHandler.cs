﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButtonHandler : MonoBehaviour
{
    public void ButtonDown()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
