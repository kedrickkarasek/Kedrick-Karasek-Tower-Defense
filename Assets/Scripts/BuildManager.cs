using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Build Manager Singleton Settings")]
    public static BuildManager instance; //single instance of build manager
    private bool selected = false;

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
    private TowerBlueprint towerToBuild;

    [Header("Tower Prefabs")]
    public GameObject machineGunTurretPrefab;

    [Header("Build Particle Effect")]
    public GameObject buildEffect;



    public bool CanBuild { get { return towerToBuild != null; } } //property
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } } //property

    public void BuildTowerOn(Node node)
    {
       if(PlayerStats.Money < towerToBuild.cost) //if player doesnt have enough money
        {
            return;
        }

       PlayerStats.Money -= towerToBuild.cost; //subtract how much the tower cost from total money
       GameObject tower =(GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity); //instantate tower
       node.tower = tower; // play on the node

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        if (selected == false)
        {
            towerToBuild = tower;
            selected = true;
        }
        else
        {
            towerToBuild = null;
            selected = false;
        }
    }

    public void UnselectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = null;
    }

}
