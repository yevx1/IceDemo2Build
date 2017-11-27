#pragma strict

var speed : float = 0.2;

function Update () 
{
	transform.Rotate(Vector3(0, Time.deltaTime * speed, 0));
}