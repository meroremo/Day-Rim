using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DetectTouches : MonoBehaviour {

    private GameObject selectedObject;
    private Ray ray;
    private RaycastHit rayHit;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GameObject.Find("TestText").GetComponent<Text>().text = "HOT HOT HOT";
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Touch touch = Input.touches[0];
            
            // touchPosition = Input.GetTouch(0).position;

            //if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            //{
            //    GameObject.Find("TestText").GetComponent<Text>().text = "CHICK CHICK CHICK";

            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
                {
                    GameObject.Find("TestText").GetComponent<Text>().text = "HIT HIT HIT";

                    GameObject hitObject = rayHit.transform.gameObject;
                    selectedObject = hitObject;

                   

                    if (hitObject.tag == "OpenDialog")
                    {
                        GameObject.Find("TestText").GetComponent<Text>().text = "LUISE LUISE LUISE";
                        SceneManager.LoadScene("DialogScene");
                    }



                    /*        // GameObject.Find("TestText").GetComponent<Text>().text = "HIT HIT HIT";
                            hit = Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                    //GameObject.Find("TestText").GetComponent<Text>().text = Input.GetTouch(0).position.ToString();
                   if (hit.collider != null && hit.transform.gameObject.tag == "Karton_Luise") 
                    { 
                        GameObject.Find("TestText").GetComponent<Text>().text = "Invenape getouched doooown..";
                    }*/
              //  }
            }
        }
    }
}
