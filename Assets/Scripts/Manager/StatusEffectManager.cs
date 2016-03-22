using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StatusEffectManager : MonoBehaviour
{
	public GameObject guiContainer;
	public GameObject glyphBase;
	private HashSet<BuffableProperty> effects = new HashSet<BuffableProperty> ();
	public Observer buffObserver;

	void Start ()
	{
		buffObserver = new Observer (BuffChanged);
	}

	void BuffChanged (BuffableProperty value)
	{
		effects.Add (value);
		RedrawGlyphs ();
	}

	void FixedUpdate ()
	{
		Text[] texts = guiContainer.GetComponentsInChildren<Text> ();
//		if (effects.RemoveAll (effect => effect.Remaining () < 0) > 0) {
//			RedrawGlyphs ();
//		}

		int i = 0;
		foreach (BuffableProperty property in effects) {
			foreach (IBuff2 effect in property.Effects) {
				if (effect.DurationType.Equals (BuffDuration.Limited)) {
					texts [i].text = effect.Remaining.ToString ("F1");
				} else {
					texts [i].text = "";
				}
				i++;
			}
		}
	}

	void RedrawGlyphs ()
	{
		foreach (Transform child in guiContainer.transform) {
			Destroy (child.gameObject);
		}

		int i = 0;
		foreach (BuffableProperty property in effects) {
			foreach (IBuff2 effect in property.Effects) {
				GameObject glyph = Instantiate (glyphBase);
				glyph.transform.SetParent (guiContainer.transform, false);
				RectTransform rt = glyph.GetComponent<RectTransform> ();
				rt.anchoredPosition = new Vector2 (-19 - i++ * 34, rt.anchoredPosition.y);

				Sprite buffSprite = Resources.Load <Sprite> (effect.GlyphName);
				glyph.GetComponent<Image> ().sprite = buffSprite;
			}
		}
	}
}
