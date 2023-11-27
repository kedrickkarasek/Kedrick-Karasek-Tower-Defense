using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TowerBlueprint machineGunTurret;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectMachineGunTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTowerToBuild(machineGunTurret);
    }

    public void SelectAnotherTurret()
    {
        Debug.Log("Standard Turret Purchased");
    }
}
