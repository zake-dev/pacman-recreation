using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
