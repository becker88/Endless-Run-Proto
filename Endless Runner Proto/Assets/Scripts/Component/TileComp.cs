// <copyright file="TileScript.cs" company="Matrix Becker">
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Becker.MVC;

namespace EndlessRunner{

    public class TileComp : View<ApplicationGameManager>
    {

        void OnTriggerExit(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                //Utils.Log("Spwan Tiles");
                Notify(GameEventNotification.SpawnPath);
                Notify(GameEventNotification.PathFallDown, this.gameObject);
            }            
        }

        
    }
}
