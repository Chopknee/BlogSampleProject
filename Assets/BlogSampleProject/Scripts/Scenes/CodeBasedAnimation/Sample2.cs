using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlogSampleProject.Scenes.CodeBasedAnimation {
	public class Sample2 : MonoBehaviour {

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
			a = a * a; // A simple exponential function
			square.localScale = Vector3.one * 2.0f * a;
		}

	}
}