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

    public GameObject BallistaTurretPrefab;

    [SerializeField] GameObject turretToBuild;
    
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public GameObject GetTurretToBuldt()
    {
        return turretToBuild;
    }
}
