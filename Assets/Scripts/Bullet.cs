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

    [SerializeField] float speed = 70f;
    Transform target;

    private void Setup(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target == null)
        {
            ObjectPooler.instance.DeactivateObject(gameObject);
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
        //float angle = GetAngleFromVectorFloat(dir);
        //transform.eulerAngles = new Vector3(0, angle,0);
        transform.LookAt(target.position);
    }

    private void HitTarget()
    {
        ObjectPooler.instance.DeactivateObject(gameObject);
    }
}
