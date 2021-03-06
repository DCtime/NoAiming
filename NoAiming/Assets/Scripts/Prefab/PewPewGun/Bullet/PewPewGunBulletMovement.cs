﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGunBulletMovement : MonoBehaviour
{
    //從PewPewGunFire匯入
    [HideInInspector] public GameObject emenyObject;
    //儲存自己的鋼體，為了添加速度
    private Rigidbody2D rb;
    //相對位移
    private Vector3 relativePosition;
    //計算角度暫存區
    private float fireAngle;
    [Header("調整速度")]
    [SerializeField] private float speed;
    //Vector2 速度暫存區
    private Vector2 Vector2Speed;

    private void Start()
    {
        //儲存鋼體
        rb = GetComponent<Rigidbody2D>();
        // --- 算出角度 ---
        //計算角度
        relativePosition = emenyObject.transform.position - transform.position;

        fireAngle = Mathf.Atan(relativePosition.y / relativePosition.x) / Mathf.PI * 180;

        if (relativePosition.x < 0)
        {
            fireAngle += 180;
        }
        else if (relativePosition.y < 0)
        {
            fireAngle += 360;
        }
        //算出速度
        Vector2Speed = new Vector2(speed * Mathf.Cos(fireAngle / 180 * Mathf.PI), speed * Mathf.Sin(fireAngle / 180 * Mathf.PI));
        //賦予速度
        rb.velocity = Vector2Speed;

    }

}
