using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInBounds : MonoBehaviour
{

  public int xUpperLimit = 200;
  public int xLowerLimit = -200;
  public int yUpperLimit = 200;
  public int yLowerLimit = -200;

  private Vector3 currentPos;
  // Start is called before the first frame update

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    currentPos = transform.position;
    if (currentPos.y > yUpperLimit)
    {
      currentPos.y = yLowerLimit;
    }

    if (currentPos.y < yLowerLimit)
    {
      currentPos.y = yUpperLimit;
    }

    if (currentPos.x > xUpperLimit)
    {
      currentPos.x = xLowerLimit;
    }

    if (currentPos.x < xLowerLimit)
    {
      currentPos.x = xUpperLimit;
    }

    transform.position = currentPos;

  }
}
