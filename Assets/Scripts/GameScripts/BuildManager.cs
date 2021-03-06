﻿using System.Collections;
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

    private TurretBlueprint turretToBuild;
    
    //property
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node) {
        if(PlayerStats.Money < turretToBuild.cost) {
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret =  (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
