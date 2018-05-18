// <copyright file="Singleton.cs" company="Zabingo Softwares">
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
namespace EndlessRunner{


    /// <summary>
    /// A generic singleton class for creating singleton
    /// </summary>
    /// <typeparam name="T">The type of MonoBehaviour the singleton needs to be</typeparam>
    public abstract class Singleton<T> : ApplicationGameManager where T : ApplicationGameManager
    {
        /// <summary>
        /// The instance of the singleton
        /// </summary>
        private static T instance;

        /// <summary>
        /// Property for accessing the singleton
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null) //If the instance is null then we need to find it
                {
                    //Finds the object
                    instance = FindObjectOfType<T>();
                }

                //Returns the instance
                return instance;
            }

        }
    }
}
