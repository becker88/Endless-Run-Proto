// <copyright file="ApplicationGameManager.cs" company="Zabingo Softwares">
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

/// <summary>
/// Application game manager.
/// </summary>
public class ApplicationGameManager : BaseApplication<GameModel,GameView,GameController> {

        //Call before Start
        void Awake()
        {
            Utils.IsDebugEnable = true;
            view.Initialize();
            controller.Initialize();
        }

    }
}
