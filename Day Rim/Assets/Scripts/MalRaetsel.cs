using UnityEngine;
using System.Collections.Generic;

using System.Collections;
using System;

[RequireComponent(typeof(LineRenderer))]
public class MalRaetsel : MonoBehaviour
{
    void Update()

    {
        Debug.Log("Test1");
       
        if ( Input.GetMouseButton(0))
        {
            Debug.Log("Mouse down");
            // Send a ray to collide with the plane
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Test2");
                // Find the u,v coordinate of the Texture
                Vector2 uv;
                uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                // Paint it red
                //Texture2D tex = (Texture2D)hit.transform.gameObject.renderer.sharedMaterial.mainTexture;
                GetComponent<SpriteRenderer>().sprite.texture.SetPixel((int)(uv.x * GetComponent<SpriteRenderer>().sprite.texture.width), (int)(uv.y * GetComponent<SpriteRenderer>().sprite.texture.height), Color.red);
                GetComponent<SpriteRenderer>().sprite.texture.Apply();
            }
        }
    }

}



