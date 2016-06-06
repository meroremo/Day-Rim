using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour 
{
	//private LineRenderer line;
	private bool isMousePressed, isTouchPressed;
	private List<Vector3> pointsList;
	private Vector3 mousePos;
    //private Sprite kiste;
    private int count=1;
    private GameObject[] lines;
    private Touch touch;
   
    private SpriteRenderer zeichenfeld;
	// Structure for line points
	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	};
	//	-----------------------------------	
	void Awake()
	{
        //Debug.Log("Test awake");
        touch = new Touch();
        zeichenfeld = GetComponent<SpriteRenderer>();
        // Create line renderer component and set its property
        lines = new GameObject[1000];
		//line = gameObject.AddComponent<LineRenderer>();
        lines[count] = new GameObject();
        lines[count].AddComponent<LineRenderer>();
        lines[count].gameObject.GetComponent<LineRenderer>().material =  new Material(Shader.Find("Particles/Additive"));
        //line.tag = "LineDraw";
        lines[count].gameObject.GetComponent<LineRenderer>().SetVertexCount(0);
        lines[count].gameObject.GetComponent<LineRenderer>().SetWidth(0.1f,0.1f);
        lines[count].gameObject.GetComponent<LineRenderer>().SetColors(Color.magenta, Color.magenta);
        lines[count].gameObject.GetComponent<LineRenderer>().useWorldSpace = true;	
		isMousePressed = false;
        isTouchPressed = false;
        count ++;
		pointsList = new List<Vector3>();
        
//		renderer.material.SetTextureOffset(
	}
	//	-----------------------------------	
	void Update () 
	{
        // If mouse button down, remove old line and set its color to green
        //Debug.Log(this.GetComponent<SpriteRenderer>().sprite.bounds.size.y);
        //Debug.Log(this.GetComponent<SpriteRenderer>().sprite.bounds.size.x);

        // Debug.Log(Input.mousePosition.ToString());
        //Debug.Log(count);
       // Debug.Log(lines.Length);

        if (Input.GetMouseButtonDown(0))
		{
			isMousePressed = true;
            //line.SetVertexCount(0);
            pointsList.RemoveRange(0,pointsList.Count); //wichtig damit neue line gezeichnet wird und nicht am punkt von der anderen weiter
            //line = gameObject.AddComponent<LineRenderer>();
            //lines[count].gameObject.GetComponent<LineRenderer>().SetColors(Color.magenta, Color.magenta);
		}
		else if(Input.GetMouseButtonUp(0) || Input.touchCount >0)
		{
            count++;
            
            lines[count] = new GameObject();
            lines[count].AddComponent<LineRenderer>();
            lines[count].gameObject.GetComponent<LineRenderer>().material = new Material(Shader.Find("Particles/Additive"));
            lines[count].gameObject.GetComponent<LineRenderer>().SetVertexCount(0);
            lines[count].gameObject.GetComponent<LineRenderer>().SetWidth(0.1f, 0.1f);
            lines[count].gameObject.GetComponent<LineRenderer>().SetColors(Color.magenta, Color.magenta);
            lines[count].gameObject.GetComponent<LineRenderer>().useWorldSpace = true;
            isMousePressed = false;
		}
        // Drawing line when mouse is moving(presses)
        if (isMousePressed)
        {
            Debug.Log(zeichenfeld.sprite.textureRect.height);
            Debug.Log(zeichenfeld.sprite.textureRect.width);
            Debug.Log(zeichenfeld.sprite.textureRect.x);
            Debug.Log(zeichenfeld.sprite.textureRect.y);
            if ((Input.mousePosition.y > zeichenfeld.sprite.textureRect.y && Input.mousePosition.y < zeichenfeld.sprite.textureRect.height && Input.mousePosition.x > zeichenfeld.sprite.textureRect.x
                && Input.mousePosition.x < zeichenfeld.sprite.textureRect.width))
                
            {

                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                if (!pointsList.Contains(mousePos))
                {
                    pointsList.Add(mousePos);
                    Debug.Log(lines[count]);
                    lines[count].gameObject.GetComponent<LineRenderer>().SetVertexCount(pointsList.Count);
                    lines[count].gameObject.GetComponent<LineRenderer>().SetPosition(pointsList.Count -1 , (Vector3)pointsList[pointsList.Count - 1]);
                    //if(isLineCollide())
                    //{
                    //	isMousePressed = false;
                    //	line.SetColors(Color.red, Color.red);
                    //}
                }
            }
        }
        else if(isTouchPressed)
        {
            if (touch.position.y > 100 && touch.position.y < 500 && touch.position.x > 500
                && touch.position.x < 863)
            {

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // = new List<Vector3>();
            
          
            // delete the LineRenderers when right mouse down
            // Destroy(line);
            /*GameObject[] delete = GameObject.FindGameObjectsWithTag("LineDraw");
            int deleteCount = delete.Length;
            for (int i = deleteCount - 1; i >= 0; i--)
                Destroy(delete[i]);*/
        }
    }
  
    //	-----------------------------------	
    //  Following method checks is currentLine(line drawn by last two points) collided with line 
    //	-----------------------------------	
    /*private bool isLineCollide()
	{
    if (Input.mousePosition.y < this.GetComponent<SpriteRenderer>().sprite.textureRect.height && Input.mousePosition.y > (this.GetComponent<SpriteRenderer>().sprite.texture.height - this.GetComponent<SpriteRenderer>().sprite.texture.height)
                && Input.mousePosition.x < this.GetComponent<SpriteRenderer>().sprite.texture.width && Input.mousePosition.x > (this.GetComponent<SpriteRenderer>().sprite.texture.width
                - this.GetComponent<SpriteRenderer>().sprite.texture.width))
		if (pointsList.Count < 2)
			return false;
		int TotalLines = pointsList.Count - 1;
		myLine[] lines = new myLine[TotalLines];
		if (TotalLines > 1) 
		{
			for (int i=0; i<TotalLines; i++) 
			{
				lines [i].StartPoint = (Vector3)pointsList [i];
				lines [i].EndPoint = (Vector3)pointsList [i + 1];
			}
		}
		for (int i=0; i<TotalLines-1; i++) 
		{
			myLine currentLine;
			currentLine.StartPoint = (Vector3)pointsList [pointsList.Count - 2];
			currentLine.EndPoint = (Vector3)pointsList [pointsList.Count - 1];
			if (isLinesIntersect (lines [i], currentLine)) 
				return true;
		}
		return false;
	}*/
    //	-----------------------------------	
    //	Following method checks whether given two points are same or not
    //	-----------------------------------	
    private bool checkPoints (Vector3 pointA, Vector3 pointB)
	{
		return (pointA.x == pointB.x && pointA.y == pointB.y);
	}
	//	-----------------------------------	
	//	Following method checks whether given two line intersect or not
	//	-----------------------------------	
	/*private bool isLinesIntersect (myLine L1, myLine L2)
	{
		if (checkPoints (L1.StartPoint, L2.StartPoint) ||
		    checkPoints (L1.StartPoint, L2.EndPoint) ||
		    checkPoints (L1.EndPoint, L2.StartPoint) ||
		    checkPoints (L1.EndPoint, L2.EndPoint))
			return false;
		
		return((Mathf.Max (L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min (L2.StartPoint.x, L2.EndPoint.x)) &&
		       (Mathf.Max (L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min (L1.StartPoint.x, L1.EndPoint.x)) &&
		       (Mathf.Max (L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min (L2.StartPoint.y, L2.EndPoint.y)) &&
		       (Mathf.Max (L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min (L1.StartPoint.y, L1.EndPoint.y)) 
		       );
	}*/
}