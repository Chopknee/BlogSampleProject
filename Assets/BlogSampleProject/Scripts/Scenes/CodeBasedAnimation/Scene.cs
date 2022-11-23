/**
 * A sample scene that demonstrates procedural animation.
 * This script sets up the sample objects.
 *
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlogSampleProject.Scenes.CodeBasedAnimation {
	public class Scene : MonoBehaviour {

		private void Awake() {
			transform.Find("Sample1").gameObject.AddComponent<Sample1>();
			transform.Find("Sample2").gameObject.AddComponent<Sample2>();
			transform.Find("Sample3").gameObject.AddComponent<Sample3>();
			transform.Find("Sample4").gameObject.AddComponent<Sample4>();
		}

	}
}