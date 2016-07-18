using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameAnimation : MonoBehaviour {

	//public static GameAnimation;

	public static void GraphicFadeIn (Graphic img) {
		print("got called");
//		StartCoroutine(GraphicInFade(img));

	}
		
	public IEnumerator GraphicInFade (Graphic img) {
		float currentAlpha = 0.0f;

		//yield return new WaitForSeconds(0.5f);

		while (currentAlpha < 1.0f) {
			currentAlpha += 0.1f;
			img.color = new Color(img.color.r, img.color.g, img.color.b, currentAlpha);
			yield return new WaitForSeconds(0.05f);
		}
	}
}