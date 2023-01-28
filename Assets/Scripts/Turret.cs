using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    [SerializeField] float range = 1.5f;
    [SerializeField] Collider target;
    [SerializeField] LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
        UpdateRotation();
        //ClearTarget();
    }

    void UpdateTarget()
    {
        float closestDistance = Mathf.Infinity;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyLayer);
        if(hitColliders.Contains(target)) { return; }
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
