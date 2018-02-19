﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler  {

	//vectors to track the card's movement on screen
	private Vector3 offset;
	private Vector3 curPositionCard;
	private Vector3 newPositionCard;

	Transform parentToReturnTo = null;

	void start()
	{
	}

	public void OnBeginDrag(PointerEventData eventData){
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag (PointerEventData eventData){
		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){
		this.transform.SetParent (parentToReturnTo);

		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	public void OnDrop(PointerEventData eventData){

		PlayerController pcontrol = eventData.pointerDrag.GetComponent<PlayerController> ();
		if (pcontrol != null) {
			pcontrol.parentToReturnTo = this.transform;
		}
	}

	public void OnPointerEnter(PointerEventData eventData){

	}

	public void OnPointerExit(PointerEventData eventData){

	}



	//click and hold the left mouse button
	/*
	void OnMouseDown()
	{
		curPositionCard = gameObject.transform.position;

		Debug.Log (gameObject.GetComponent<CardManager> ().cardName);	//read name of card'

		offset = curPositionCard - Camera.main.ScreenToWorldPoint (
			new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));
	}

	//the object that is clicked on will follow the position of the mouse
	void OnMouseDrag()
	{
		Vector3 newPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		transform.position = Camera.main.ScreenToWorldPoint (newPosition) + offset;
	}

	void OnMouseUp()
	{
		newPositionCard = gameObject.transform.position;

		//test position of the card if it's within the card builder
		if (newPositionCard.x > 5.5f) {
			//put card into into a container, then destroy the object (card)

		} 
		//if it is NOT within card builder, go back to original position
		else {
			transform.position = curPositionCard;
		}

	}*/


}