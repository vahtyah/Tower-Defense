using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    //BuildManager buildManager;
    //Turret turret;
    [SerializeField] Material tuan;
    Material[] originalMaterial;
    MeshRenderer meshRenderer;

    private void Start()
    {
        //buildManager = GetComponent<BuildManager>();
        //turret = buildManager.GetTurretToBuild();
        originalMaterial = gameObject.GetComponent<MeshRenderer>().materials;
       
            for (int i = 0; i < originalMaterial.Length; i++)
            {
                print(originalMaterial[i].color);
            }
        
        ChangeMaterials();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            print(originalMaterial[0].color);
        }
    }

    void ChangeMaterials()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        for (int i = 0; i < renderer.materials.Length; i++)
        {
            renderer.materials[i].color = tuan.color;
        }
    }

    void RestoreMaterials()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.materials = originalMaterial;
    }
}
