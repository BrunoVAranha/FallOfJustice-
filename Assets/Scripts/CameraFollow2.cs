﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public AudioSource audio;
    public AudioClip music;
  
  void Update () 
  {
      transform.position = new Vector3 
        (Mathf.Clamp(player.position.x + offset.x, -9.4f, 9.7f),
         player.position.y + offset.y,
         offset.z); // Camera follows the player with specified offset position
  }
}