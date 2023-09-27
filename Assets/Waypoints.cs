
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points; //static list of game objects in the scene

    void Awake()
    {
        points = new Transform[transform.childCount]; //transform array with a length of the number of childeren under waypoints (should be of size 20)
        for(int i = 0; i < points.Length; i++) //iterating through and getting every child of the waypoints object and pushing that into our array at the ith slot
        {
           points[i] = transform.GetChild(i); // list of all the children we can access here
        }
    }
}
