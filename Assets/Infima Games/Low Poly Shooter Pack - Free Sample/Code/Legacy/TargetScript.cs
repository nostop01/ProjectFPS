using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	float randomTime;
	public bool routineStarted = false;

	float DestroyTIme = 0.5f;

	//Used to check if the target has been hit
	public bool isHit = false;

	public bool isDown = false;

	public bool DestroyMode = false;

	[Header("Customizable Options")]
	//Minimum time before the target goes back up
	public float minTime;
	//Maximum time before the target goes back up
	public float maxTime;

	[Header("Audio")]
	public AudioClip upSound;
	public AudioClip downSound;

	[Header("Animations")]
	public AnimationClip targetUp;
	public AnimationClip targetDown;

	public AudioSource audioSource;

	[SerializeField]
	private GameObject target;
	
	private void Update () {
		
		//Generate random time based on min and max time values
		randomTime = Random.Range (minTime, maxTime);

		//If the target is hit
		if (isHit == true) 
		{
			if (routineStarted == false) 
			{
                //Animate the target "down"
                gameObject.GetComponent<Animation>().clip = targetDown;
				gameObject.GetComponent<Animation>().Play();

				//Set the downSound as current sound, and play it
				audioSource.GetComponent<AudioSource>().clip = downSound;
				audioSource.Play();

				StartCoroutine(Delay());

                //Start the timer
                StartCoroutine(DelayTimer());
				routineStarted = true;
			} 

			else if(DestroyMode == false)
			{
                //Animate the target "down"
                gameObject.GetComponent<Animation>().clip = targetDown;
                gameObject.GetComponent<Animation>().Play();

                //Set the downSound as current sound, and play it
                audioSource.GetComponent<AudioSource>().clip = downSound;
                audioSource.Play();

                StartCoroutine(DestroyTImer());
				DestroyMode = true;
			}
		}
	}

	//Time before the target pops back up
	private IEnumerator DelayTimer () {
		//Wait for random amount of time
		yield return new WaitForSeconds(randomTime);
		//Animate the target "up" 
		gameObject.GetComponent<Animation>().clip = targetUp;
		gameObject.GetComponent<Animation>().Play();

		//Set the upSound as current sound, and play it
		audioSource.GetComponent<AudioSource>().clip = upSound;
		audioSource.Play();

		//Target is no longer hit
		isHit = false;
		routineStarted = false;
	}

	private IEnumerator DestroyTImer()
	{
		yield return new WaitForSeconds(DestroyTIme);

		Destroy(target);
	}

	private IEnumerator Delay()
	{
		isDown = true;

		yield return new WaitForSeconds(0.5f);

		isDown = false;
	}
}