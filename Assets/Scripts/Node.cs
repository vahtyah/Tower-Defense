using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    BuildManager buildManager;
    GameObject turret;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuldt() == null) return;
        if (turret != null)
        {
            print("Can't build");
            return;
        }
        GameObject turretToBulld = buildManager.GetTurretToBuldt();
        turret = Instantiate(turretToBulld, new Vector3(transform.position.x, .2f, transform.position.z), transform.rotation);
    }
}
