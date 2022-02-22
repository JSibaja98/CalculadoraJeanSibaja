using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJeanSibaja
{
    public class Actions
    {
        public double numberOne { get; set; }
        public double numberTwo { get; set; }
        public double result { get; set; }
        public double memory { get; set; }

        public Actions()
        {
            this.numberOne = 0.0;
            this.numberTwo = 0.0;
            this.result = 0.0;
            this.memory = 0.0;
        }

        public void memoryClear()
        {
            this.memory = 0;
        }

        public double memoryRecall()
        {
            return this.memory;
        }

        public void memoryStorage(double pMemoryNumber)
        {
            this.memory = pMemoryNumber;
        }

        public void mPlus(double pScreenNumber)
        {
            this.memory += pScreenNumber;
        }

        public void mMinus(double pScreenNumber)
        {
            this.memory -= pScreenNumber;
        }

        public void clear()
        {
            this.numberOne = 0.0;
            this.numberTwo = 0.0;
            this.result = 0.0;
            this.memory = 0.0;
        }

        public void clearNumbers()
        {
            this.numberOne = 0.0;
            this.numberTwo = 0.0;
        }

        public int mod()
        {
            int quo = (int)((int)this.numberOne / (int)this.numberTwo);
            this.clearNumbers();
            return quo;
        }

        public string calculation(string pOperation)
        {
            try
            {
                if (pOperation.Equals("+"))
                {
                    this.result = this.numberOne + this.numberTwo;
                }
                else if (pOperation.Equals("-"))
                {
                    this.result = this.numberOne - this.numberTwo;
                }
                else if (pOperation.Equals("/"))
                {
                    this.result = this.numberOne / this.numberTwo;
                }
                else if (pOperation.Equals("*"))
                {
                    this.result = this.numberOne * this.numberTwo;
                }
                else
                {
                    return "ERROR";
                }

                this.clearNumbers();

                return this.result.ToString();
            }

            catch (Exception)
            {
                return "SYNTAX ERROR";
            }

        }

    }
}

