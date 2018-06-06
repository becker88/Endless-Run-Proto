// <copyright file="GameModel.cs" company="Zabingo Softwares">
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
using System.Collections.Generic;
using Becker.MVC;

namespace EndlessRunner{

    public class GameModel : Model<ApplicationGameManager>
    {
        public float nextTimeToReach = 0f;
        private int currentScore = 0;
        private int highScore = 0;
        private int specialScore = 5;
        private bool isGameOver = false;
        // Register Player Info    
        private PlayerInfo m_playerInfo;
        // Register Entity Details
        private EntityDetails m_entityDetails;
        // Register UI(Canvas) Component
        private UIComponent m_uiComp;
        // Register CombatTextInfo
        private CombatTextInfo m_combatInfo;

        /// <summary>
        /// Reference to the Player Info Model.
        /// </summary>
        public PlayerInfo playerInfo { get { return m_playerInfo = Assert<PlayerInfo>(m_playerInfo); } }

        /// <summary>
        /// Reference to the Entity Details Model.
        /// </summary>
        public EntityDetails entityDetails { get { return m_entityDetails = Assert<EntityDetails>(m_entityDetails); } }

        /// <summary>
        /// Reference to the UIComponent View.
        /// </summary>
        public UIComponent uiComp { get { return m_uiComp = Assert<UIComponent>(m_uiComp); } }

        /// <summary>
        /// Reference to the Combat Info.
        /// </summary>
        public CombatTextInfo combatInfo { get { return m_combatInfo = Assert<CombatTextInfo>(m_combatInfo); } }

       

        /// <summary>
        /// Current Score
        /// </summary>
        public int CurrentScore { get { return currentScore; }set { currentScore = value; } }

        /// <summary>
        /// High Score
        /// </summary>
        public int HighScore {  get { return highScore; } set { highScore = value; } }

        /// <summary>
        /// Special Score
        /// </summary>
        public int SpecialScore { get { return specialScore; } set { specialScore = value;} }

        /// <summary>
        /// Game Over or Not Checking
        /// </summary>
        public bool IsGameOver  {  get  {   return isGameOver;  } set{  isGameOver = value;} }
    }
}
