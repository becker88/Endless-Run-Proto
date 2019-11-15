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
using UnityEngine.UI;

using Becker.MVC;

namespace WheelOfFortune
{
    public class PopulateData : View<ApplicationGameManager> {

        public Text location;
        public Text temperature;
        public Text time;
        public Text date;
        public Text humidity;
        public Text precipetation;
        public Text windSpeed;
        public Text pressure;

        /// <summary>
        /// Populating Function
        /// </summary>
        /// <param name="_loc"></param>
        /// <param name="_temp"></param>
        /// <param name="_localTime"></param>
        /// <param name="_humidity"></param>
        /// <param name="_precip"></param>
        /// <param name="_windSpeed"></param>
        /// <param name="_pressure"></param>
        public void PopulateDataFetch(string _loc, string _temp, string _localTime, string _humidity, string _precip, string _windSpeed, string _pressure)
        {
            location.text       = _loc;
            temperature.text    = _temp;
            date.text           = _localTime.Substring(0, 11);
            time.text           = _localTime.Substring(11, 5);
            humidity.text       = _humidity;
            precipetation.text  = _precip;
            windSpeed.text      = _windSpeed;
            pressure.text       = _pressure;
        }
        
    }
}
