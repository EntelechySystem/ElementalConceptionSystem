using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace ECS.Core.LanguageProcess;

public class ContexFreeGammar
{
    public string Lhs { get; }
    public List<List<string>> Rhs { get; }

    public static Dictionary<string, List<string[]>> Rules(Dictionary<string, string> rules)
    {
        var result = new Dictionary<string, List<string[]>>();
        foreach (var item in rules)
        {
            var lhs = item.Key;
            var rhs = item.Value;
            var alternatives = rhs.Split('|').Select(alt => alt.Trim().Split()).ToList();
            result[lhs] = alternatives;
        }
        return result;
    }

}

public class Lexicon
{
    public string Lhs { get; }
    public List<string> Rhs { get; }

    public Lexicon(string lhs, List<string> rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }
}

public class Grammar
{
    public string Name { get; }
    public List<Rule> Rules { get; }
    public List<Lexicon> Lexicon { get; }
    public Dictionary<string, List<string>> Categories { get; }

    public Grammar(string name, List<Rule> rules, List<Lexicon> lexicon)
    {
        Name = name;
        Rules = rules;
        Lexicon = lexicon;
        Categories = new Dictionary<string, List<string>>();
        foreach (var lhs in lexicon)
        {
            foreach (var word in lhs.Rhs)
            {
                if (!Categories.ContainsKey(word))
                {
                    Categories[word] = new List<string>();
                }

                Categories[word].Add(lhs.Lhs);
            }
        }
    }

    public List<List<string>> RewritesFor(string cat)
    {
        return Rules.FirstOrDefault(r => r.Lhs == cat)?.Rhs ?? new List<List<string>>();
    }

    public bool IsA(string word, string cat)
    {
        return Categories.ContainsKey(word) && Categories[word].Contains(cat);
    }

    public override string ToString()
    {
        return $"<Grammar {Name}>";
    }
}
//
// E0 = new Grammar("E0",
//     new Rules( // Grammar for E_0 [Figure 22.4]
//         S = "NP VP | S Conjunction S",
//         NP = "Pronoun | Name | Noun | Article Noun | Digit Digit | NP PP | NP RelClause", // noqa
//         VP = "Verb | VP NP | VP Adjective | VP PP | VP Adverb",
//         PP = "Preposition NP",
//         RelClause = "That VP"
//     ),
//     new Lexicon( // Lexicon for E_0 [Figure 22.3]
//         动作名词 = "",
//         名词 = "stench | breeze | glitter | nothing | wumpus | pit | pits | gold | east", // noqa
//         动词 = "is | see | smell | shoot | fell | stinks | go | grab | carry | kill | turn | feel", // noqa
//         形容词 = "right | left | east | south | back | smelly",
//         副词 = "here | there | nearby | ahead | right | left | east | south | back", // noqa
//         代词 = "me | you | I | it",
//         专有名词 = "John | Mary | Boston | Aristotle",
//         冠词 = "the | a | an",
//         介词 = "to | in | on | near",
//         连词 = "and | or | but",
//         数词 = "0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9",
//         That = "that"
//     )
// );
// E_ = new Grammar("E_", // Trivial Grammar and lexicon for testing
//     new Rules(
//         S = "NP VP",
//         NP = "Art N | Pronoun",
//         VP = "V NP"
//     ),
//     new Lexicon(
//         Art = "the | a",
//         N = "man | woman | table | shoelace | saw",
//         Pronoun = "I | you | it",
//         V = "saw | liked | feel"
//     )
// );
//
// E_NP_ = new Grammar("E_NP_", // another trivial grammar for testing
//     new Rules(
//         NP = "Adj NP | N"
//     ),
//     new Lexicon(
//         Adj = "happy | handsome | hairy",
//         N = "man"
//     )
);