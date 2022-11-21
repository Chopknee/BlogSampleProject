/**
 * A sample scene that demonstrates procedural animation.
 * This script sets up the sample objects.
 *
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlogSampleProject.Scenes.ProceduralAnimation {
	public class Scene : MonoBehaviour {

		private void Awake() {
			transform.Find("Sample1").gameObject.AddComponent<Sample1>();
		}

	}
}