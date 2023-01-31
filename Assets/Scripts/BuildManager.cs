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


    [SerializeField] UpgradeOverlay upgradeOverlay;
    TurretBlueprint turretToBuild;
    Node selectedNode;
    
    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        upgradeOverlay.Show(node.turret);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        upgradeOverlay.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        var turret = Turret.Create(turretToBuild.TurretPrefab, node.transform).GetComponent<Turret>();
        node.turret = turret;
    }

    public bool CanBuild { get {return turretToBuild != null; } }
}
