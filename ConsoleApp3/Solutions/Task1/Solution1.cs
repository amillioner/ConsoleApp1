namespace ConsoleApp3.Solutions.Task1
{
    //Using C# create a function that takes a string as an input parameter
    //and returns the reverse of that string as the return value.
    //Do not use the built in String.Reverse function.
    public class Solution1
    {
        public string? ReverseString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            char[] str = input.ToCharArray();
            int left = 0;
            int right = str.Length - 1;
            char t;
            while (left < right)
            {
                t = str[left];
                str[left] = str[right];
                str[right] = t;
                //(str[left], str[right]) = (str[right], str[left]);
                left++;
                right--;
            }
            return new string(str);
        }
        public string? RecReverseString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            char[] str = input.ToCharArray();
            ReverseInternal(str, 0, str.Length - 1);
            return new string(str);
        }
        public void ReverseInternal(char[] str, int left, int right)
        {
            if (left >= right) return;
            (str[left], str[right]) = (str[right], str[left]);
            ReverseInternal(str, left + 1, right - 1);
        }
    }
}