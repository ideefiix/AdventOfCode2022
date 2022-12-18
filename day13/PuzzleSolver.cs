using System.Collections;
using System.Text.Json.Nodes;
namespace day13;

public class PuzzleSolver
{
    private string[] input;

    public PuzzleSolver()
    {
        input = System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day13\input.txt");
    }

    public void Puzzle1Solution()
    {
        List<JsonNode[]> pairOfPackets = GetPackets(input).Chunk(2).ToList();
        
        int answer = pairOfPackets.Select((pair, index) =>
                Compare(pair[0], pair[1]) < 2 ? index + 1 : 0)
            .Sum();

        Console.WriteLine("The sum of the right pair indicies are: " + answer);
    }

    public void Puzzle2Solution()
    {
        List<JsonNode> packets = GetPackets(input);
        JsonNode dividerPacket1 = JsonNode.Parse("[[2]]");
        JsonNode dividerPacket2 = JsonNode.Parse("[[6]]");
        int div1Index = GetIndexOfElementIfSorted(dividerPacket1, packets) + 1; 
        int div2Index = GetIndexOfElementIfSorted(dividerPacket2, packets) + 2; //Add 2 here because dividerPacket1 comes before also
        
        Console.WriteLine("Divider packets are at index " + div1Index + " and " + div2Index + ". With a decoding key of " + (div1Index * div2Index));

    }
    
    // 0 --> Items are equal
    // 1 --> Left is smaller
    // 2 --> Left is bigger
    public int Compare(JsonNode left, JsonNode right)
    {
        if (left is JsonValue && right is JsonValue)
        {
            if (left.GetValue<int>() < right.GetValue<int>()) return 1;
            if (left.GetValue<int>() > right.GetValue<int>()) return 2;
            else return 0;
        }

        if (left is JsonArray && right is JsonArray)
        {
            int shortestIndex = Math.Min(left.AsArray().Count, right.AsArray().Count);
            for (int i = 0; i < shortestIndex; i++)
            {
                int res = Compare(left.AsArray()[i], right.AsArray()[i]);
                if (res == 0) continue;
                if (res == 1) return 1;
                if (res == 2) return 2;

            }
            //Longest array is biggest
            if (left.AsArray().Count == right.AsArray().Count) return 0;
            if (left.AsArray().Count < right.AsArray().Count) return 1;
            if (left.AsArray().Count > right.AsArray().Count) return 2;
        }

        JsonArray leftArr = left as JsonArray ?? new JsonArray(left.GetValue<int>());
        JsonArray rightArr = right as JsonArray ?? new JsonArray(right.GetValue<int>());
        return  Compare(leftArr, rightArr);
    }

    public List<JsonNode> GetPackets(string[] input)
    {
      var packets = input.Where(line => string.IsNullOrEmpty(line) == false);
      List<JsonNode> result = new List<JsonNode>();
      
      foreach (var packet in packets)
      {
          result.Add(JsonNode.Parse(packet));
      }
      return result;
    }

    public int GetIndexOfElementIfSorted(JsonNode element, List<JsonNode> input)
    {
        return (from packet in input where Compare(packet, element) < 2 select packet).Count();
    }
}