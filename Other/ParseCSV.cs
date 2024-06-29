// Have the function MatchCSVWithInputs(string[] inputs, out int sum) use the string array parameter to populate the sum and return true or false if certain criteria are met.  It will be explained that an element in the 'inputs' array may be considered a match, return true if there is a match and false if not.  The sum is calculated from part of the matched element.
// The 'inputs' array can be divided into two sections. The first element represents the "input", while the rest of the elements represent "rows" from a .csv file. The objective is to find a "row" that matches the "input" and calculate the sum of the values provided in that row.
// The input is also comma separated. Each value in the input is a string with no significant meaning. Here is an example of the input element: "A,B,XYZ,1" where there are 4 input values: "A", "B", "XYZ", and "1"
// The subsequent elements in the array simulate a .csv file structure, where each element represents a row. Each row is divided into three sections: the left hand side, the delimiter (always "%%%"), and the right hand side.
// The left hand side can contain zero or more pairs, with each pair consisting of an index and a corresponding value. The index signifies a position within the input, while the value represents the desired string at that index. In order for the row to be considered a match, each pair must match with the corresponding input values.
// The right hand side consists of a list of one or more numbers.
// Here is an example of a row: "1,B,%%%,5,12" where there is 1 pair in the left hand side: (1, "B") and two values on the right hand side: 5 and 12.
// If our two examples combined was the `inputs` parameter to this function, it would look like this: ["A,B,XYZ,1", "1,B,%%%,5,12"]. The implementation of MatchCSVWithInputs should parse the `inputs` parameter into "input" and "rows", match the left hand side of the second element, add the values in the right hand side, assign `sum` the value of 17, and return true as the result.
// If there are no matches, return false. If ["D", "0,A,%%%,5,12"] was the argument passed to this function, false should be returned and the value of sum ignored.

using System;

/// <summary>
/// Do not change the class name, or the function name.  Feel free to add anything else (such as functions or using statements) that would be helpful.
/// </summary>
public class ParseCSVClass
{
    public bool MatchCSVWithInputs(string[] inputs, out int sum)
    {
        sum = -1;
        // Finish implementation.

        const string delimiter = "%%%";

        //parse the inputs parameter into input and rows:
        string[] input = inputs[0].Split(',');
        string[] rows = new string[inputs.Length - 1];
        Array.Copy(inputs, 1, rows, 0, inputs.Length - 1);

        //Iterate through the rows and parse the CSV:
        foreach (string row in rows)
        {
            //Split the row into columns:
            string[] columns = row.Split(',');

            int delimiterIndex = Array.IndexOf(columns, delimiter);
            //delimiter must be present and must be even (since LHS is key-value pairs)
            if (delimiterIndex == -1 || delimiterIndex % 2 == 1)
            {
                return false;
            }
            // Iterate through the columns until the delimiter is found, verifying the LHS.
            // Incrementing by 2 since the LHS is key-value pairs.
            for (int i = 0; i < delimiterIndex; i += 2)
            {

                if (int.TryParse(columns[i], out int x))
                {
                    if (!input[x].Equals(columns[i + 1]))
                    {
                        return false;
                    }
                }
            }
            //If we get beyond this point, the LHS is valid.
            sum = 0;
            for (int i = delimiterIndex + 1; i < columns.Length; i++)
            {
                if (int.TryParse(columns[i], out int value))
                {
                    sum += value;
                }
            }
            return true;
        }
        return false;
    }
}