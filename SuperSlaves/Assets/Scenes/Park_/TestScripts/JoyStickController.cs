using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using SFML.Window;

public class JoyStickController : MonoBehaviour
{
    [SerializeField] private uint m_joystickCount;
    [SerializeField] private TextMeshProUGUI m_vectorTest;
    /*
    [DllImport("SFML.Window.dll")]
    public static extern void update();

    public enum Axis
    {
        X,    //!< The X axis
        Y,    //!< The Y axis
        Z,    //!< The Z axis
        R,    //!< The R axis
        U,    //!< The U axis
        V,    //!< The V axis
        PovX, //!< The X axis of the point-of-view hat
        PovY  //!< The Y axis of the point-of-view hat
    };

    [DllImport("SFML.Window.dll")]
    public static extern float GetAxisPosition(uint joystick, Axis axis);   //Axis가 좀 이상?함

    [DllImport("SFML.Window.dll")]
    public static extern bool IsConnected(uint joystick);
    */

    public void JoystickUpdate()
    {
        SFML.Window.Joystick.Update();
        for (uint i = 0; i < m_joystickCount; i++)
        {
            if (SFML.Window.Joystick.IsConnected(i))
            {
                float x = SFML.Window.Joystick.GetAxisPosition(i, SFML.Window.Joystick.Axis.X);
                float y = SFML.Window.Joystick.GetAxisPosition(i, SFML.Window.Joystick.Axis.Y);

                if (i == 0)
                {
                    m_vectorTest.text = $"({x}, {y})";
                }
            }
        }
    }
}
