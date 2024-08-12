using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CurrMovementEnum
{
	both,
	vertical,
	horizontal
}

public class ObjectDraggerPlatform_script : MonoBehaviour 
{
	public CurrMovementEnum objCurrMovementEnum;
	public List<Outline> outlines;

	private Vector3 screenPoint;
	private Vector3 offset;

	void Start()
	{
		outlines = new List<Outline>(transform.GetComponentsInChildren<Outline>());
		toggleOutline(false);
	}
	 
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		toggleOutline(true);
	}
	
	void OnMouseDrag()
	{
		Vector3 tempPos_vec3;

		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		tempPos_vec3 = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		if (objCurrMovementEnum == CurrMovementEnum.vertical)
		{
			transform.position = new Vector3(transform.position.x, tempPos_vec3.y, transform.position.z);
		}
		else if (objCurrMovementEnum == CurrMovementEnum.horizontal)
		{
			transform.position = new Vector3(tempPos_vec3.x, transform.position.y, transform.position.z);
		}
		else if (objCurrMovementEnum == CurrMovementEnum.both)
		{
			transform.position = tempPos_vec3;
		}
	}

	void OnMouseUp()
	{
		toggleOutline(false);
	}

	private void toggleOutline (bool enable)
	{
		if (outlines.Count > 0)
			foreach(Outline o in outlines)
			{
				o.enabled = enable;
			}
	}
}