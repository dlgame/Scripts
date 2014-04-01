// 	    GameKits by Greenfox
//  Copyright (c) 2014, Recreation studio.

namespace GameKits
{
	using UnityEngine;
	using System.Collections.Generic;

	public class GeneralList<T> : MonoBehaviour
	{
		[ SerializeField ]
		private List<T> data = new List<T>();

		public T[] Get
		{
			get{ return this.data.ToArray(); }
		}

		public void Add(T item)
		{
			this.data.Add(item);
		}

		public bool Remove(T item)
		{
			return this.data.Remove(item);
		}



	}
}
