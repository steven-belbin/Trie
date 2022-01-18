using System;
using System.Collections.Generic;

namespace Solution
{
    public class Trie
    {
        Node _Root { get; } = new Node();

        public void AddText(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

             _Root.Add(text[0], text.Substring(1));
        }

        public void Print()
        {
            _Root.Print();
        }
    }
    
    public class Node {
        public char _value {get; set; }
        public List<Node> _nodes { set; get; } = new List<Node>();

        public void Add(char value, string remainder)
        {
            var node = _nodes.Find(node => node._value == value);

            if (node == null)
            {
                node = new Node { _value = value };
                _nodes.Add(node);
            }

            if (string.IsNullOrEmpty(remainder)) return;

            node.Add(remainder[0], remainder.Substring(1));
        }

        public void Print()
        {
            Console.Write($"Node value is: {_value} child nodes are : ");

            if (_nodes == null || _nodes.Count == 0)
            {
                Console.WriteLine("<end>");
                return;
            }

            foreach (var node in _nodes) Console.Write($"{node._value}, ");
            Console.WriteLine("");

            foreach (var node in _nodes) node.Print();
        }
    };

    public class Solution {
        public static void Main(string[] args) {
            Trie trie = new Trie();

            trie.AddText("Hello");
            trie.AddText("Hi");
            trie.AddText("Salut");
            trie.AddText("Sam");

            trie.Print();
        }
    }
}
