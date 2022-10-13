﻿using Microsoft.Extensions.Logging;
using Modele.Business.DiceFactoryFolder;
using Modele.Business.DiceFolder;
using Modele.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Manager.DiceManagerFolder
{
    /// <summary>
    /// Represent a manager of simple dice
    /// </summary>
    public class SimpleDiceManager : DiceManager
    {


        /// <summary>
        /// No args constsructor. Calls base's no args constructor.
        /// </summary>
        public SimpleDiceManager() : base() { }


        /// <summary>
        /// Calls parent constructor with only a list of dice.
        /// </summary>
        /// <param name="dice"> A list of dice </param>
        public SimpleDiceManager(IList<Dice> dice) : base(dice) { }

        /// <summary>
        /// Calls parent's constructor with a logger.
        /// </summary>
        /// <param name="logger"> A SimpleDiceManager logger </param>
        public SimpleDiceManager(ILogger<SimpleDiceManager> logger) : base(logger) {}

        /// <summary>
        /// Calls parent's constructor with a dice list and a logger.
        /// </summary>
        /// <param name="dice"> A list of dice </param>
        public SimpleDiceManager(IList<Dice> dice, ILogger<SimpleDiceManager> logger) : base(dice, logger) { }



        /// <summary>
        /// Add one simple dice
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> DiceFactory CreateDice method can throw an exception. </exception>
        /// <param name="nbFace">Dice's number of faces to add</param>
        /// <returns> true if the element could be added, false otherwise </returns>
        public override bool AddDice(int nbFace)
        {
            try
            {
                _dice.Add(new DiceFactory().CreateDice(nbFace));
                return true;
            }
            catch(ArgumentOutOfRangeException aoore)
            {
                return false;
            }
        }


        /// <summary>
        /// Remove one simple dice from the list
        /// </summary>
        /// <param name="nbFaces">Dice's number of faces to remove</param>
        /// <returns> true if the element could be removed, false otherwise. </returns>
        public override bool RemoveDice(int nbFaces)
        {
            try
            {
                return _dice.Remove(new DiceFactory().CreateDice(nbFaces));
            }
            catch(ArgumentOutOfRangeException aoore)
            {
                return false;
            }
        }
    }
}
