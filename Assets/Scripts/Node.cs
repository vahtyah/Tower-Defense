using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    GameObject turret;
    private void OnMouseDown()
    {
        if (turret != null)
        {
            print("Can't build");
            return;
        }
        GameObject turretToBulld = BuildManager.instance.GetTurretToBuldt();
        turret = Instantiate(turretToBulld, new Vector3(transform.position.x, .2f, transform.position.z), transform.rotation);
    }
}
