using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawn : MonoBehaviour
{
    public GameObject batteryPrefab;

    private List<Vector3> _locations = new List<Vector3>{ 
                                                    new Vector3(-4.5f, -1f, 0),
                                                    new Vector3(5.5f, -0.5f, 0),
                                                    new Vector3(-3.5f, 1.5f, 0)
                                                        };

    void Start()
    {
        for(var i = 0; i < _locations.Count; i++){
            GameObject obj = Instantiate(batteryPrefab,_locations[i], Quaternion.identity);
            obj.transform.SetParent(this.transform);
        }

    }
}
