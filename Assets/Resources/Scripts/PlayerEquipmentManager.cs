using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    WeaponLoaderSlot weaponLoaderSlot;
    AnimatorManager animatorManager;

    [Header("Current Equipment")]
    public WeaponItem weapon;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        LoadWeaponLoaderSlot();
    }

    private void Start()
    {
        LoadCurrentWeapon();
    }

    private void LoadWeaponLoaderSlot()
    {
        //BackSlot
        //HipSlot
        weaponLoaderSlot = GetComponentInChildren<WeaponLoaderSlot>();
    }

    private void LoadCurrentWeapon()
    {
        weaponLoaderSlot.LoadWeaponModel(weapon);
        //Load Current Weapon to the player Hand
        animatorManager.animator.runtimeAnimatorController = weapon.weaponAnimator;
        //Change the player animations to the weapons animation
    }
}
