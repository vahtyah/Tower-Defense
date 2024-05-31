using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    [SerializeField] Turret[] ballistaTurret;

    BuildManager buildManager;
    private void Start() { buildManager = BuildManager.instance; }

    public void SelectBallista(string turretName)
    {
        foreach (var turret in ballistaTurret)
        {
            if (String.Compare(turret.gameObject.tag, turretName, StringComparison.Ordinal) == 0) continue;
            buildManager.SelectTurretToBuild(turret);
            break;
        }
    }
}