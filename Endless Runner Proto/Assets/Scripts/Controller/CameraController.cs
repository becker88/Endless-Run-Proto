// <copyright file="CameraController.cs" company="Zabingo Softwares">
// Copyright (C) 2017 Zabingo Softwares.All Rights Reserved.
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
using Becker.MVC;

namespace EndlessRunner{
	
public class CameraController : Controller<ApplicationGameManager> {
       

        private Transform player; //Track the Target i.e Player
        private Vector3 offset; //Private variable to store the offset distance between the player and camera

        // Use this for initialization
        private void Initialize () {

            Utils.Log("Initialization of Camera");
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            //Calculate and store the offset value by getting the distance between the player's position and camera's position.
            offset = transform.position - player.transform.position;
        }

		
        // LateUpdate is called after Update each frame
        void LateUpdate()
        {
            if (player == null)
            {
                FindPlayer();
                return;
            }
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = player.transform.position + offset;
        }

        /// <summary>
        /// Handle notifications from the application.
        /// </summary>
        /// <param name="p_event"></param>
        /// <param name="p_target"></param>
        /// <param name="p_data"></param>
        public override void OnNotification(string p_event, Object p_target, params object[] p_data)
        {
            switch (p_event)
            {

                case GameEventNotification.FindPlayer:

                    Utils.Log("Find Player");
                    Initialize();
                    break;               
            }
        }
        /// <summary>
        /// Finds the player.
        /// </summary>
        private void FindPlayer()
		{
			if (app.model.nextTimeToReach <= Time.time) {
				GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");
				if (searchResult != null)
                    player = searchResult.transform;
					app.model.nextTimeToReach = Time.time + 0.5f;
			}
		}
  }
}
