using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
    public TurretInfor[] turretBlueprint;
    [System.Serializable]
    public class TurretInfor
    {
        public GameObject turretPrefab;
        public int cost;
    }

}
