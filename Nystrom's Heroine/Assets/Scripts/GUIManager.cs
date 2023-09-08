using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject spaceGameObject;
    [SerializeField] GameObject shiftGameObject;
    [SerializeField] GameObject wGameObject;
    [SerializeField] GameObject eGameObject;
    [SerializeField] GameObject sGameObject;

    public void ShowObject (KeyCode input, bool show)
    {
        if (input == KeyCode.Space)
        {
            spaceGameObject.SetActive(show);
        }
        else if (input == KeyCode.LeftShift)
        {
            shiftGameObject.SetActive(show);
        }
        else if (input == KeyCode.W)
        {
            wGameObject.SetActive(show);
        }
        else if (input == KeyCode.E)
        {
            eGameObject.SetActive(show);
        }
        else if (input == KeyCode.S)
        {
            sGameObject.SetActive(show);
        }
    }
}