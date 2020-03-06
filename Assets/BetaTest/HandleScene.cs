using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleScene : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<HouseGauge>().onEmpty.AddListener(LoadBabyWinEnd);
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
