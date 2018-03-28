﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour 
{
	public OneSoldierManager[,] soldiers = new OneSoldierManager[6,6];
	public OneCropManager[,] crops = new OneCropManager[6,6];
	public GameObject Soldier;
	public GameObject Crop;
	private bool isCreated;
	private bool isSelected;

	private Vector2 mouseOver;
	private Vector2 startDrag;
	private Vector2 endDrag;

	private Vector3 boardOffset = new Vector3(-2,-1,0);

	private OneSoldierManager selectedSoldier;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateMouseOver ();

		int x = (int)mouseOver.x;
		int y = (int)mouseOver.y;

		if (Input.GetMouseButtonDown(0))
		{
			SelectSoldier (x, y);
		}
		/*if (Input.GetMouseButtonUp (0)) 
		{
			TryMove ((int)startDrag.x, (int)startDrag.y, x, y);
		}*/
	}

	void UpdateMouseOver() 
	{
		if (!Camera.main)
		{
			Debug.Log ("cannot find main camera");
			return;
		}

		RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
		{
			mouseOver.x = (int)(hit.collider.transform.position.x - boardOffset.x);
			mouseOver.y = (int)(hit.collider.transform.position.y - boardOffset.y);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		//Debug.Log ("collision detected");
		if (collider.gameObject.tag == "card" && collider.gameObject.GetComponent<OneCardManager>().cardAsset.TypeOfCard == TypesOfCards.Soldier && collider.gameObject.GetComponent<DraggingActionsReturn>().dragging == false) 
		{
			GenerateSoldier (collider, 0, 0);
		}

		if(collider.gameObject.tag == "card" && collider.gameObject.GetComponent<OneCardManager>().cardAsset.TypeOfCard == TypesOfCards.Crop && collider.gameObject.GetComponent<DraggingActionsReturn>().dragging == false)
		{
			GenerateCrop (collider, 0, 2);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		isCreated = false;
	}

	private void GenerateSoldier(Collider collider, int x, int y)
	{
		if (!isCreated) {
			GameObject newGO = Instantiate (Soldier) as GameObject;
			newGO.transform.position = new Vector3 (x, y, 0);
			newGO.gameObject.GetComponent<OneSoldierManager> ().cardAsset = collider.gameObject.GetComponent<OneCardManager> ().cardAsset;
			//newGO.transform.SetParent (this.gameObject.transform, false);
			Destroy (collider.gameObject);
			//Debug.Log (collider.gameObject.GetComponent<OneCardManager> ().cardAsset.name);
			OneSoldierManager s = newGO.GetComponent<OneSoldierManager>();
			soldiers[x, y] = s;
			isCreated = true;
		}
	}

	private void GenerateCrop(Collider collider, int x, int y)
	{
		if (!isCreated) {
			GameObject newGO = Instantiate (Crop) as GameObject;
			newGO.transform.position = new Vector3 (x, y, 0);
			newGO.gameObject.GetComponent<OneCropManager> ().cardAsset = collider.gameObject.GetComponent<OneCardManager> ().cardAsset;
			//newGO.transform.SetParent (this.gameObject.transform, false);
			Destroy (collider.gameObject);
			//Debug.Log (collider.gameObject.GetComponent<OneCardManager> ().cardAsset.name);
			OneCropManager c = newGO.GetComponent<OneCropManager>();
			crops[x, y] = c;
			isCreated = true;
		}
	}

	private void SelectSoldier(int x, int y)
	{
		//out of bounds
		if (x < 0 || x > 6 || y < 0 || y > 6)
			return;
		
		/*RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && !isSelected)
		{
			Debug.Log (hit.collider.name);
			if (hit.collider.tag == "soldier") 
			{
				selectedSoldier = hit.collider.gameObject.GetComponent<OneSoldierManager>();
				startDrag = mouseOver;
				Debug.Log (selectedSoldier.gameObject.name);
				isSelected = true;
			}
		}*/

		OneSoldierManager s = soldiers[x,y];
		if (s != null)
		{
			selectedSoldier = s;
			startDrag = mouseOver;
			Debug.Log(selectedSoldier.gameObject.name);
		}
		else
			Debug.Log("nothing there");
		
	}

	/*private void TryMove(int x1, int y1, int x2, int y2)
	{
		startDrag = new Vector2 (x1, y1);
		endDrag = new Vector2 (x2, y2);
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit) && isSelected) 
		{
			selectedSoldier = hit.collider.gameObject.GetComponent<OneSoldierManager>();
		}

		MoveSoldier (selectedSoldier, x2, y2);
	}

	private void MoveSoldier(OneSoldierManager soldier, int x, int y)
	{
		soldier.transform.position = (Vector3.right * x) + (Vector3.up * y) + boardOffset;
	}*/

}
