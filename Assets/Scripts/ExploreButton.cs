using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreButton : MonoBehaviour
{
    SpawnerLand spawnerLand;
    void Start()
    {
        spawnerLand = FindObjectOfType<SpawnerLand>();
    }

    private void OnMouseDown()
    {
        spawnerLand.CreateLandLeft(transform.position, transform.parent.position);
        gameObject.SetActive(false);
    }
}
