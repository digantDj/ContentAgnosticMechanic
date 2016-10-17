using UnityEngine;
using System.Collections;

public class HealthContent : Content {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public HealthContent(string name, string description){
		base.description = description;
		base.name = name;
	}

	/// <summary>
	/// This is the same as above, but for longer than
	/// single char strings. This can also be for things
	/// like a message representing an objective to the
	/// player.
	/// </summary>
	/// <returns>A string specific to this content.</returns>
	public override string getTerm()
	{
		return "Disease";
		//return "NULL";
	}

}
