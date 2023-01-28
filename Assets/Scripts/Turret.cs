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

    [Header("Use bulletGO")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
        UpdateRotation();
        //ClearTarget();

        if (fireCountdown <= 0f && target)
        {
            Shoot(bulletPrefab);
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot(GameObject bulletPrefab)
    {
        var bulletGO = ObjectPooler.instance.ActivateObject(bulletPrefab.tag);
        if(bulletGO != null)
        {
            bulletGO.SetActive(true);
            bulletGO.transform.position = firePoint.position;
            bulletGO.transform.rotation = firePoint.rotation;
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if(bullet!=null) { bullet.setTarget(target.transform); }
        }
    }

    void UpdateTarget()
    {
        float closestDistance = Mathf.Infinity;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyLayer);
        if(hitColliders.Contains(target)) { return; }
        if(hitColliders.Length <= 0)
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
        if (distance < range) {
            target = null;
            print("Tuan");
        }
    }

    void UpdateRotation()
    {
        if (target == null) return;
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2 * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
