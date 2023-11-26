using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Build Manager Singleton Settings")]
    public static BuildManager instance; //single instance of build manager

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("There ain't room for two build managers around here.... Fix your shit spagatti boy");
            return;
        }

        instance = this; //setting instance
    }

    [Header("Tower Building Settings")]
    private GameObject towerToBuild;

    [Header("Tower Prefabs")]
    public GameObject machineGunTurretPrefab;

    void Start()
    {
        towerToBuild = machineGunTurretPrefab;
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
