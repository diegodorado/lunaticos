using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GuiDemo : MonoBehaviour {
	//[ColorUsageAttribute(true,true,0f,8f,0.125f,8f)]
	//private Color colorA = new Color(0.0f,0.0f,0.0f);

	//[ColorUsageAttribute(true,true,0f,8f,0.125f,8f)]
	//private Color colorB = new Color(0.0f,0.0f,0.0f);

	//[ColorUsageAttribute(true,true,0f,8f,0.125f,8f)]
	//private Color colorC = new Color(0.0f,0.0f,0.0f);

	//[ColorUsageAttribute(true,true,0f,8f,0.125f,8f)]
	//private Color colorD = new Color(0.0f,0.0f,0.0f);

	private float lightX = 40.0f;
	private float lightY = 295.0f;
	private float lightInt = 1.0f;
	private float lightBounce = 2.0f;
	private bool isEnabled = false;


	//public float colorIntensity = 1.0f;
	public Light sunlight;
	//public Material[] materials;
	//public ReflectionProbe probeComponent;
	//public Material skyProc;

	// Use this for initialization
	void Start () {
		//DynamicGI.synchronousMode = true;

		//colorA = new Color(1.7f,1.7f,1.7f);
		//recomputeLight(colorA);

		//skyProc.Tint(Color.black);
	}


	// Update is called once per frame
	void Update () {
		if (isEnabled == true){
			sunlight.transform.eulerAngles = new Vector3(lightX, lightY, 0);
			sunlight.intensity = lightInt;
			sunlight.bounceIntensity = lightBounce;

			RenderSettings.skybox.SetFloat("_Exposure", lightInt);
		}
	
		if (Input.GetMouseButtonDown(1)){
			isEnabled = !isEnabled ;

			if (isEnabled == true){
				GetComponent<FirstPersonController>().enabled = false;
			}else{
				GetComponent<FirstPersonController>().enabled = true;
			}
		}
	}



	void OnGUI () {
		// Make a background box
		if (isEnabled == true){
	
			GUI.Box(new Rect(10,10,270,300), "Loader Menu");

			// Buttons
		//	if(GUI.Button(new Rect(20,220,150,20), "Color type A")) {
		//		colorA = new Color(1.1f*colorIntensity,1.1f*colorIntensity,1.3f*colorIntensity);
		//		recomputeLight(colorA);
		//	}

		//	if(GUI.Button(new Rect(20,250,150,20), "Color type B")) {
		//		colorB = new Color(1.5f*colorIntensity,0.4458722f*colorIntensity,0.004514754f*colorIntensity);
		//		recomputeLight(colorB);		
		//	}

		//	if(GUI.Button(new Rect(20,280,150,20), "Color type C")) {
		//		colorC = new Color(0.5514706f*colorIntensity,0.7958418f*colorIntensity,1.5f*colorIntensity);
		//		recomputeLight(colorC);		
		//	}

		//	if(GUI.Button(new Rect(20,310,150,20), "Color type D")) {
		//		colorD = new Color(0.6818369f*colorIntensity,1.147059f*colorIntensity,0.05903978f*colorIntensity);
		//		recomputeLight(colorD);		
		//	}

			// Sliders
			GUI.Label (new Rect (25, 50, 300, 30),"Sunlight rotate Y");
			GUI.Label (new Rect (210, 80, 100, 30),"" + lightY);

			lightY = GUI.HorizontalSlider (new Rect (25, 80, 180, 30), lightY, 0.0f, 360.0f);


			GUI.Label (new Rect (25, 100, 300, 30),"Sunlight rotate X");
			GUI.Label (new Rect (210, 120, 100, 30),"" + lightX);
			
			lightX = GUI.HorizontalSlider (new Rect (25, 120, 180, 30), lightX, 0.0f, 80.0f);

			GUI.Label (new Rect (25, 140, 300, 30),"Sunlight intensity");
			GUI.Label (new Rect (210, 160, 100, 30),"" + lightInt);

			lightInt = GUI.HorizontalSlider (new Rect (25, 160, 180, 30), lightInt, 0.3f, 1.0f);

			GUI.Label (new Rect (25, 180, 300, 30),"Sunlight bounce");
			GUI.Label (new Rect (210, 200, 100, 30),"" + lightBounce);

			lightBounce = GUI.HorizontalSlider (new Rect (25, 200, 180, 30), lightBounce, 0.0f, 8.0f);

			//GUI.Label (new Rect (25, 165, 300, 30),"Level light intensity (need to click colors buttons)");
			//GUI.Label (new Rect (210, 185, 100, 30),"" + colorIntensity);
			
			//colorIntensity = GUI.HorizontalSlider (new Rect (25, 185, 180, 30), colorIntensity, 1.0f, 3.0f);
		}else{
			GUI.Box(new Rect(10,10,Screen.width-20,40), "Press right mouse to show the menu");
		}

	}

	/*void recomputeLight(Color color) {
		MeshRenderer[] rendered = FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];

		// Change materials colors
		foreach( Material mat in materials){
			mat.EnableKeyword ("_EMISSION");
			mat.SetColor("_EmissionColor", color);
		}

		// Change all game objects colors and GI
		foreach (MeshRenderer rend in rendered) {
			DynamicGI.SetEmissive(rend,color);
			DynamicGI.UpdateMaterials(rend);
		}

		// GI update
		DynamicGI.UpdateEnvironment();

		// Update of reflexion probe
		probeComponent.RenderProbe();

	}*/

}

