using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeOverlay : MonoBehaviour
{
    private Turret turret;

    public void Show(Turret turret)
    {
        this.turret = turret;
        gameObject.SetActive(turret);
        transform.position = turret.transform.position;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void updatecc()
    {
        print("update");
    }
}
