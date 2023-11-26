using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Node : MonoBehaviour
{
    [Header("Highlight Color Setup")]
    public Color hoverOverColor;
    private Color startColor;
    private Renderer rend;

    [Header("Turret Place Setup")]
    private GameObject turret;
    public Vector3 positionOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
       if(turret != null) //if we have already built something here
        {
            Debug.Log("This land ain't big enough for the two of us!!");
            //put a open canvas thing for maybe an uogrades menu where you can sell
            return;
        }

        //building a tower
        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        turret = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);

    }

    void OnMouseEnter()
    {
        rend.material.color = hoverOverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
