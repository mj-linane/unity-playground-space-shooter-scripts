using UnityEngine;
using System.Collections;

public class CameraFollowInterpolate : MonoBehaviour {

    public Transform objectToFollow;
    float bottom = 0.0f;
    float lead = 10f;
    float above = 5f;
    float minView = 16;

    void Start () {

    }

    void FixedUpdate(){
        float height = objectToFollow.position.y + above - bottom;
        height = Mathf.Max(height,minView);
        height /= 2.0f;
        Camera.main.orthographicSize = height;
        transform.position = new Vector3 (objectToFollow.position.x + lead, bottom + height, transform.position.z);
    }
}