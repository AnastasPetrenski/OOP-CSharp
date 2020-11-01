﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal : ISoundProducable
    {
        private const string ERROR_MESSAGE = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        
        public string Name 
        {
            get { return this.name; }
            set 
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }
                
                this.name = value;
                
            } 
        }
        public int Age 
        {
            get { return this.age; }
            set
            {   
                if (value < 0)
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }

                this.age = value;
            } 
        }
        
        public string Gender 
        {
            get { return this.gender; }
            set 
            {
                Gender gender;
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || !Enum.TryParse<Gender>(value, out gender))
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }

                this.gender = value;
            } 
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine(this.GetType().Name)
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .AppendLine(this.ProduceSound());
            
            return sb.ToString().Trim();
        }
    }
}