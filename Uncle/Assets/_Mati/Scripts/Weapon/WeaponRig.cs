using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponRig
{
    public abstract Vector3 GetGunPosition();
    public abstract Quaternion GetGunRotacion();
    public abstract Vector3 GetGunScale();

    public abstract Vector3 GetLeftHandPosition();
    public abstract Quaternion GetLeftHandRotacion();

    public abstract Vector3 GetRightHandPosition();
    public abstract Quaternion GetRightHandRotacion();

}
