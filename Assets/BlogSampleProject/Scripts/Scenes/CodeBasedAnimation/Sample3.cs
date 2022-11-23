using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlogSampleProject.Scenes.CodeBasedAnimation {
	public class Sample3 : MonoBehaviour {

		private Transform square = null;

		private float playbackTime = 0.0f;
		public float playbackDuration = 2f;

		private void Awake() {
			square = transform.Find("Square");
		}

		private void Update() {
			playbackTime += Time.deltaTime;

			// Eliminating 0 or negative values.
			// The following turns our accumulated delta time into a 0 to 1 value
			float percent = 0.0f;
			if (Mathf.Abs(playbackTime) > 0.0f)
				percent = playbackTime / Mathf.Abs(playbackDuration);

			float a = percent - Mathf.Floor(percent);

			// Using the calculated 0 - 1 value, pass it to the render function
			Render(a);
		}

		private void Render(float a) {
			a = EaseOutBounce(a); // Bounce function
			square.localScale = Vector3.one * 2.0f * a;
		}

		public static float EaseOutBounce(float a) {
			if (a < ( 1.0f / 2.75f )) {
				return 7.5625f * a * a;
			} else if (a < ( 2.0f / 2.75f )) {
				a -= ( 1.5f / 2.75f );
				return 7.5625f * a * a + 0.75f;
			} else if (a < ( 2.5f / 2.75f )) {
				a -= ( 2.25f / 2.75f );
				return 7.5625f * a * a + 0.9375f;
			} else {
				a -= ( 2.65f / 2.75f );
				return 7.5625f * a * a + 0.984375f;
			}
		}

	}
}