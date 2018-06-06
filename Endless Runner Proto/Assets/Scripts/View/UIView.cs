// <copyright file="UIView.cs" company="Zabingo Softwares">
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
using Becker.MVC;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunner{

    public class UIView : View<ApplicationGameManager>
    {
        int score = 0;
        int hiScore = 0;
        float duration = 0.5f;
        /// <summary>
        /// Enabling Restart Button
        /// </summary>
        private void EnableRestart(bool isActive)
        {
            app.model.uiComp.gameOver.SetActive(isActive);
        }

        /// <summary>
        /// Restart Game
        /// </summary>
        public void ResetGame()
        {
            EnableRestart(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        /// <summary>
        /// Display and View Scores
        /// </summary>
        public void DisplyScoreTable()
        {
            StartCoroutine(ArrengeScoreTable(app.model.HighScore, app.model.CurrentScore));
        }


        IEnumerator ArrengeScoreTable(int targetHiScore, int targetCurrScore)
        {
            EnableRestart(true);
            yield return new WaitForSeconds(1.0f);

            int startOne = hiScore;
            int startTwo = score;

            for (float timer = 0; timer < 3.0f; timer += Time.deltaTime)
            {
                float progress = timer / 3.0f;

                hiScore = (int)Mathf.Lerp(startOne, targetHiScore, progress);
                app.model.uiComp.bestScore.text = hiScore.ToString();

                score = (int)Mathf.Lerp(startTwo, targetCurrScore, progress);
                app.model.uiComp.currentScore.text = score.ToString();

                yield return null;
            }
            hiScore = targetHiScore;
            score = targetCurrScore;

        }


    }
}
