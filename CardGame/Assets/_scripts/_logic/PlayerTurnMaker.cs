﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnMaker : TurnMaker {

	public override void OnTurnStart(){
		base.OnTurnStart ();
		if (player.PlayerColor == "blue") {
			new ShowMessageCommand ("Your Turn", 2.0f).AddToQueue ();
			MessageManager.Instance.ShowMessage ("Your Turn", 1.0f);
		//	Board.Instance.PlayerInput (Board.Instance.x, Board.Instance.y);
		}
		else if (player.PlayerColor == "red") {
			new ShowMessageCommand ("Enemy Turn", 2.0f).AddToQueue ();
			MessageManager.Instance.ShowMessage ("Enemy Turn", 1.0f);
		//	Board.Instance.PlayerInput (Board.Instance.x, Board.Instance.y);
		}
		player.DrawACard();
	}
}
