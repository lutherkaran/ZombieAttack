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
        //Load Current Weapon to the player Hand
        weaponLoaderSlot.LoadWeaponModel(weapon);
        //Change the player animations to the weapons animation
        animatorManager.animator.runtimeAnimatorController = weapon.weaponAnimator;
    }
}
