using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] GameObject UILevelSelect;

    public void OnLevelSelectButtonClick()
    {
        UILevelSelect.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnQuitButtonClick() {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
