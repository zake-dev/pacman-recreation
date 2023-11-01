using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneBorderAnimationController : MonoBehaviour
{
    [SerializeField]
    private GameObject borderA;
    [SerializeField]
    private GameObject borderB;
    [SerializeField]
    private float borderFlashingInterval = 1.0f;

    void Awake()
    {
        borderB.SetActive(false);   
    }

    void Start()
    {
        InvokeRepeating("ToggleBorder", 0f, borderFlashingInterval);
    }

    private void ToggleBorder()
    {
        if (borderA.activeSelf)
        {
            borderA.SetActive(false);
            borderB.SetActive(true);
        }
        else
        {
            borderA.SetActive(true);
            borderB.SetActive(false);
        }
    }
}
