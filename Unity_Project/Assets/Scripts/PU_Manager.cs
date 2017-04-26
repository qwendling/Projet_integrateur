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

	private int NBR_OF_PU;

	// Use this for initialization
	void Start () {
		NBR_OF_PU = PU_List.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public PU ChoosePU () {
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
