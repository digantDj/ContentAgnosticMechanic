using UnityEngine;
using System.Collections;

public class SocialScienceContent : Content {

	private string[] issues = {"child abuse- Child abuse is when a parent or caregiver, whether through action or failing to act, causes injury, death, emotional harm or risk of serious harm to a child.","gender inequality- Gender inequality refers to unequal treatment or perceptions of individuals based on their gender. It arises from differences in socially constructed gender roles."," " ,"corruption- Dishonest or fraudulent conduct by those in power, typically involving bribery."," ","genocide- The deliberate killing of a large group of people, especially those of a particular ethnic group or nation."," ","slavery- Slavery in America began when the first African slaves were brought to the North American colony of Jamestown, Virginia, in 1619, to aid in the production of such lucrative crops as tobacco."," ","gun violence- Gun related violence is violence committed with the use of a gun (firearm or small arm). ","racism- The belief that all members of each race possess characteristics or abilities specific to that race, especially so as to distinguish it as inferior or superior to another race or races."," "};


	public SocialScienceContent(string name, string description){
		base.description = description;
		base.name = name;
	}

	public SocialScienceContent(){
		name = "Social Issues";
		description = "Protect US citizens from the various social issues in US history as they turn into reality once again.";
	}
		
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