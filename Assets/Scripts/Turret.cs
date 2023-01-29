using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float range = 1.5f;
    [SerializeField] Collider target;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float speedRotation = 10f;

    [Header("Use bulletGO")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    public float fireRate = 1f;
    public float fireCountdown = 0f;


    bool targetLock = false;

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
        float angle = Vector3.Angle(transform.forward, direction);
        if (angle <= 5) targetLock = true;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speedRotation * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
