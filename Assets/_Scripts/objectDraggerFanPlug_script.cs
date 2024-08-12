using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class objectDraggerFanPlug_script : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;
	bool fanPlugAttached_bool = false;
	public Rigidbody rb;
	public bool isRoller_bool;
	bool canMove_bool;
	public Vector3 posOffset = new Vector3(0.8746666f,0f,-0.034f);
	public bool followRotation = false;
	public List<Outline> outlines;
	public bool allowDisconnection = true;
	public bool isConnected = false;

	void Start()
	{
		outlines = new List<Outline>(transform.GetComponentsInChildren<Outline>());
		toggleOutline(false);
	}

	void OnMouseDown()
	{
		//if (!fanPlugAttached_bool)
		//{
		if (isRoller_bool && isConnected)
			return;
		canMove_bool = true;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		rb.isKinematic = true;
		rb.useGravity = false;

		toggleOutline(true);		//}
	}

	void OnMouseDrag()
	{
	 //if (!fanPlugAttached_bool)
	 //{
		if(canMove_bool)
		{ 
			Vector3 tempPos_vec3;
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			transform.position = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		}
	}

	void OnMouseUp()
	{
		canMove_bool = false;

		if (!fanPlugAttached_bool)
		{
			rb.isKinematic = false;
			rb.useGravity = true;
		}

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

	//private void OnTriggerStay(Collider coll)
	//{
	//	if (!isRoller_bool)
	//	{
	//		if (coll.name == gameObject.transform.parent.name)
	//		{
	//			canMove_bool = false;
	//			rb.isKinematic = true;
	//			rb.useGravity = false;
	//			fanPlugAttached_bool = true;
	//			gameObject.transform.parent.transform.GetComponent<fanButton_script>().OnAllFans_func();
	//		}
	//	}
	//}

    private void OnTriggerEnter(Collider coll)
	{
		if (!isRoller_bool)
		{
			if (coll.name == gameObject.transform.parent.name)
			{
				canMove_bool = false;
				rb.isKinematic = true;
				rb.useGravity = false;
				fanPlugAttached_bool = true;
		
				gameObject.transform.parent.transform.GetComponent<fanButton_script>().OnAllFans_func();
				////gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.green, 0.2f);
		
				transform.DOMove (transform.parent.position + posOffset,0.2f);
				//gameObject.transform.DOLocalMove(new Vector2(0, 1), 0.2f);
				////coll.gameObject.GetComponent<fanButton_script>().fanWireAttached_bool = true;
			}
		}

		if (coll.tag == "rotater")
		{
			rb.isKinematic = true;
			rb.useGravity = false;
			fanPlugAttached_bool = true;

			canMove_bool = false;

			isConnected = true;

			gameObject.transform.SetParent(coll.gameObject.transform);//.GetComponent<rotater_script>().rotaterSlot_gm.transform);
			gameObject.transform.DOMove(coll.transform.position +  offset, 0.2f);
			transform.rotation = transform.parent.rotation;
			print(coll.gameObject.transform.parent);
			coll.gameObject.transform.parent.transform.GetComponent<rotater_script>().load_gm.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			coll.gameObject.transform.parent.transform.GetComponent<rotater_script>().load_gm.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		}
	}


	private void OnTriggerExit(Collider coll)
	{
		if (!isRoller_bool)
		{
			if (fanPlugAttached_bool)
			{
				fanPlugAttached_bool = false;
				gameObject.transform.parent.transform.GetComponent<fanButton_script>().OffAllFans_func();
				////gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.2f);

				//coll.gameObject.GetComponent<fanButton_script>().fanWireAttached_bool = false;
			}
		}
	}

}
