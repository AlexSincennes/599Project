#pragma strict

function Start () {
	transform.position.z = -15;
	transform.position.y = 4.52;
	transform.position.x = 114;
}
 var target : Transform;
 var distance : float;
 function Update(){
 	if(target.position.x>=114)
 	{
     transform.position.z = target.position.z - distance;
     transform.position.y = target.position.y;
     transform.position.x = target.position.x+2;
     }
 
 }