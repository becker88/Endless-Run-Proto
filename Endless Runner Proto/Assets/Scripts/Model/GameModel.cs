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
          
        private PlayerInfo m_playerInfo;  // Register Player Info  
        private EntityDetails m_entityDetails; // Register Entity Details

        /// <summary>
        /// Reference to the Player Info Model.
        /// </summary>
        public PlayerInfo playerInfo { get { return m_playerInfo = Assert<PlayerInfo>(m_playerInfo); } }

        /// <summary>
        /// Reference to the Entity Details Model.
        /// </summary>
        public EntityDetails entityDetails { get { return m_entityDetails = Assert<EntityDetails>(m_entityDetails); } }

        public float nextTimeToReach = 0f;

    }
}
