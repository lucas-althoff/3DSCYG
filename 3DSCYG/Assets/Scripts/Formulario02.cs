// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// //https://www.youtube.com/watch?v=Lq170ztDAPo&ab_channel=HamzaHerbou
// //https://www.youtube.com/watch?v=zbNxrGl4nfc&ab_channel=Abhinava.k.aDemkeys
// //https://github.com/herbou/Unity_ListItems_using_code/blob/master/Assets/Demo.cs
// public static class ButtonExtension2
// {
// 	public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
// 	{
// 		button.onClick.AddListener(delegate() {
// 			OnClick(param);
// 		});
// 	}
// }

// public class Formulario02 : MonoBehaviour
// {
// 	[Serializable]
// 	public struct Item
// 	{
// 		public string Nome;
// 		public string Descricao;
// 		public Sprite Icone;
// 	}

// 	[SerializeField] Item[] todosItens;

// 	void Start ()
// 	{
//         GameObject grupoBotoes = transform.Find("Scrollbar").transform.GetChild(0).Find("botaoDominio").gameobject;
// 		GameObject g;
        
// 		int N = todosItens.Length;

// 		for (int i = 0; i < N; i++) {
// 			g = Instantiate(grupoBotoes, transform);
            
// 			g.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = todosItens[i].Nome;
// 			g.transform.GetChild(1).GetComponent<Image>().sprite = todosItens[i].Icone;
// 			//g.transform.GetChild(2).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = todosItens[i].Descricao;
// 			//g.transform.GetChild(2).GetComponent<Button>().AddEventListener(i, InformClicked);
//             g.GetComponent<Button>().AddEventListener(i, ItemClicked);
// 		}

// 		Destroy (grupoBotoes);
// 	}

// 	void ItemClicked (int itemIndex)
// 	{
// 		Debug.Log ("------------item " + itemIndex + " clicked---------------");
// 		Debug.Log ("nome " + todosItens[itemIndex].Nome);
// 		//Debug.Log ("desc " + todosItens [itemIndex].Descricao);
// 	}

//     void InformClicked (int itemIndex)
// 	{
// 		Debug.Log ("------------item " + itemIndex + " clicked---------------");
// 		Debug.Log ("nome " + todosItens[itemIndex].Nome);
// 		//Debug.Log ("desc " + todosItens [itemIndex].Descricao);
// 	}
// }