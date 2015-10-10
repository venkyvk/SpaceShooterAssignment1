/* Author: Venkatesh Managoli*/
/* File: DestroyByBoundary.cs */
/* Creation Date: Sept 30, 2015 */
/* Description: This script controls destruction of game object that exit game boundary*/

using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);
	}
}