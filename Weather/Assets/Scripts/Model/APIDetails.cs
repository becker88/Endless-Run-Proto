// <copyright file="GameEventNotification.cs" company="Matrix Becker">
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
    public class APIDetails : Model<ApplicationGameManager>
    {
        private string _baseURL = "http://api.weatherstack.com/";
        private string _curObserve = "current?";
        private string _accessKey = "access_key=fb5b798ccedcb92923e9662b89363042&";
        private string _queryInfo = "query=";

        /// <summary>
        /// Get Base URL
        /// </summary>
        public string BaseURL { get { return _baseURL; } }

        /// <summary>
        /// Get Current Weather Data
        /// </summary>
        public string CurObserve { get { return _curObserve; } }

        /// <summary>
        /// Attach AccessKey
        /// </summary>
        public string AccessKey { get { return _accessKey; } }

        /// <summary>
        /// Weather queryInfo
        /// </summary>
        public string QueryInfo { get { return _queryInfo; } }

        
    }
}
