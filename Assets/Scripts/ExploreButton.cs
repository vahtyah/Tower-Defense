using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreButton : MonoBehaviour
{
    SpawnerLand spawnerLand;

    Vector3 camPosition;
    void Start()
    {
        spawnerLand = FindObjectOfType<SpawnerLand>();
    }

    private void OnMouseDown()
    {
        spawnerLand.CreateLandLeft();
        gameObject.SetActive(false);
    }
}
