using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    [Header("Option")]
    public GameObject turret;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) return;
        if (turret != null)
        {
            print("Can't build");
            return;
        }
        buildManager.BuildTurretOn(this);
    }
}
