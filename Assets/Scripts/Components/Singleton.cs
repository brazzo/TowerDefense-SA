using UnityEngine;
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	/***
	 * Quelle: http://www.glenstevens.ca/unity3d-best-practices/
	 ***/
	protected static T instance;

	public static T Instance {
		get {
			if (instance == null) {
				instance = (T)FindObjectOfType (typeof(T));

				if (instance == null) {
					Debug.LogError ("An instance of " + typeof(T) +
					" is needed in the scene, but there is none.");
				}
			}

			return instance;
		}
	}
}
