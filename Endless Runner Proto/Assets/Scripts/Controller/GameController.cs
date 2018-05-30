// <copyright file="GameController.cs" company="Zabingo Softwares">
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
using UnityEngine.SceneManagement;
using Becker.MVC;

namespace EndlessRunner{
	
public class GameController : Controller<ApplicationGameManager>{
       

        /// <summary>
		/// Initialize all Components.
		/// </summary>
		public void Initialize()
        {
            app.view.uiView.uiTitle.text = "ZIG ZAG";
            Notify(GameEventNotification.FindPlayer);            
            Notify(GameEventNotification.RandPathGen);
        }

        /// <summary>
        /// Call Once Per frame.
        /// </summary>
        void Update()
		{
            if (Input.GetMouseButtonDown(0))
            {
                app.view.player.SetupDirection();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                app.view.player.Jump();
            }

            app.view.player.Run();           
        }

       
        /// <summary>
        /// After Game Over Reload the Game
        /// </summary>
        private void ReloadGame()
        {            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                case GameEventNotification.SceneLoad:
                    Utils.Log("Endless Run [" + p_data[0] + "][" + p_data[1] + "] loaded");
                    Initialize();
                    break;

                case GameEventNotification.ScoreUpdate:

                    Utils.Log("Score Update");
			        break;

			    case GameEventNotification.GameOver:

				    Utils.Log("Oops...!!Game Over...!!..Ball Hit in the Wrong Color");
                    break;
            }	
		}

 	}
}
