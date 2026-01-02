using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlByMouse : MonoBehaviour
{
    public Camera mainCam;

    // Update is called once per frame
    void Update()
    {
        /*Vector3 worldPoint = mainCam.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        transform.position = worldPoint;*/
        var mouse = Mouse.current;
        if (mouse == null) return;

        Vector2 mousePos = mouse.position.ReadValue();
        Vector3 worldPos = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        transform.position = new Vector3(worldPos.x, worldPos.y, 0);
    }
}
