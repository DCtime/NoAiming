﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGunFire : MonoBehaviour
{
    //儲存發射鍵
    private KeyCode fireKey;

    [Header("子彈Prefab")]
    [SerializeField] private GameObject bulletType;

    [Header("槍口")]
    [SerializeField] private GameObject muzzle;

    [Header("槍枝參數")]
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;

    //儲存最近發射的子彈
    private GameObject currentBullet;

    [Header("敵方物件")]
    [SerializeField] private GameObject emenyObject;

    private void Awake()
    {
        //初始化fireKey
        fireKey = gameObject.transform.parent.gameObject.GetComponent<PlayerFire>().fireKey;
    }

    private void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            //產生子彈，並放到muzzle
            currentBullet = Instantiate(bulletType, muzzle.transform.position, transform.rotation);
            Debug.Log("currentBullet is instantiate!");
            //將產生出來的物件之元件加入一些參數
            currentBullet.GetComponent<PewPewGunBulletMovement>().emenyObject = emenyObject;

            currentBullet.GetComponent<PewPewGunBulletCollider>().emenyObject = emenyObject;
            currentBullet.GetComponent<PewPewGunBulletCollider>().damage = damage;

        }
    }


}
