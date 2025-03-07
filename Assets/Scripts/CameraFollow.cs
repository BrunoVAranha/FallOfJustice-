﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
  
  void Update () 
  {
      transform.position = new Vector3 
        (Mathf.Clamp(player.position.x + offset.x, -74.5f, 74.5f),
         player.position.y + offset.y,
         offset.z); // Camera follows the player with specified offset position
  }
}