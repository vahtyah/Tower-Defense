using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeOverlay : MonoBehaviour
{
    Turret turret;
    Node node;

    public void Show(Node node)
    {
        this.turret = node.Turret;
        this.node = node;   
        gameObject.SetActive(true);
        transform.position = turret.transform.position;
        RefreshRangeVisual();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void RefreshRangeVisual()
    {
        transform.Find("Range").localScale = turret.Range * Vector3.one * 2f;
    }

    public void Upgrade()
    {
        node.UpgradeTurret();
        Show(node);
    }
}
