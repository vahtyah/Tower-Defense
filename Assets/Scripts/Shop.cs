using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseBallista()
    {
        print("purchase ballista");
        buildManager.SetTurretToBuild(buildManager.BallistTurretPrefab);
    }
}
