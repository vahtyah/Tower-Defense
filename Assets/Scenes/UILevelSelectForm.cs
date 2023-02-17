using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelectForm : MonoBehaviour
{
    [SerializeField] MouseScroll mouseScroll;
    [SerializeField] GameObject UIMenu;
    private void OnEnable()
    {
        mouseScroll.Init();
    }

    public void OnBackButtonClick()
    {
        gameObject.SetActive(false);
        UIMenu.SetActive(true);
    }

    public void OnLevel1Click()
    {
        SceneManager.LoadScene(1);
    }
}
