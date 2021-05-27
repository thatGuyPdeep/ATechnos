using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GunController theGun;

    public RotatePlayer rp;

    void FixedUpdate()
    {
        //Gamepad Shooting
        if (Mathf.Abs(rp.gamepadPos.x) > 0.7 || Mathf.Abs(rp.gamepadPos.y) > 0.7)
        {
            theGun.isFiring = true;
        }
        else
        {
            theGun.isFiring = false;
        }

        /*
        //Mouse Shooting
        var mouse = Mouse.current;

        if(mouse == null)
        {
            return;
        }

        if (mouse.leftButton.wasPressedThisFrame)
        {
            theGun.isFiring = true;
            Debug.Log("Fire");
        }
        */
    }  
}
