// <copyright file="PlayerInfo.cs" company="Zabingo Softwares">
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Becker.MVC;

namespace EndlessRunner{

    /// <summary>
    /// Player Profile Details
    /// </summary>
    public class PlayerInfo : Model<ApplicationGameManager>
    {

        private float movementSpeed = 7.0f; // Jump Force of Player
        private int playerHeath = 5; //Player Health Details
        private int score;

        private Vector3 direction; //Set the Player Movement Direction

        /// <summary>
		/// Gets the jump force.
		/// </summary>
		/// <value>The jump force.</value>
		public float MovementSpeed { get { return movementSpeed; } }

        /// <summary>
        /// Gets the Player Health
        /// </summary>
        public int PlayerHealth { get { return playerHeath; } }

        /// <summary>
        /// Get and Set Score of Player
        /// </summary>
        public int Score { get { return score; } set { score = value; } }

        /// <summary>
        /// Fetch and Set the Player Movement Direction
        /// </summary>
        public Vector3 PlayerDirection { get { return direction; } set { direction = value; } }

    }
}