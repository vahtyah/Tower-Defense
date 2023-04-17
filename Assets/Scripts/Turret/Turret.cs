using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    public static GameObject Create(GameObject turretPrefab, Transform transform)
    {
        var turret = ObjectPooler.instance.ActivateObject(turretPrefab.tag);
        turret.SetActive(true);
        turret.transform.position = transform.position + new Vector3(0f,.2f,0f);
        return turret;
    }

    public static void Destroy(GameObject turretPrefab)
    {
        ObjectPooler.instance.DeactivateObject(turretPrefab);
    }

    [Header("General")]
    [SerializeField] float range = 1.5f;
    [SerializeField] int costForBuild;
    [SerializeField] Transform partToRotate;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float speedRotation = 10f;
    [SerializeField] GameObject shootEffect;
    [HideInInspector]
    public Collider target;
    

    [Header("Use bulletGO")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float fireCountdown = 0f;

    [Header("Upgrade")]
    [SerializeField] Turret turretPrefabUpgrade;
    [SerializeField] int costRefuns;

    bool targetLock = false;

    public float Range { get { return range; } }

    private void Awake()
    {
        costRefuns = costForBuild * 50 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
        if (target == null) return;
        UpdateRotation();
        Shoot();
    }

    void Shoot()
    {
        if (fireCountdown <= 0f && targetLock)
        {
            if (shootEffect != null)
                Effect.Create(shootEffect, firePoint.position, target.transform, this);
            Bullet.Create(bulletPrefab, firePoint, target.transform);
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        float closestDistance = Mathf.Infinity;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyLayer);
        if (hitColliders.Contains(target)) { return; }
        targetLock = false;
        if (hitColliders.Length <= 0)
        {
            target = null;
            return;
            //nào bắt đầu wave thì cập nhật;
            //tạo list enemies ở trong EnemyWayManager or ObjectPooling
            //Tamj thoi thi nhu nay
        }
        for (int i = 0; i < hitColliders.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, hitColliders[i].transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = hitColliders[i];
            }
        }
    }

    void ClearTarget()
    {
        if (target == null) return;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < range)
        {
            target = null;
            print("Tuan");
        }
    }

    void UpdateRotation()
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Vector3.Angle(partToRotate.forward, direction);
        if (angle <= 10) targetLock = true;
        Quaternion rotation = Quaternion.LookRotation(direction);
        partToRotate.rotation = Quaternion.Slerp(partToRotate.rotation, rotation, speedRotation * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public Transform GetPartToRotate()
    {
        return partToRotate;
    }

    public Turret GetTurretPrefabUpgrade()
    {
        return turretPrefabUpgrade;
    }

    public int GetCostForBuild()
    {
        return costForBuild;
    }

    public int GetCostRefuns()
    {
        return costRefuns;
    }
}
