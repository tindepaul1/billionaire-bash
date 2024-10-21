using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickup : MonoBehaviour
{

    public Movement move_script;
    public bool GetWeapon;

    public GameObject Weapon_Sprite;
    void Start()
    {
        Weapon_Sprite.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rifle"))
        {
            Debug.Log("Weapon picked up");
            GetWeapon = true;
            Weapon_Sprite.SetActive(true);
        }
    }
}