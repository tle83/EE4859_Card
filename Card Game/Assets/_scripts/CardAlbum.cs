﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardAlbum : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	Transform parentToReturnTo = null;


	public void OnPointerEnter(PointerEventData eventData){

	}

	public void OnPointerExit(PointerEventData eventData){
		
	}

	public void OnDrop(PointerEventData eventData){
		PlayerController pcontrol = eventData.pointerDrag.GetComponent<PlayerController> ();
		if (pcontrol != null) {
			//hold the cards
			pcontrol.parentToReturnTo = this.transform;
		}
	}

}