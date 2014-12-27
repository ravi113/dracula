using UnityEngine;
using System.Collections;
using Parse;
using UnityEngine.UI;

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
		 	ParseUser.LogInAsync(usernameVal, pwdVal).ContinueWith(t => {
				if(t.IsFaulted || t.IsCanceled) {
					// Login fail
					//Text status = GameObject.Find("statusText").GetComponent<Text>();
					//status.text = "Fail to login";
					Debug.LogWarning("Fail to login");
				}
				else {
					// Login Success
					usernameField.enabled = false;
					passwordField.enabled = false;
					usernameField.text = "welcome " + ParseUser.CurrentUser.Username;
				}
			});
		}
	}
}
