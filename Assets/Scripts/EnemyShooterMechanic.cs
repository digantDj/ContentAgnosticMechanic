using UnityEngine;
using System.Collections;

public class EnemyShooterMechanic : Mechanics {

	public void sendHook(char c, char[] cs)
	{
		passHook(new CompareHook(c, cs));
	}
}
