using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShotgun : MonoBehaviour
{

    public Movement move_script;
    public bool GetWeapon;

    public GameObject Weapon_Sprite2;
    void Start()
    {
        Weapon_Sprite2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shotgun"))
        {
            Debug.Log("Weapon picked up");
            GetWeapon = true;
            Weapon_Sprite2.SetActive(true);
        }
    }
}