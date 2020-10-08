using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake() {
        if(instance != null) {
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    void Start() {
        turreToBuild = standardTurretPrefab;
    }

    private GameObject turreToBuild;
    
    public GameObject GetTurretToBuild() {
        return turreToBuild;
    }
}
