using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Stats/Weapons/MachineGunStats")]
public class MachineGunStats : WeaponStats
{
    [field: SerializeField] public int BulletsPerShot { get; private set;} = 5; 
    

}
