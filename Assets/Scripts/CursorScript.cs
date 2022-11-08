using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * 5f * Time.deltaTime, Input.GetAxis("Vertical") * 5f * Time.deltaTime, 0f);
    }
}
