using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    Turret turret;
    TurretBlueprint turretOnNode;
    int numberOfUpdate = 0;

    public Turret Turret { get { return turret;} }
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turretOnNode != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint turretBlueprint)
    {
        turret = Turret.Create(turretBlueprint.turretBlueprint[0].turretPrefab, transform).GetComponent<Turret>();
        turretOnNode = turretBlueprint;
    }

    public void UpgradeTurret()
    {
        if(numberOfUpdate + 1 >= turretOnNode.turretBlueprint.Length)
        {
            print("Update cc");
            return;
        }
        //money
        Destroy(turret.gameObject);
        turret = Turret.Create(turretOnNode.turretBlueprint[++numberOfUpdate].turretPrefab, transform).GetComponent<Turret>();
    }
}
