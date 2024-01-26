using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    public GameObject InfoButton;
    public GameObject Description;

	public void Next ()
    {
        Description.SetActive(true);
	}
	
}
