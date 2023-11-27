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

    

    public bool CanBuild { get { return towerToBuild != null; } } //property

    public void BuildTowerOn(Node node)
    {
       if(PlayerStats.Money < towerToBuild.cost)
        {
            return;
        }

       PlayerStats.Money -= towerToBuild.cost;
       GameObject tower =(GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
       node.tower = tower;
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
