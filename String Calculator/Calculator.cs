using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Calculator
{
    public class Calculator
    {

        private const string CustomDelimNotation = "//";
        private readonly List<string> _delimiters = new List<string> { ",", "\n" };
        public int Add(string numbers)
        {
            string cleanedNumbers = numbers;
            if (numbers.StartsWith(CustomDelimNotation))
            {
                addCustomDelims(ref numbers);
                cleanedNumbers = removeCustomDelimString(numbers);
            }

            string splitNumbers = splitStringByDelimeters(cleanedNumbers);
            if (string.IsNullOrEmpty(splitNumbers) || splitNumbers == ",")
                return 0;                                                           
            List<int> numberList = splitString(splitNumbers);
            List<int> validList = removeInvalidEntries(numberList);
            validateInput(validList);
            int res = getSum(validList);
            return res;
        }

        private void addCustomDelims(ref string input)
        {
            string[] customDelimStrings = { CustomDelimNotation, "[", "]" };
            List<string> customDelimeters = input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                                                    .First()
                                                                    .Split("][")
                                                                    .ToList();
            customDelimeters.ForEach(o =>
            {
                string cleanedDelim = o;
                customDelimStrings.ToList().ForEach(delim =>
                {
                    cleanedDelim = cleanedDelim.Replace(delim, "");
                });
                _delimiters.Add(cleanedDelim);
            });
        }

        private string removeCustomDelimString(string input)
        {
            return input.Remove(0, input.IndexOf("\n") + 1);
        }

        private string splitStringByDelimeters(string input)
        {
            _delimiters.ForEach(delim => { input = input.Replace(delim, ","); });
            return input;
        }



        private List<int> splitString(string input)
        {
            return input.Split(",").Select(o => Convert.ToInt32(o)).ToList();
        }

        private List<int> removeInvalidEntries(List<int> input)
        {
            return input.Where(o => o <= 1000).ToList();
        }

        private void validateInput(List<int> input)
        {
            List<int> negatives = input.Where(o => o < 0).ToList();
            if (negatives.Count > 0)
            {
                string negativeNumbers = string.Join(',', negatives);
                throw new Exception($"Negative Numbers are not allowed \n  negatives found: {negativeNumbers}");
            }
        }
        private int getSum(List<int> input)
        {
            return input.Sum();
        }
    }
}
