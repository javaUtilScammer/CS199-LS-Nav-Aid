using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleDropDownScript : MonoBehaviour {
	public bool marked = false;
	private bool done = false;
	private GameObject obj, btn, txt;
	private Dropdown drop;
	private Text txtobj;

	void Start () {
		obj = GameObject.Find("DestList");
		btn = GameObject.Find("ConfirmButton");
		txt = GameObject.Find("MessageText");
		drop =  obj.GetComponent<Dropdown>();
		txtobj = txt.GetComponent<Text>();
		Dropdown.OptionData list = new Dropdown.OptionData("Alingal Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Bellarmine Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Berchmans Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Blue Eagle Gym");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Cervini Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Church of the Gesu");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Communications Department");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Covered Courts");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Dela Costa Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Eliazo Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Escaler Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Faber Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Faura Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Gonzaga Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Henry Lee Irwin Theatre");
		drop.options.Add(list);
		list = new Dropdown.OptionData("JGSOM");
		drop.options.Add(list);
		list = new Dropdown.OptionData("JSEC");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Kostka Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Leong Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("MVP Student Leadership Center");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Manila Observatory");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Matteo Ricci Study Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("New Rizal Library");
		drop.options.Add(list);
		list = new Dropdown.OptionData("PIPAC");
		drop.options.Add(list);
		list = new Dropdown.OptionData("PLDT-CTC Building");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Rizal Library");
		drop.options.Add(list);
		list = new Dropdown.OptionData("SEC A");
		drop.options.Add(list);
		list = new Dropdown.OptionData("SEC B");
		drop.options.Add(list);
		list = new Dropdown.OptionData("SEC C");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Schmitt Hall");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Social Sciences Building");
		drop.options.Add(list);
		list = new Dropdown.OptionData("University Residence North and South");
		drop.options.Add(list);
		list = new Dropdown.OptionData("Xavier Hall");
		drop.options.Add(list);
		obj.SetActive(false);
		btn.SetActive(false);
	}
	
	void Update () {
		if(!done){
			if(marked){
				obj.SetActive(marked);
				btn.SetActive(marked);
				txtobj.text = "Marker scan successful!\nUser location is currently at the SEC marker.\nPlease select your destination.";
				done = true;
			}
		}
	}
}
