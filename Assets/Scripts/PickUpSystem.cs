using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    BuildManager buildManager;
    Turret turret;
    [SerializeField] Material tuan;

    private void Start()
    {
        buildManager = GetComponent<BuildManager>();
        turret = buildManager.GetTurretToBuild();
    }
}
