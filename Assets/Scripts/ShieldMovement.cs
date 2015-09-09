using UnityEngine;
using System.Collections;

public class ShieldMovement : MonoBehaviour {

	public float tempX,tempY,tempZ;
	public int tempN = 0;
	public float temp = -15;
	public GameObject shield;
	public DirectionChecker dc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//print(transform.position.x);
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		//print (dc.CurrentDirection);
		tempX = Input.mousePosition.x - transform.position.x -550;
		tempY = Input.mousePosition.y - transform.position.y - 200;
		
		tempZ = Input.mousePosition.z - transform.position.z;
		if (dc.CurrentDirection == 1)
		{
			
			if((tempX > 0)&&(tempY - tempX > 0))
			{
				if (tempN != 1)
				{
					shield.transform.Translate(new Vector3(0,2f,0));
					shield.transform.Rotate(new Vector3(-45,0,0));
					tempN = 1;
				}
			}
			else if ((tempY - tempX < 0) && (tempY > 0))
			{
				if(tempN == 1)
				{	
					shield.transform.Rotate(new Vector3(45,0,0));
					shield.transform.Translate(new Vector3(0,-2f,0));
					tempN = 0;
				}
				else if (tempN == -1)
				{
					shield.transform.Rotate(new Vector3(-45,0,0));
					shield.transform.Translate(new Vector3(0,2f,0));
					tempN = 0;
				}
			}
			else if ((tempY < 0) && (tempY + tempX > 0))
			{
				if (tempN != -1)
				{
					shield.transform.Translate(new Vector3(0,-2f,0));
					shield.transform.Rotate(new Vector3(45,0,0));
					tempN = -1;
				}
			}
			else
			{
				if(tempN == 1)
				{
					shield.transform.Rotate(new Vector3(45,0,0));
					shield.transform.Translate(new Vector3(0,-2f,0));
					tempN = 0;
				}
				else if (tempN == -1)
				{
					shield.transform.Rotate(new Vector3(-45,0,0));
					shield.transform.Translate(new Vector3(0,2f,0));
					tempN = 0;
				}
			}
			temp = transform.position.x;
		}
		else if (dc.CurrentDirection == -1)
		{
			
			if((tempX < 0)&&(tempY + tempX > 0))
			{
				if (tempN != 1)
				{
					shield.transform.Translate(new Vector3(0,2f,0));
					shield.transform.Rotate(new Vector3(-45,0,0));
					tempN = 1;
				}
			}
			else if ((tempY + tempX < 0) && (tempY > 0))
			{
				if(tempN == 1)
				{	
					shield.transform.Rotate(new Vector3(45,0,0));
					shield.transform.Translate(new Vector3(0,-2f,0));
					tempN = 0;
				}
				else if (tempN == -1)
				{
					shield.transform.Rotate(new Vector3(-45,0,0));
					shield.transform.Translate(new Vector3(0,2f,0));
					tempN = 0;
				}
			}
			else if ((tempY < 0) && (tempY - tempX > 0))
			{
				if (tempN != -1)
				{
					shield.transform.Translate(new Vector3(0,-2f,0));
					shield.transform.Rotate(new Vector3(45,0,0));
					tempN = -1;
				}
			}
			else
			{
				if(tempN == 1)
				{
					shield.transform.Rotate(new Vector3(45,0,0));
					shield.transform.Translate(new Vector3(0,-2f,0));
					tempN = 0;
				}
				else if (tempN == -1)
				{
					shield.transform.Rotate(new Vector3(-45,0,0));
					shield.transform.Translate(new Vector3(0,2f,0));
					tempN = 0;
				}
			}
			temp = transform.position.x;
		}
		
		
	}
}
