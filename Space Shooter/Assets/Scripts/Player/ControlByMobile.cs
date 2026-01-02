using UnityEngine;
using UnityEngine.InputSystem;

public class ControlByMobile : MonoBehaviour
{
    public Camera mainCam;

    // Update is called once per frame
    void Update()
    {
        var touchScreen = Touchscreen.current;
        if (touchScreen == null) return;

        if (touchScreen.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = touchScreen.primaryTouch.position.ReadValue();
            Vector3 worldPos = mainCam.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 0));
            transform.position = new Vector3(worldPos.x, worldPos.y, 0);
        }
    }
}
