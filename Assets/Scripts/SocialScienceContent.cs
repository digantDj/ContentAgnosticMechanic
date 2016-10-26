using UnityEngine;
using System.Collections;

public class SocialScienceContent : Content {

	//private string[] dieases = {"dengue - A mosquito borne viral disease occurring in tropical and subtropical areas.","malaria","cold"," ","flu","aids"," ","cancer","tb"," ", " "};
	private string[] issues = {"child abuse - A","homelessness - A","immigration - A"," ","genocide - A","slavery - "," ","gun violence - A","racism - A"," ","drugs - A"};


	public SocialScienceContent(string name, string description){
		base.description = description;
		base.name = name;
	}

	public SocialScienceContent(){
		name = "Social Issues";
		description = "Protect US citizens from the various social issues in US history as they turn into reality once again.";
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
		return issues[Random.Range(0, issues.Length)].Split('-')[0];
	}

	public string getEntireTerm(string term){
		foreach (string item in issues) {
			if (item.Contains (term)) {
				return item;
			}
		}
		return "-1";
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