using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PyramidControl : MonoBehaviour
{
	public static int slotsOccupied;

	[SerializeField]
	private Transform[] rings;

	[SerializeField]
	private GameObject winSign;

	[SerializeField]
	private GameObject wrongSign;
	public Text textScore;

    // Start is called before the first frame update
    private void Start()
    {
		Drag.PuzzleDone += CheckResults;
		slotsOccupied = 0;
		winSign.SetActive(true);
		wrongSign.SetActive(true);
		textScore.text = "0";
    }

	public void CheckResults()
	{
		Debug.Log (rings[0].position.y);
		if (rings[0].position.y == 1.7f &&
			rings[1].position.y == 0.15f &&
			rings[2].position.y == -1.5f &&
			rings[3].position.y == -3.15f)
		{
			winSign.SetActive(true);
			Invoke("ReloadGame", 2f);
		}
		else
		{
			wrongSign.SetActive(true);
			Invoke("ReloadGame", 1f);
		}
	}

	private void ReloadGame()
	{
		Drag.PuzzleDone -= CheckResults;
		SceneManager.LoadScene("SampleScene");
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log ("----------->");
		for (int i = 0; i < rings.Length; i++)
		{
			Debug.Log(rings[i].position + rings[i].name);
		}
		if (rings.Length == 4)
		{
			int[] sct = new int[4];
			sct[0] = sct[1] = sct[2] = sct[3] = 0;
			if (rings[0].position == new Vector3(-4f, 1.7f, 0f))
			{
				sct[0] = 1;
			}
			else sct[0] = 0;
			if (rings[1].position == new Vector3(-4f, 0.15f, 0f))
			{
				sct[1] = 1;
			}
			else sct[1] = 0;
			if (rings[2].position == new Vector3(-4f, -1.5f, 0f))
			{
				sct[2] = 1;
			}
			else sct[2] = 0;
			if (rings[3].position == new Vector3(-4f, -3.15f, 0f))
			{
				sct[3] = 1;
			}
			else sct[3] = 0;
			int sum = sct[0] + sct[1] + sct[2] + sct[3];
			textScore.text = sum.ToString();
			// if (rings[0].position == new Vector3(-4f, 1.7f, 0f) ||
			// 	rings[1].position == new Vector3(-4f, 0.15f, 0f) ||
			// 	rings[2].position == new Vector3(-4f, -1.5f, 0f) ||
			// 	rings[3].position == new Vector3(-4f, -3.15f, 0f))
			// {
			// 	textScore.text = "1";
			// }
			// else if ((rings[0].position == new Vector3(-4f, 1.7f, 0f) && rings[1].position == new Vector3(-4f, 0.15f, 0f)) ||
			// 	(rings[0].position == new Vector3(-4f, 1.7f, 0f) && rings[1].position == new Vector3(-4f, -1.5f, 0f)) ||
			// 	(rings[0].position == new Vector3(-4f, 1.7f, 0f) && rings[1].position == new Vector3(-4f, -3.15f, 0f)) ||
			// 	(rings[0].position == new Vector3(-4f, 0.15f, 0f) && rings[1].position == new Vector3(-4f, -1.5f, 0f)) ||
			// 	(rings[0].position == new Vector3(-4f, 0.15f, 0f) && rings[1].position == new Vector3(-4f, -3.15f, 0f)) ||
			// 	(rings[0].position == new Vector3(-4f, -1.5f, 0f) && rings[1].position == new Vector3(-4f, -3.15f, 0f)))
			// {
			// 	textScore.text = "2";
			// }
		}
		if (rings.Length == 5)
		{
			int[] sct = new int[5];
			sct[0] = sct[1] = sct[2] = sct[3] = sct[4] = 0;
			if (rings[0].position == new Vector3(-4f, 3.25f, 0f))
			{
				sct[0] = 1;
			}
			else sct[0] = 0;
			if (rings[1].position == new Vector3(-4f, 1.7f, 0f))
			{
				sct[1] = 1;
			}
			else sct[1] = 0;
			if (rings[2].position == new Vector3(-4f, 0.15f, 0f))
			{
				sct[2] = 1;
			}
			else sct[2] = 0;
			if (rings[3].position == new Vector3(-4f, -1.5f, 0f))
			{
				sct[3] = 1;
			}
			else sct[3] = 0;
			if (rings[4].position == new Vector3(-4f, -3.15f, 0f))
			{
				sct[4] = 1;
			}
			else sct[4] = 0;
			int sum = sct[0] + sct[1] + sct[2] + sct[3] + sct[4];
			textScore.text = sum.ToString();
		}
		if (rings.Length == 9)
		{
			int[] sct = new int[9];
			sct[0] = sct[1] = sct[2] = sct[3] = sct[4] = sct[5] = sct[6] = sct[7] = sct[8] = 0;
			if (rings[0].position == new Vector3(-4f, 3.25f, 0f) || rings[0].position == new Vector3(5.2f, 1.7f, 0f))
			{
				sct[0] = 1;
			}
			else sct[0] = 0;
			if (rings[1].position == new Vector3(-4f, 3.25f, 0f) || rings[1].position == new Vector3(5.2f, 1.7f, 0f))
			{
				sct[1] = 1;
			}
			else sct[1] = 0;
			if (rings[2].position == new Vector3(-4f, 1.7f, 0f) || rings[2].position == new Vector3(5.2f, 0.15f, 0f))
			{
				sct[2] = 1;
			}
			else sct[2] = 0;
			if (rings[3].position == new Vector3(-4f, 1.7f, 0f) || rings[3].position == new Vector3(5.2f, 0.15f, 0f))
			{
				sct[3] = 1;
			}
			else sct[3] = 0;
			if (rings[4].position == new Vector3(-4f, 0.15f, 0f) || rings[4].position == new Vector3(5.2f, -1.5f, 0f))
			{
				sct[4] = 1;
			}
			else sct[4] = 0;
			if (rings[5].position == new Vector3(-4f, 0.15f, 0f) || rings[5].position == new Vector3(5.2f, -1.5f, 0f))
			{
				sct[5] = 1;
			}
			else sct[5] = 0;
			if (rings[6].position == new Vector3(-4f, -1.5f, 0f) || rings[6].position == new Vector3(5.2f, -3.15f, 0f))
			{
				sct[6] = 1;
			}
			else sct[6] = 0;
			if (rings[7].position == new Vector3(-4f, -1.5f, 0f) || rings[7].position == new Vector3(5.2f, -3.15f, 0f))
			{
				sct[7] = 1;
			}
			else sct[7] = 0;
			if (rings[8].position == new Vector3(-4f, -3.15f, 0f))
			{
				sct[8] = 1;
			}
			else sct[8] = 0;
			int sum = sct[0] + sct[1] + sct[2] + sct[3] + sct[4] + sct[5] + sct[6] + sct[7] + sct[8];
			textScore.text = sum.ToString();
		}
    }
}
