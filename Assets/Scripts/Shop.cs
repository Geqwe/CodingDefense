using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;

    BuildManager buildManager;

    public void SelectStandardTurret() {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
