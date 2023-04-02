using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptions : MonoBehaviour
{
    [SerializeField] GameObject UIMenu;

    public void OnBackButtonClick()
    {
        UIMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
