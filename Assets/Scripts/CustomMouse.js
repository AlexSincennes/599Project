var texture : Texture2D;


function Awake() {
	Cursor.visible = false;
}
function Start () {

}

function Update () {
transform.position = Vector3(Input.mousePosition.x/Screen.width,Input.mousePosition.y/Screen.height,0f);
}

function OnGUI(){
	GetComponent.<GUITexture>().texture =texture;
}