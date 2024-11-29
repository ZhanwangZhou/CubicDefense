using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 40;
    public float scrollSpeed = 80;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");

        transform.Translate(new Vector3(horizontal, scroll * scrollSpeed, vertical) * Time.deltaTime * speed, Space.World);
    }
}
