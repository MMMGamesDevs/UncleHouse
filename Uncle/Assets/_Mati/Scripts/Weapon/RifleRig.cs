using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleRig : WeaponRig
{
    public override Vector3 GetGunPosition()
    {
        return new Vector3(0f, 0f, 0.3f);
    }

    public override Quaternion GetGunRotacion()
    {
        return Quaternion.Euler(180f, 180f, 180f);
    }

    public override Vector3 GetGunScale()
    {
        return Vector3.one;
    }

    public override Vector3 GetLeftHandPosition()
    {
        return new Vector3(-0.04800001f, 0.104f, 0.511f);
    }

    public override Quaternion GetLeftHandRotacion()
    {
        return Quaternion.Euler(199.51f, -211.045f, -60.11099f);
    }

    public override Vector3 GetRightHandPosition()
    {
        return new Vector3(0.02689999f, -0.06600001f, 0.2479f);
    }

    public override Quaternion GetRightHandRotacion()
    {
        return Quaternion.Euler(64.77f, -26.534f, 71.02f);
    }

    
}
