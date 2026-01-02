using UnityEngine;
using UnityEngine.InputSystem;

public class ControlInMobile : MonoBehaviour
{
    public Camera mainCam;
    private int tempInt = 0;

    private void Start()
    {
        transform.position = Vector3.zero;
        Debug.Log("Start!!");
        Debug.Log("Pos: " + transform.position);
    }

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
            tempInt++;
        }

        if(tempInt == 1 && !touchScreen.primaryTouch.press.isPressed)
        {
            var lastestFrameTouch = touchScreen.primaryTouch.ReadValueFromPreviousFrame();
            Vector3 worldPos = mainCam.ScreenToWorldPoint(lastestFrameTouch.position);
            transform.position = new Vector3(worldPos.x, worldPos.y, 0);
            tempInt--;
        }
    }
}
