// <copyright file="CombatText.cs" company="Matrix Becker">
// Copyright (C) 2017 Matrix Becker.All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Becker.MVC;


namespace EndlessRunner{
	
public class CombatText : View<ApplicationGameManager> {

		private float speed;
		private Vector3 direction;
		private float fadeTime;

		public AnimationClip critAnim;
		private bool isCrit;

		// Update is called once per frame
		void Update () {
			
			if (!isCrit) {
				
				float translation = speed * Time.deltaTime;

				transform.Translate (direction * translation);
			}
		}

		/// <summary>
		/// Initialize the specified Speed, Direction and FadeTime.
		/// </summary>
		/// <param name="Speed">Speed.</param>
		/// <param name="Direction">Direction.</param>
		/// <param name="FadeTime">Fade time.</param>
		public void Initialize( float Speed, Vector3 Direction, float FadeTime, bool IsCrit)
		{
			this.speed = Speed;
			this.direction = Direction;
			this.fadeTime = FadeTime;
			this.isCrit = IsCrit;

			if (isCrit) {
			
				GetComponent<Animator> ().SetTrigger ("Critical");

				StartCoroutine (Critical());
			} 
			else {
				
				StartCoroutine (FadeOut());	 
			}

		}

		/// <summary>
		/// Waitfor Play Critical Animation then FadeOut.
		/// </summary>
		private IEnumerator Critical()
		{
			yield return new WaitForSeconds (critAnim.length);
			isCrit = false;
			StartCoroutine (FadeOut());	
		}

		/// <summary>
		/// Fades out the Text Gameobject.
		/// </summary>
		/// <returns>The out.</returns>
		private IEnumerator FadeOut()
		{
			float startAlfa = GetComponent<Text> ().color.a;

			float rate = 1.0f / fadeTime;
			float progress = 0.0f;

			while (progress < 1.0) {
				Color tmpColor = GetComponent<Text> ().color;

				GetComponent<Text>().color = new Color (tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlfa, 0, progress));
				progress += rate * Time.deltaTime;
				yield return null;
			}

			Destroy (gameObject);
		}
 	 }
}
