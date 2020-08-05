using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHelper
{
    Vector3 mousePositionStart;
    Vector3 mousePositionCurrent;

    float mod = 0;

    // return if opened
    public (bool, float) GetNextMod()
    {
        mousePositionCurrent = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            mousePositionStart = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            mod = (mousePositionCurrent.x - mousePositionStart.x) / (Screen.width / 4);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (mod > 0)
            {
                return (true, mod);
            }
        }
        return (false, mod);
    }
}
