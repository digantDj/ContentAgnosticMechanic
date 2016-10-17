using UnityEngine;
using System.Collections;

public class EnemyShooterMechanic : Mechanics {

	public void sendHook(string c)
	{
		passHook(new IsEmptyHook(c));
	}
}
