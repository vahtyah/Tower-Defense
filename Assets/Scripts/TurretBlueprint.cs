using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
    [SerializeField] GameObject turretPrefab;
    [SerializeField] int cost;

    public GameObject TurretPrefab { get { return turretPrefab; } }
    public int Cost { get { return cost; } }
}
