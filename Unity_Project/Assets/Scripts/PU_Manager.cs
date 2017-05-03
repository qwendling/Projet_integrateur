using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PU_Manager : NetworkBehaviour {
	public GameObject[] PU_List;

	public enum PU
	{
		ThisIsJustAnEquivalentOfNullButInstanciatedAsAnEnumBecauseItIsImpossibleToCastAnEnumIntoNullAndINeedThatToDoAPrettySwitchWithoutFilthyReturnStatementsInsideTheDifferentCases,
		MSBoost,
		Heal
	};

	private int NBR_OF_PU;

	// Use this for initialization
	void Start () {
		if (!isServer)
			return;
		
		NBR_OF_PU = PU_List.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public PU ChoosePU () {
		if (!isServer)
			return PU.ThisIsJustAnEquivalentOfNullButInstanciatedAsAnEnumBecauseItIsImpossibleToCastAnEnumIntoNullAndINeedThatToDoAPrettySwitchWithoutFilthyReturnStatementsInsideTheDifferentCases;
		
		int r = Random.Range (0, NBR_OF_PU);
		PU ret = PU.ThisIsJustAnEquivalentOfNullButInstanciatedAsAnEnumBecauseItIsImpossibleToCastAnEnumIntoNullAndINeedThatToDoAPrettySwitchWithoutFilthyReturnStatementsInsideTheDifferentCases;

		switch (r) {
		case 0: 
			ret = PU.MSBoost;
			break;
		
		case 1:
			ret = PU.Heal;
			break;

		default:
			break;
		}

		return ret;
	}
}
