using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlogSampleProject.Scenes.ProceduralAnimation {
	public class Sample4 : MonoBehaviour {

		//private Transform square = null;
		private Transform[] squares = null;

		private float playbackTime = 0.0f;
		public float playbackDuration = 4f;

		private void Awake() {
			squares = new Transform[10];

			Transform sourceSquare = transform.Find("Square");
			squares[0] = sourceSquare;

			for (int i = 1; i < squares.Length; i++) {
				Transform newSquare = Instantiate(sourceSquare.gameObject).transform;
				squares[i] = newSquare;
				newSquare.SetParent(transform);
				newSquare.localPosition = sourceSquare.localPosition + new Vector3(0.0f, i * -155.0f, 0.0f);
			}
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
			float sliceLength = 1.0f / (float)squares.Length;

			for (int i = 0; i < squares.Length; i++) {
				// Get the 0 - 1 value in each "slice" of time. 
				// We're taking 10 slices of time in this situation
				float aSlice = GetNormalizedTimeInTimeSlice(a, i * sliceLength, sliceLength);
				aSlice = EaseInOutCirc(aSlice);

				Transform square = squares[i];
				square.localScale = Vector3.one * 1.5f * aSlice;
			}
		}

		public static float GetNormalizedTimeInTimeSlice(float currentTime, float timeSliceStart, float timeSliceLength) {
			if (currentTime <= 0)
				return 0.0f;
			if (timeSliceLength <= 0)
				return 1.0f;

			if (timeSliceStart <= 0)
				timeSliceStart = 0.0f;

			float timeSliceCurrentTime = currentTime - timeSliceStart;
			if (timeSliceCurrentTime <= 0)
				return 0.0f;
			if (timeSliceCurrentTime >= timeSliceLength)
				return 1.0f;

			return timeSliceCurrentTime / timeSliceLength;
		}

		public static float EaseInOutCirc(float a) {
			a = a * 2.0f;
			if (a < 1.0f)
				return -0.5f * (UnityEngine.Mathf.Sqrt(1.0f - a * a) - 1.0f );
			else {
				a = a - 2.0f;
				return 0.5f * (UnityEngine.Mathf.Sqrt(1.0f - a * a) + 1.0f);
			}
		}

	}
}