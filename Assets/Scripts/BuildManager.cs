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
    Turret turretToBuild;
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
        upgradeOverlay.Show(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        upgradeOverlay.Hide();
    }

    public void SelectTurretToBuild(Turret turret)
    {
        turretToBuild = turret;
    }

    public Turret GetTurretToBuild()
    {
        return turretToBuild;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney(int money)
    {
        return Player.Money >= money;
    }
}
