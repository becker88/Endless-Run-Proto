// <copyright file="TileManager.cs" company="Zabingo Softwares">
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

    public class TileManager : Controller<ApplicationGameManager>
    {

        private Stack<GameObject> leftTile = new Stack<GameObject>();
        private Stack<GameObject> topTile = new Stack<GameObject>();

        public void GeneratePath()
        {
            CreateTiles(50);

            for (int i = 0; i < 20; i++)
            {
                SpawnTile();
            }            
        }

        /// <summary>
        /// Creation of Tile with Reuability
        /// </summary>
        /// <param name="amount"></param>
        public void CreateTiles(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                
                leftTile.Push(Instantiate(app.model.entityDetails.tileSet[0]));
                topTile.Push(Instantiate(app.model.entityDetails.tileSet[1]));

                leftTile.Peek().name    = "LeftTile";
                topTile.Peek().name     = "TopTile";

                leftTile.Peek().transform.SetParent(app.model.entityDetails.tileParent);
                topTile.Peek().transform.SetParent(app.model.entityDetails.tileParent);

                topTile.Peek().SetActive(false);
                leftTile.Peek().SetActive(false);
            }
        }
        /// <summary>
        /// Slowly Fall Down
        /// </summary>
        /// <returns></returns>
        IEnumerator FallDown(GameObject pathPrefab)
        {
            yield return new WaitForSeconds(1.5f);
            pathPrefab.GetComponent<Rigidbody>().isKinematic = false;

            yield return new WaitForSeconds(2.0f);

            switch (pathPrefab.name)
            {
                case "LeftTile":
                    leftTile.Push(pathPrefab);
                    pathPrefab.GetComponent<Rigidbody>().isKinematic = true;
                    pathPrefab.SetActive(false);
                    break;

                case "TopTile":
                    topTile.Push(pathPrefab);
                    pathPrefab.GetComponent<Rigidbody>().isKinematic = true;
                    pathPrefab.SetActive(false);
                    break;
            }
        }

        /// <summary>
        /// Spawn The Tile for Path generation
        /// </summary>
        private void SpawnTile()
        {
            if(leftTile.Count == 0 || topTile.Count == 0)
            {
                CreateTiles(10);
            }

            int randomIndex = Random.Range(0, 2);
            if(randomIndex == 0)
            {
                GameObject tmp = leftTile.Pop();
                tmp.SetActive(true);
                tmp.transform.position = app.model.entityDetails.currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
                app.model.entityDetails.currentTile = tmp;
            }
            else if(randomIndex == 1)
            {
                GameObject tmp = topTile.Pop();
                tmp.SetActive(true);
                tmp.transform.position = app.model.entityDetails.currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
                app.model.entityDetails.currentTile = tmp;
            }

            int spawinPicker = Random.Range(0, 10);
            if (spawinPicker == 0)
            {
                app.model.entityDetails.currentTile.transform.GetChild(1).gameObject.SetActive(true);
            }

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

                case GameEventNotification.RandPathGen:

                    GeneratePath();                  
                    break;
                case GameEventNotification.SpawnPath:

                    SpawnTile();
                    break;
                case GameEventNotification.PathFallDown:

                    GameObject go = (GameObject)p_data[0];
                    StartCoroutine("FallDown", go);
                    break;

                case GameEventNotification.PickerOff:
                    Utils.Log("Off the Picker");
                    GameObject picker = (GameObject)p_data[0];
                    picker.SetActive(false);
                    Instantiate(app.model.entityDetails.destroyedParticleSystems, picker.transform.position, Quaternion.identity);
                    break;
            }
        }
    }
}
