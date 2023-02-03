using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static void Create(GameObject bulletPrefab, Transform firePoint, Transform target)
    {
        var bulletGO = ObjectPooler.instance.ActivateObject(bulletPrefab.tag);
        bulletGO.SetActive(true);
        bulletGO.transform.position = firePoint.position;
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.Setup(target);
    }

    public static void Destroy(GameObject bulletPrefab)
    {
        ObjectPooler.instance.DeactivateObject(bulletPrefab);
    }

    [SerializeField] float speed = 70f;
    Transform target;
    Enemy enemy;

    private void Setup(Transform target)
    {
        this.target = target;
        enemy = target.GetComponent<Enemy>();
    }

    private void Update()
    {
        if (target == null)
        {
            Bullet.Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target.position);
    }

    private void HitTarget()
    {
        Bullet.Destroy(gameObject);
        enemy.Damage(10);
    }
}
