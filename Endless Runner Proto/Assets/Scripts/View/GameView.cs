// <copyright file="GameView.cs" company="Zabingo Softwares">
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
	
public class GameView : View<ApplicationGameManager> {


        private PlayerView m_player; // Register Player View
        private UIComponent m_uiComp;// Register UI(Canvas) Component

        /// <summary>
        /// Reference to the Player View.
        /// </summary>
        public PlayerView player { get { return m_player = Assert<PlayerView>(m_player); } }

        /// <summary>
        /// Reference to the UIComponent View.
        /// </summary>
        public UIComponent uiView { get { return m_uiComp = Assert<UIComponent>(m_uiComp); } }

        /// <summary>
        /// Initialize all Components.
        /// </summary>
        public void Initialize()
        {
            player.Initialize();
        }
     }
}
