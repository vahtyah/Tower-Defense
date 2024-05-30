using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;
    Player player;
    Turret turret;

    public Turret Turret { get { return turret;} }
    private void Start()
    {
        player = Player.instance;
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            print("You have not select turret!");
            return;
        }
        int moneyToBuild = buildManager.GetTurretToBuild().GetCostForBuild();
        if(!buildManager.HasMoney(moneyToBuild))
        {
            print("Do not have enough money left!");
            return;
        }
        player.ChangeMoney(-moneyToBuild);
        BuildTurret(buildManager.GetTurretToBuild().gameObject);
    }

    void BuildTurret(GameObject turretBlueprint)
    {
        turret = Turret.Create(turretBlueprint, transform).GetComponent<Turret>();
    }

    public void UpgradeTurret()
    {
        if (turret.GetTurretPrefabUpgrade() == null)
        {
            print("Upgraded to the highest version");
            return;
        }
        int moneyToUpgrade = turret.GetTurretPrefabUpgrade().GetCostForBuild();
        if (!buildManager.HasMoney(moneyToUpgrade))
        {
            print("Do not have enough money left!");
            return;
        }
        player.ChangeMoney(-moneyToUpgrade);
        Quaternion quaternion = turret.GetPartToRotate().rotation;
        Collider target = turret.target;
        Turret.Destroy(turret.gameObject);
        turret = Turret.Create(turret.GetTurretPrefabUpgrade().gameObject, transform).GetComponent<Turret>();
        turret.target = target;
        turret.gameObject.transform.rotation = quaternion;
    }

    public void SellTurret()
    {
        int moneyFromSellTurret = turret.GetCostRefuns();
        player.ChangeMoney(moneyFromSellTurret);
        buildManager.DeselectNode();
        Turret.Destroy(turret.gameObject);
        turret = null;
    }
}
