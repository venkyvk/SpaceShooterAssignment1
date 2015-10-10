/* Author: Venkatesh Managoli*/
/* File: Mover.cs */
/* Creation Date: Sept 30, 2015 */
/* Description: This script controls the movement of hazards */

using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
