using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeOverlay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costForUpgrade;
    [SerializeField] TextMeshProUGUI costForSell;
    Turret turret;
    Node node;

    public void Show(Node node)
    {
        this.turret = node.Turret;
        this.node = node;   
        gameObject.SetActive(true);
        transform.position = turret.transform.position;
        RefreshRangeVisual();
        RefreshCostVisual();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void RefreshRangeVisual()
    {
        transform.Find("Range").localScale = turret.Range * Vector3.one * 2f;
    }

    private void RefreshCostVisual()
    {
        costForSell.text = "+ $ " + turret.GetCostRefuns().ToString();
        if(turret.GetTurretPrefabUpgrade() == null)
        {
            costForUpgrade.text = "NONE";
            return;
        }
        costForUpgrade.text = "$ " + turret.GetTurretPrefabUpgrade().GetCostForBuild().ToString();
    }

    public void Upgrade()
    {
        node.UpgradeTurret();
        Show(node);
    }

    public void Sell()
    {
        node.SellTurret();
    }
}
