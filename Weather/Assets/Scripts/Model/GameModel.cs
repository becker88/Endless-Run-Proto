// <copyright file="GameModel.cs" company="Matrix Becker">
// Copyright (C) 2019 Matrix Becker. All Rights Reserved.
//
//@ Author: Mr. Saikat Patra
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

namespace WheelOfFortune
{
    /// <summary>
    /// Root of All Game Model
    /// </summary>
    public class GameModel : Model<ApplicationGameManager>
    {
        private string _cityInfo;

        private APIDetails m_urlInfo; // Register API Info
        private UIComp m_uiComp;
        

        /// <summary>
        /// Reference to the APIDetails Info Model.
        /// </summary>
        public APIDetails urlInfo { get { return m_urlInfo = Assert<APIDetails>(m_urlInfo); } }

        /// <summary>
        /// Reference to the UI Component.
        /// </summary>
        public UIComp uiComp { get { return m_uiComp = Assert<UIComp>(m_uiComp); } }

        /// <summary>
        /// Get Base URL
        /// </summary>
        public string CityInfo { get { return _cityInfo; } }

    }
}
