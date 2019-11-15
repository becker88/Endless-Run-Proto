// <copyright file="GameController.cs" company="Matrix Becker">
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
    /// Root of All Game Controller
    /// </summary>
    public class GameController : Controller<ApplicationGameManager>
    {
        private byte[] rawData  = null;
        private string cityInfo;
        private GameObject weatherPreab;

        // Use this for initialization
        void Start()
        {
            app.model.uiComp.userInput.onValueChanged.AddListener(delegate
            {
                Debug.Log(app.model.uiComp.userInput.text);
            });

           
            //StartCoroutine("FetchWeatherData", "mumbai");
        }

        
        /// <summary>
        /// On Click Function to fetch weather data
        /// </summary>
        public void WeatherGo(string cityInfo)
        {
            if ((Application.internetReachability != NetworkReachability.NotReachable))
            {
                Debug.Log(cityInfo);
                StartCoroutine("FetchWeatherData", cityInfo);
            }
        }

        /// <summary>
        /// Fetchs the master data.
        /// </summary>
        /// <returns>The master data.</returns>
        IEnumerator FetchWeatherData(string cityInfo)
        {
            app.model.uiComp.waitText.text = "Please wait...";
            Destroy(weatherPreab);
            float startTime = Time.realtimeSinceStartup;
            string apiURL = app.model.urlInfo.BaseURL + app.model.urlInfo.CurObserve + app.model.urlInfo.AccessKey + app.model.urlInfo.QueryInfo + cityInfo;

            WWWForm wwwform = new WWWForm();
            rawData = null;
            WWW www = new WWW((apiURL), rawData);
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.text);
                ParseWeatherAPI(www.text);
            }
            else
            {
                print("Failure...!!!:" + www.error);
            }
            float elapsedTime = Time.realtimeSinceStartup - startTime;
            app.model.uiComp.waitText.text = "";
            Debug.Log("Total Download Time:" + elapsedTime.ToString());

        }

        /// <summary>
        /// After getting weather Data it will be parse and Disply Properly
        /// </summary>
        public void ParseWeatherAPI(string weatherData)
        {
            WeatherSerialized weatherInfo = JsonUtility.FromJson<WeatherSerialized>(weatherData);
            string location     = weatherInfo.location.name;
            string temp         = weatherInfo.current.temperature;
            string dateTime     = weatherInfo.location.localtime;
            string humidity     = weatherInfo.current.humidity.ToString();
            string precip       = weatherInfo.current.precip.ToString();
            string windSpeed    = weatherInfo.current.wind_speed.ToString();
            string pressure     = weatherInfo.current.pressure.ToString();


           
            //Instantiate Weather Prefab
            weatherPreab = Instantiate(app.model.uiComp.forecastPrefab);
            weatherPreab.transform.SetParent(app.model.uiComp.parentObj);
            weatherPreab.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            weatherPreab.GetComponent<RectTransform>().localPosition = new Vector3(0, -106, 0);
            weatherPreab.GetComponent<PopulateData>().PopulateDataFetch(location, temp, dateTime, humidity, precip, windSpeed, pressure);

            Debug.Log(weatherInfo.location.name);
            Debug.Log(weatherInfo.location.country);
            Debug.Log(weatherInfo.current.temperature);
        }

        /// <summary>
        /// Handle notifications from the application.
        /// </summary>
        /// <param name="p_event"></param>
        /// <param name="p_target"></param>
        /// <param name="p_data"></param>
        public override void OnNotification(string p_event, Object p_target, params object[] p_data)
        {
            switch (p_event)
            {
                case GameEventNotification.SceneLoad:

                    Utils.Log("Weather Info [" + p_data[0] + "][" + p_data[1] + "] loaded");
                    app.model.uiComp.waitText.text = "Enter City and Get Weather Report";
                    break;

                case GameEventNotification.CallAPI:
                    WeatherGo(app.model.uiComp.userInput.text);
                    break;
            }
        }

    }
}
