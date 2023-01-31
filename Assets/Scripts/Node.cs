using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    [Header("Option")]
    public Turret turret;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            buildManager.SelectNode(this);
            print("Open Upgrade!");
            return;
        }
        if (!buildManager.CanBuild)
        {
            print("can't not build this place!");
            return;
        }
        buildManager.BuildTurretOn(this);
    }
}
