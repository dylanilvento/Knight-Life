using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayKeeper : MonoBehaviour {

	//int dayCnt = 0;
	public DayList days = new DayList();
	static DayTransitioner dayTrans;

	void Start () {

		dayTrans = GetComponent<DayTransitioner>();

		days.AddDay("Day 1");
		days.AddDay("Day 2");
		days.AddDay("Day 6");
		days.AddDay("Day 27");
		days.AddDay("Day 52");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetCurrentDay () {
		return days.GetCurrentDay();
	}

	public void IncrementDay () {
		days.AdvanceTime();
	}

	public class Day {
		bool madeFood = false;
		bool watchedTV = false;
		bool slept = false;
		public Day nextDay;

		public string name;

		public Day (string name) {
			//print(name);
			this.name = name;
			//print(this.name);
			//nextDay = this.nextDay;
		}

		public void SetMadeFood (bool val) {
			madeFood = val;
		}

		public bool GetMadeFood () {
			return madeFood;
		}

		public void SetWatchedTV (bool val) {
			watchedTV = val;
		}

		public bool GetWatchedTV () {
			return watchedTV;
		}

		public void SetSlept (bool val) {
			slept = val;

			if (val) {

				dayTrans.DayTransition();

				//Timeline.Instance.DayTransition();
				//GameAnimation.Instance.GraphicFadeIn();
			}

		}

		public bool GetSlept () {
			return slept;
		}

		public override string ToString () {
			return name;
		}
	}

	public class DayList {
		Day firstDay;
		Day nextDay;
		public Day currDay;

		public DayList() {

		}

		public void AddDay(string str) {
			//print(str);
			Day newDay = new Day(str);

			if (firstDay == null) {
				firstDay = newDay;
				currDay = firstDay;
			}

			else {
				Day currentDay = firstDay;

				while (currentDay.nextDay != null) {
					//print(currentDay.name);
					currentDay = currentDay.nextDay;
				}

				if (currentDay.nextDay == null) {
					
					currentDay.nextDay = newDay;
					//print(currentDay + "'s next day is " + currentDay.nextDay);

				}
			}
		}

		public void AdvanceTime () {
			currDay = currDay.nextDay;
		}

		public string GetCurrentDay () {
			return currDay.name;
		}

		public string GetNextDay () {
			return currDay.nextDay.name;
		}
	}
}
