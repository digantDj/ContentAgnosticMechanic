﻿using UnityEngine;
using System.Collections;

/// <summary>
/// This is the one framework file you should be editing.
/// Everything else from the framework should not need editing.
/// </summary>
public static class GameInfo
{
    // Change to the title of your game.
    public const string gameTitle = "Bean Man - The Hero";

    // Change this to be an object of your child class.
	public static Mechanics currentMechanics = new EnemyShooterMechanic();

    // Change each of these to be one of your content objects. If you only have one, leave the second alone for now.
	//public static Content contentOne = new NoContent("Science/Health", "Prevent the diseases from spreading by shooting and surviving them till you can!");
	public static Content contentOne = new HealthContent("Health & Disease", "Help city during epidemic, kill dieseases without hitting humans!");
	public static Content contentTwo = new SocialScienceContent("Social Issues", "Protect US citizens from the various social issues in US history as they turn into reality once again.");
}
