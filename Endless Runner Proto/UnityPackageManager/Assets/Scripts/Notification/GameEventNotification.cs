// <copyright file="GameEventNotification.cs" company="Zabingo Softwares">
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
	
public class GameEventNotification {

        public const string GameStart     	= "game.start";
		public const string GameOver  		= "game.over";
		public const string SceneLoad     	= "scene.load";
		public const string ScoreUpdate     = "score.update";
        public const string RandPathGen     = "rand.path.gen";
        public const string SpawnPath       = "spwan.path";
        public const string RandomEnemy     = "generate.random.enemy";
        public const string PathFallDown    = "fall.down";
        public const string FindPlayer      = "find.player";
        public const string PickerOff       = "off.picker";
        public const string StopCameraFollow = "stop.camera.follow";
    }
}
