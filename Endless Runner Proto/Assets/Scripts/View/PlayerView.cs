// <copyright file="PlayerView.cs" company="Zabingo Softwares">
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
	
public class PlayerView : View<ApplicationGameManager> {


        private float amountTofMove;
        private Rigidbody rBody;
        private bool isDead;
        /// <summary>
        /// Jump this instance.
        /// </summary>
        public void Jump()
		{
            rBody.AddForce(new Vector3(0, 30, 0));
        }      

        /// <summary>
        /// For Run
        /// </summary>
        public void SetupDirection()
        {
            if (!isDead)
            {
                if (app.model.playerInfo.PlayerDirection == Vector3.forward)
                {
                    app.model.playerInfo.PlayerDirection = Vector3.left;
                }
                else
                {
                    app.model.playerInfo.PlayerDirection = Vector3.forward;
                }
            }          

        }

        /// <summary>
        /// For Run
        /// </summary>
        public void Run()
        {
            amountTofMove = app.model.playerInfo.MovementSpeed * Time.deltaTime;
            transform.Translate(app.model.playerInfo.PlayerDirection * amountTofMove);
        }

		/// <summary>
		/// Initialize all Components.
		/// </summary>
		public void Initialize()
		{
            isDead = false;
            rBody = gameObject.GetComponent<Rigidbody>();
            app.model.playerInfo.PlayerDirection = Vector3.zero;
            Utils.Log("Initialization of Player");
		}

        /// <summary>
        /// Raises the trigger enter2 d event.
        /// </summary>
        /// <param name="col">Col.</param> 
        void OnTriggerEnter(Collider other)
		{            
            if (other.tag.Equals("Picker"))
            {
                Notify(GameEventNotification.PickerOff,other.gameObject);
                //other.gameObject.SetActive(false);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.tag.Equals("Tile"))
            {
                RaycastHit hit;

                Ray downRay = new Ray(transform.position, -Vector3.up);
                if(!Physics.Raycast(downRay, out hit))
                {
                    Notify(GameEventNotification.StopCameraFollow);
                    isDead = true;
                }
            }
 
        }
    }
}
