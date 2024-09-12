using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your input: ");
        string input = Console.ReadLine().Trim();

        if (input.Contains("%"))
        {
            string decompressed = decompress(input);
            Console.WriteLine(decompressed);
        }
        else
        {
            string compressed = compress(input);
            Console.WriteLine(compressed);
            
        }




    }
    static string compress(string input)
    {
        StringBuilder compressed = new StringBuilder();

        int count = 1;

            for (int i = 0; i<input.Length; i++)
            {
                if(i + 1 < input.Length && input[i] == input[i + 1])
                {
                    count++;
                }
                else
                {
                    
                    compressed.Append("%");
                    compressed.Append(count);
                    compressed.Append("%");
                    
                    compressed.Append(input[i]);
                    count = 1;
                   
                }

            
                            }
            return compressed.ToString();
            }

    static string decompress(string input)
    {
        StringBuilder decompressed = new StringBuilder();
        int i = 0;
        while (i < input.Length)
        {
            if (input[i] == '%')
            {
                
                int end = input.IndexOf('%', i + 1);
                int repeatCount = int.Parse(input.Substring(i + 1, end - i - 1));
                
                char repeatChar = input[end + 1];
                decompressed.Append(new string(repeatChar, repeatCount));
                
                i = end + 2;
            }
            else
            {
               
                decompressed.Append(input[i]);
                i++;
            }
        }
        return decompressed.ToString();
    }

}




