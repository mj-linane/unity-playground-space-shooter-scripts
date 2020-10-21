﻿using UnityEngine;
using System.Collections;

public class TeleportActionRandom : MonoBehaviour
{
  private float x;
  private float y;

  // Moves the GameObject instantly to a custom position

  void OnCollisionEnter2D(Collision2D collision)
  {
    x = Random.Range(-200, 200);
    y = Random.Range(-200, 200);

    collision.transform.position = new Vector2(x, y);
  }
}
