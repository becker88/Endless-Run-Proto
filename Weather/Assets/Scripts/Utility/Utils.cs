// <copyright file="Utils.cs" company="Matrix Becker">
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
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;


namespace WheelOfFortune
{

    public static class Utils
    {

        private static readonly string logPrefix = "[WheelOfFortune] ";
        private static bool isDebugEnable;

        public static bool IsDebugEnable { set { isDebugEnable = value; } }

        /// <summary>
        /// Show Log
        /// </summary>
        /// <param name="format"></param>
        /// <param name="list"></param>
        public static void Log(string format, params object[] list)
        {
            if (isDebugEnable)
            {
                Debug.Log(logPrefix + string.Format(format, list));
            }
        }

        /// <summary>
        /// Show Warning
        /// </summary>
        /// <param name="format"></param>
        /// <param name="list"></param>
        public static void Warn(string format, params object[] list)
        {
            if (isDebugEnable)
            {
                Debug.LogWarning(logPrefix + string.Format(format, list));
            }
        }

        /// <summary>
        /// Show Error
        /// </summary>
        /// <param name="format"></param>
        /// <param name="list"></param>
        public static void Error(string format, params object[] list)
        {
            if (isDebugEnable)
            {
                throw new System.Exception(logPrefix + string.Format(format, list));
            }
        }

        /// <summary>
        /// Copy Directory
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="copySubDirs"></param>
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Application.persistentDataPath + "/Color Switch/";
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Application.persistentDataPath + "/Color Switch/";
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        /// <summary>
        /// Create and Write File into Proper Path
        /// </summary>
        /// <param name="pathToSave"></param>
        /// <param name="fileName"></param>
        /// <param name="fileExtension"></param>
        /// <param name="dataToWrite"></param>
        public static void CreateAndSaveFile(string pathToSave, string fileName, string fileExtension, string dataToWrite)
        {

            // If the  directory doesn't exist, create it.
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);

                // If the  File doesn't exist, create and Write it.
                if (!File.Exists(pathToSave + fileName + fileExtension))
                {
                    File.WriteAllText(pathToSave + fileName + fileExtension, dataToWrite);
                }
            }
            else
            {
                File.WriteAllText(pathToSave + fileName + fileExtension, dataToWrite);
            }
        }

        /// <summary>
        /// Load file from Specific Path
        /// </summary>
        /// <param name="pathFromLoad"></param>
        /// <returns></returns>
        public static string LoadFile(string pathFromLoad)
        {
            if (!Directory.Exists(pathFromLoad))
            {
                return null;
            }
            var file = Directory.GetFiles(pathFromLoad, "*.*");
            string jsonItem = "";
            foreach (var item in file)
            {

                if (Regex.IsMatch(item, @".json|.txt$"))
                {

                    jsonItem = File.ReadAllText(item);
                }
            }
            return jsonItem;
        }
    }
}
