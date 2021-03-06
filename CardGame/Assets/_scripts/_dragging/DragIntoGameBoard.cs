﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DragIntoGameBoard : DraggingActions
{

    private Vector3 savedPos;

    public override void OnStartDrag()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
            savedPos = transform.position;
    }

    public override void OnEndDrag()
    {
        transform.DOMove(savedPos, 0.1f);
       	transform.DOMove (savedPos, 1f).SetEase (Ease.OutBounce, 0.5f, 0.1f);
        transform.DOMove (savedPos, 1f).SetEase (Ease.OutQuint, 0.5f, 0.1f);
    }

    public override void OnDraggingInUpdate()
    {

    }

    protected override bool DragSuccessful()
    {
        return true;
    }

	public override void OnCancelDrag(){

	}


}
