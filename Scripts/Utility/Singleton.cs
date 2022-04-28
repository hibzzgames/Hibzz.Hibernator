// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  A class that simplifies the creation and usage of singletons
//               in unity projects
// 
// License ID:   N/A
// License:      This script can only be used on projects made by Hibzz Games
//               or on projects that have a valid license ID. To request a
//               custom license and a license ID, please send an email to
//               support@hibzz.games with details about the project.
// 
//               THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY
//               KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//               WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//               PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//               COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//               LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//               ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
//               USE OR OTHER DEALINGS IN THE SOFTWARE.

using UnityEngine;

namespace Hibzz.Hibernator
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = CreateNewInstance();
                }

                return instance;
            }
        }

        private static T CreateNewInstance()
        {
            T[] items = FindObjectsOfType(typeof(T)) as T[];
            if (items.Length == 0)
            {
                // no instance of the singleton found in the scene... so creating one
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name + "Object";
                return obj.AddComponent<T>();
            }
            else if (items.Length > 1)
            {
                // more than one instance found. So returning null
                Debug.LogError("Multiple instances of the singleton found. So, cant determine what's the singleton. Returning null.");
                return null;
            }

            // only one instance of type T found in the scene
            return items[0];
        }

        // when the singleton object gets destroyed, we make sure that the
        // static singleton reference is cleared
        private void OnDestroy()
        {
            // making sure that this object is the static instance, before just 
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}
