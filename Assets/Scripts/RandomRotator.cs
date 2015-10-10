/* Author: Venkatesh Managoli*/
/* File: RandomRotator.cs */
/* Creation Date: Sept 30, 2015 */
/* Description: This script controls the asteroid's tumbling movement */

using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float tumble;
	
	void Start ()
	{
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
}