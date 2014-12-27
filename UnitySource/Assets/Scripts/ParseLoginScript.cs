using UnityEngine;
using System.Collections;
using Parse;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ParseLoginScript : MonoBehaviour {
	public Text usernameField;
	public Text passwordField;
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Login() {
		string usernameVal = usernameField.text;
		string pwdVal = passwordField.text;
		
		if (!string.IsNullOrEmpty (usernameVal)) {
			Debug.Log("Calling Login....");
			StartCoroutine(callParseLogin(usernameVal, pwdVal));
		}
	}

	protected IEnumerator callParseLogin(string u, string pwd) {
		var taskLogin = ParseUser.LogInAsync (u, pwd);
		taskLogin.ContinueWith (t => {
			if (t.Result == null) {
				Debug.LogWarning ("Login fail");
			} else {
				Debug.Log("Welcome " + t.Result.Username);
			}
		});

		yield return taskLogin ;
	}

	protected void OnLoginComplete(Task<ParseUser> t) {
		if (t.Result == null) {
			Debug.LogWarning ("Login fail");
		} else {
			Debug.Log("Welcome " + t.Result.Username);
		}
	}
}
