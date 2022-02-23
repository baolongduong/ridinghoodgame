using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("BeginAnimation");
    }
    public void GoToInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void Exit()
    {
        Application.Quit();
    }
}

