using UnityEngine;
using System.Collections;

public class HealthContent : Content {

	private string[] dieases = {"dengue","malaria","cold"," ","flu","aids"," ","cancer","tb"," "};

	public HealthContent(string name, string description){
		base.description = description;
		base.name = name;
	}

	public HealthContent(){
		name = "Health/Science";
		description = "Keep humans healthy by shooting dieseases";
	}

	/*public override char getItem(){
		return dieases [Random.Range (0, dieases.Length)];
	}*/

	/// <summary>
	/// This is the same as above, but for longer than
	/// single char strings. This can also be for things
	/// like a message representing an objective to the
	/// player.
	/// </summary>
	/// <returns>A string specific to this content.</returns>
	public override string getTerm()
	{
		return dieases [Random.Range (0, dieases.Length)];
	//	return "Shoot the Disease!";
		//return "NULL";
	}

	protected override void customHook(Hook hook){
		switch (hook.type) {
		case HookType.IsEmpty:
			isEmptyHook ((IsEmptyHook)hook);
			break;
		default:
			base.customHook (hook);
			break;
		}
	}

	private void isEmptyHook(IsEmptyHook hook){
		
		if (hook.input.Equals (" ")) {
			lastActionValid = false;
		} else {
			lastActionValid = true;
		}
	}
}
