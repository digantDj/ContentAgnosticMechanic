using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthContent : Content {

	//private string[] dieases = {"dengue - A mosquito borne viral disease occurring in tropical and subtropical areas.","malaria","cold"," ","flu","aids"," ","cancer","tb"," ", " "};
	private string[] dieases = {"dengue- A mosquito borne viral disease occurring in tropical and subtropical areas."," ","malaria- A disease caused by a plasmodium parasite, transmitted by the bite of infected mosquitoes.","cold- A common viral infection of the nose and throat."," ","flu- A common viral infection that can be deadly, especially in high-risk groups.","aids- HIV causes AIDS and interferes with the body's ability to fight infections."," ","cancer- A disease in which abnormal cells divide uncontrollably and destroy body tissue.","tb- A potentially serious infectious bacterial disease that mainly affects the lungs."," "};

	public HealthContent(string name, string description){
		base.description = description;
		base.name = name;
	}

	public HealthContent(){
		name = "Health & Disease";
		description = "Keep humans healthy by shooting dieseases";
	}
		
	public override string getTerm()
	{
		return dieases[Random.Range(0, dieases.Length)].Split('-')[0];
	}

	public string getEntireTerm(string term){
		foreach (string item in dieases) {
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

	public int getIndex(string term){
		int counter = 0;
		foreach (string item in dieases) {
			if (item.Contains (term)) {
				return counter;
			}
			counter++;
		}
		return -1;
	}
}
