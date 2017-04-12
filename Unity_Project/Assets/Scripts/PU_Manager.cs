using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Manager : MonoBehaviour {
	public GameObject[] PU_List;

	public enum PU
	{
		ThisIsJustAnEquivalentOfNullButInstanciatedAsAnEnumBecauseItIsImpossibleToCastAnEnumIntoNullAndINeedThatToDoAPrettySwitchWithoutFilthyReturnStatementsInsideTheDifferentCases,
		MSBoost,
		Heal
	};

	private int NBR_OF_PU = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public PU ChoosePU () {
		int r = Random.Range (1, NBR_OF_PU);
		PU ret = PU.ThisIsJustAnEquivalentOfNullButInstanciatedAsAnEnumBecauseItIsImpossibleToCastAnEnumIntoNullAndINeedThatToDoAPrettySwitchWithoutFilthyReturnStatementsInsideTheDifferentCases;

		switch (r) {
		case 1: 
			ret = PU.MSBoost;
			break;
		
		case 2:
			ret = PU.Heal;
			break;

		default:
			break;
		}

		return ret;
	}
}
