using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour 
{
	[Space(10)]
	// all light effects and spotlight
	[SerializeField()] GameObject Lights;
	// audio of the switcher
	[SerializeField()] AudioSource switchSound; 
	// dust particles
	[SerializeField()] ParticleSystem dustParticles; 



	public Text flashlightText;
	private Light spotlight;
	private Material ambientLightMaterial;
	private Color ambientMatColor;
	private bool isEnabled = false;


	// Use this for initialization
	void Start () 
	{
		// cache components
		flashlightText.text = "Press 'F' to ON / OFF Flashlight";
		spotlight = Lights.transform.Find ("Spotlight").GetComponent<Light> ();
		ambientLightMaterial = Lights.transform.Find ("ambient").GetComponent<Renderer> ().material;
		ambientMatColor = ambientLightMaterial.GetColor ("_TintColor");
	}

	/// <summary>
	/// changes the intensivity of lights from 0 to 100.
	/// call this from other scripts.
	/// </summary>
	public void Change_Intensivity(float percentage)
	{
		percentage = Mathf.Clamp (percentage, 0, 100);


		spotlight.intensity = (8 * percentage) / 100;

		ambientLightMaterial.SetColor ("_TintColor", new Color(ambientMatColor.r , ambientMatColor.g , ambientMatColor.b , percentage/2000)); 
	}

	/// <summary>
	/// enables the particles.
	/// </summary>
	public void Enable_Particles(bool value)
	{
		if(dustParticles != null)
		{
			if(value)
			{
				dustParticles.gameObject.SetActive(true);
				dustParticles.Play();
			}
			else
			{
				dustParticles.Stop();
				dustParticles.gameObject.SetActive(false);
			}
		}
	}

	/// <summary>
	/// switch current state  ON / OFF.
	/// call this from other scripts.
	/// </summary>
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			flashlightText.text = null;
			isEnabled = !isEnabled;

			Lights.SetActive(isEnabled);

			if (switchSound != null)
			{
				switchSound.Play();
			}
		}
	}
}