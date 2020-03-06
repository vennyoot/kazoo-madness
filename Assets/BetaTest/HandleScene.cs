using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleScene : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "KazooMadness")
        {
            FindObjectOfType<HouseGauge>().onEmpty.AddListener(LoadBabyWinEnd);
            FindObjectOfType<HouseGauge>().onFull.AddListener(LoadSitterWinEnd);
        }

        if (SceneManager.GetActiveScene().name == "START_THIS")
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (InputHandle.GetSitterInteractKey())
            {
                SceneManager.LoadScene("KazooMadness");
            }
        }

        if (SceneManager.GetActiveScene().name == "BabyWin" || SceneManager.GetActiveScene().name == "SitterWin")
        {
            if (InputHandle.GetSitterInteractKey())
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void LoadBabyWinEnd()
    {
        SceneManager.LoadScene("BabyWin");
    }

    public void LoadSitterWinEnd()
    {
        SceneManager.LoadScene("SitterWin");
    }
}
