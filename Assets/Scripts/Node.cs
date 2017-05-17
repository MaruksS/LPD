using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 pos;

    public GameObject tower;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    //sanem poziciju, lai uzbuvetu pieshi virs node
    public Vector3 GetPos()
    {
        return transform.position + pos;
    }

    void OnMouseDown()
    {
        //parbauda vai uz konkreta apgabala ir briva vieta un vai neaizsedz UI
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild) return;
        if (tower != null)
        {
            Debug.Log("can't build");
            return;
        }
        buildManager.Place(this);
    }
    void OnMouseEnter()
    {
        //iekraso apgabalu, kad pele uzbidas uz ta
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild) return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
