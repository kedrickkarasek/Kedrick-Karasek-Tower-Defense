using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Highlight Color Setup")]
    public Color hoverOverColor;
    public Color noMoneyColor;
    private Color startColor;
    private Renderer rend;

    [Header("Turret Place Setup")]
    public Vector3 positionOffset;
    [Header("Optional Setup")]
    public GameObject tower;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

       if(tower != null) //if we have already built something here
        {
            Debug.Log("This land ain't big enough for the two of us!!");
            //put a open canvas thing for maybe an uogrades menu where you can sell
            return;
        }

        buildManager.BuildTowerOn(this);

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverOverColor;
        }
        else
        {
            rend.material.color = noMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
