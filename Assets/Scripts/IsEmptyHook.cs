using UnityEngine;
using System.Collections;

public class IsEmptyHook : Hook {
	public string input{ get; private set;}
	//public char[] isEmpty{ get; private set;}

	public IsEmptyHook(string inp){
		input = inp;
		//isEmpty = coms;
		type = HookType.IsEmpty;
	}

	public override string ToString ()
	{
		return string.Format ("[IsEmptyHook: input={0}]", input);
	}
}
