using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string v)
        {
            string delimiters = "," ;
            string usingNumbers = v;
            if (v.Contains("//["))
            {
                delimiters = "";
                string[] tempDelimiters = v.Split('[');
                for (int i = 1; i < tempDelimiters.Length; i++)
                {
                    delimiters += tempDelimiters[i].Substring(0, v.IndexOf(']') - 3);
                }
                //delimiter = v.Substring(3, v.IndexOf(']') - 3);
                usingNumbers = v.Substring(v.IndexOf('\n') + 1);
            }
            else if (v.Contains("//"))
            {
                delimiters = "";
                delimiters = v.Substring(2, 1);
                usingNumbers = v.Substring(4);
            }
            if (usingNumbers.Equals(string.Empty))
            {
                return 0;
            }
            if (usingNumbers.Length == 1)
            {
                return int.Parse(usingNumbers);
            }

            List<string> numbers = new List<string>();
            StringBuilder negativeNumbers = new StringBuilder();
            
            List<string> initialNumbers = usingNumbers.Split(delimiters.ToCharArray()).ToList<string>();
            initialNumbers.ForEach(item =>
            {
                List<string> tempNumbers = item.Split('\n').ToList<string>();
                tempNumbers.ForEach(temp =>
                {
                    if (temp != string.Empty)
                    {
                        numbers.Add(temp);
                    }
                });
            });
            int result = 0;
            numbers.ForEach(item =>
            {
                int tempNumber = int.Parse(item);
                if (tempNumber < 0)
                {
                    negativeNumbers.Append(item);
                }
                if (tempNumber <= 1000)
                {
                    result += tempNumber;
                }
            });
            if (negativeNumbers.Length > 0)
            {
                throw new ArgumentOutOfRangeException($" Negative numbers were found in the parameter v. Negative numbers are {negativeNumbers}");
            }
            return result;
        }
    }
}
