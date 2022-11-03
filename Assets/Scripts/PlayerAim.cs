using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform firingPoint;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        firingPoint.LookAt(GetMousePositionInPlaneOfLauncher());
    }

    Vector3 GetMousePositionInPlaneOfLauncher()
    {
        Plane p = new Plane(mainCamera.transform.forward, firingPoint.position);
        Ray r = mainCamera.ScreenPointToRay(Input.mousePosition);
        float d;
        Debug.DrawRay(r.origin, r.direction * 10, Color.red);
        return r.direction;
        if (p.Raycast(r, out d))
        {
            Vector3 v = r.GetPoint(d);
            return v;
        }

        throw new UnityException("Mouse position ray not intersecting launcher plane");
    }

    
}
