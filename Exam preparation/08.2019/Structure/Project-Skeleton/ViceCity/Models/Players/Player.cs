﻿using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }
                name = value;
            }
        }
        public bool IsAlive => LifePoints > 0;
        public IRepository<IGun> GunRepository { get; private set; }
        public int LifePoints
        {
            get { return lifePoints; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (LifePoints - points < 0)
            {
                LifePoints = 0;
            }
            else
            {
                LifePoints -= points;
            }
        }
    }
}
