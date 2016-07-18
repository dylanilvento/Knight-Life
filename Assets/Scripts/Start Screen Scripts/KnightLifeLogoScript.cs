using UnityEngine;
using System.Collections;

public class KnightLifeLogoScript : MonoBehaviour {
	Animator anim;
	Renderer rend;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rend = GetComponent<Renderer>();
		//StartCoroutine("AnimateFlag");
		//print(MyTestDLL.DLLClass.GetRandom());
		//print(Timeline.DayOne.GetRandom());
		//Timeline.GetTest();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartAnimation () {
		StartCoroutine("AnimateFlag");
	}

	public void AnimateTailFlap () {
		anim.SetTrigger("TailFlap");
	}

	IEnumerator AnimateFlag () {
		int choice;
		
		yield return new WaitForSeconds(Random.Range(2f, 5f));
		anim.SetTrigger("EndTailFlap");
		
		while (true) {
		//	yield return new WaitForSeconds(Random.Range(1f, 10f));
			yield return new WaitForSeconds(Random.Range(1f, 3f));
			choice = Mathf.FloorToInt(Random.Range(1f, 2.9f));
			//print(choice);

			if (choice == 1) {
				anim.SetTrigger("TailFlap");
				yield return new WaitForSeconds(Random.Range(0.5f, 3f));
				anim.SetTrigger("EndTailFlap");
			}

			else if (choice == 2) {
				anim.SetTrigger("Ruffle");
				yield return new WaitForSeconds(Random.Range(1.5f, 5f));

			}
		}
	}

	public void FadeOut () {
		StartCoroutine("LogoFadeOut");
	}

	IEnumerator LogoFadeOut () {
		float currentAlpha = 1.0f;

		while (currentAlpha > 0f) {
			//print("Logo alpha is " + currentAlpha);
			currentAlpha -= 0.1f;
			Color currentColor = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, currentAlpha);
			rend.material.color = currentColor;
			//print("Logo color is " + rend.material.color);
			yield return new WaitForSeconds(0.05f);
		}
		//print("Logo alpha is " + currentAlpha);
		//print("Logo color is " + rend.material.color);
	}

	public void FadeIn () {
		StartCoroutine("LogoFadeIn");
	}

	IEnumerator LogoFadeIn () {
		float currentAlpha = 0.0f;

		yield return new WaitForSeconds(0.5f);

		while (currentAlpha < 1.0f) {
			currentAlpha += 0.1f;
			//print("Logo alpha is " + currentAlpha);
			Color currentColor = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, currentAlpha);
			rend.material.color = currentColor;
			yield return new WaitForSeconds(0.05f);
		}

		//print("Logo alpha is " + currentAlpha);
		//print("Logo color is " + rend.material.color);
	}
}