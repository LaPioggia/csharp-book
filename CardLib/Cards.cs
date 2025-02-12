﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
	public class Cards : CollectionBase,ICloneable
	{
		public void Add(Card newCard) => List.Add(newCard);

		public void Remove(Card newCard) => List.Remove(newCard);

		public Card this[int cardIndex]
		{
			get { return (Card)List[cardIndex]; }
			set { List[cardIndex] = value; }
		}

		/// <summary>
		/// Utility method for copying card instance into another Cards instance-used in Deck.Shuffle().
		/// This implementation assumes that source and target collections are the same size
		/// </summary>
		/// <param name="targetCards"></param>
		public void CopyTo(Cards targetCards)
		{
			for (int index = 0; index < this.Count; index++)
			{
				targetCards[index] = this[index];
			}
		}

		/// <summary>
		/// Check to see if the Cards collection contains a particular card.
		/// This calls the Contains() method of the ArrayList for the collection,which you access through the InnerList property.
		/// </summary>
		/// <param name="card"></param>
		/// <returns></returns>
		public bool Contains(Card card) => InnerList.Contains(card);

		/// <summary>
		/// 深度复制
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			Cards newCards = new Cards();
			foreach (Card sourceCard in List)
			{
				newCards.Add((Card)sourceCard.Clone());
			}
			return newCards;
		}
	}
}
