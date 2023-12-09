using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverRig : WeaponRig
{
    public override Vector3 GetGunPosition()
    {
        return new Vector3(0f, 0f, 0.35f);
    }

    public override Quaternion GetGunRotacion()
    {
        return Quaternion.Euler(0f, 0f, 0f);
    }

    public override Vector3 GetGunScale()
    {
        return Vector3.one;
    }

    public override Vector3 GetLeftHandPosition()
    {
        return new Vector3(-0.051f, 0.077f, 0.416f);
    }

    public override Quaternion GetLeftHandRotacion()
    {
        return Quaternion.Euler(199.51f, -211.045f, -60.11099f);
    }

    public override Vector3 GetRightHandPosition()
    {
        return new Vector3(0.054f, -0.051f, 0.341f);
    }

    public override Quaternion GetRightHandRotacion()
    {
        return Quaternion.Euler(64.77f, -26.534f, 71.02f);
    }


}
