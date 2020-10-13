using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Renderer rend;
    private Color startColor; 
    public Color NotEnoughMoneyColor;
    public GameObject turret;
    private Vector3 offset;
    BuildManager buildManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        offset = new Vector3(0f, 0.5f, 0f);
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() {
        return transform.position+offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        if(EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if(!buildManager.CanBuild) {
            return;
        }

        if(turret != null) {
            Debug.Log("Can't build there");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter() {
        if(EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if(!buildManager.CanBuild) {
            return;
        }

        if(buildManager.HasMoney) {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = NotEnoughMoneyColor;
        }
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
