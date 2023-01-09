using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instanceBuildManager;
    public static BuildManager instance
    {
        get
        {
            if (instanceBuildManager == null)
            {
                instanceBuildManager = FindObjectOfType<BuildManager>();
            }
            return instanceBuildManager;
        }
    }
    //[SerializeField] GameObject buildEffect;
    //[SerializeField] GameObject sellEffect;

    [SerializeField] GameObject standardTurretPrefab;
    GameObject turretToBuild;
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuldt()
    {
        return turretToBuild;
    }
}
