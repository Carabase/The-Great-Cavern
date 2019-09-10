using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public class Parser
    {
        // Very Messy and complicated. Consider replacing with a Dictionary API.
        public static List<string> Parse(string input)
        {
            List<string> ParsedInput = new List<string>();
            List<string> UnparsedInput = new List<string>();

            List<string> NounDictionary = new List<string>();
            NounDictionary.AddRange(Globals.LocationDictionary);
            NounDictionary.AddRange(Globals.ItemDictionary);
            NounDictionary.AddRange(Globals.NPCDictionary);

            var pattern = new Regex(
            @"( \w(?<!\d)[\w'-]*            
            )",
            RegexOptions.IgnorePatternWhitespace);

            foreach (Match m in pattern.Matches(input))
            {
                UnparsedInput.Add(m.Groups[1].Value);
            }


            if (UnparsedInput.Count > 6)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("Try being a little less wordy.");
                return null;
            }

            List<string> format = new List<string>();
            string current = null;
            foreach (string word in UnparsedInput)
            {
                foreach (string thing in NounDictionary)
                {
                    if (word == thing )
                    {
                        ParsedInput.Add(word);
                        format.Add("noun");
                        break;
                    }
                }

                foreach (string verb in Globals.VerbDictionary)
                {
                    if ( word == verb)
                    {
                        ParsedInput.Add(word);
                        format.Add("verb");
                        break;
                    }
                }

                foreach (string verb in Globals.MovementVerbDictionary)
                {
                    if (word == verb && ParsedInput.Count > 0)
                    {
                        if (ParsedInput[ParsedInput.Count - 1] != "go" && ParsedInput[ParsedInput.Count - 1] != "move")
                        {
                            ParsedInput.Add(word);
                            format.Add("verb");
                            break;
                        }

                        else 
                        {
                            ParsedInput.Add(word);
                            format.Add("noun");
                            break;
                        }
                    }

                    else if (word == verb)
                    {
                        ParsedInput.Add(word);
                        format.Add("verb");
                        break;
                    }
                }

                if(ParsedInput.Count > 0)
                {
                    foreach(string special in Globals.SpecialDictionary)
                    {
                        if (word == special)
                        {
                            ParsedInput.Add(word);
                            format.Add("noun");
                            break;
                        }
                    }
                }
                
                current = word;
            }

            if (format.Contains("noun"))
            {
                foreach (string adj in Globals.AdjectiveDictionary)
                {
                    if (UnparsedInput.Contains(adj))
                    {
                        UnparsedInput.Remove(adj);
                    }
                }
            }

            if (ParsedInput.Count > 1)
            {
                if (ParsedInput[0] == "pick" && ParsedInput[1] == "up")
                {
                    format.RemoveAt(1);
                    ParsedInput.Remove("up");
                    UnparsedInput.Remove("up");
                }
            }
            
            if (ParsedInput.Count > 3)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You're trying to do too much at once.");
                return null;
            }

            if (ParsedInput.Count < 1)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("I don't know any of those words...");
                return null;
            }

            // Catch a Noun
            if (format[0] == "noun")
            {
                if (ParsedInput.Count > 1)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("That doesn't make sense. Please check your word order.");
                    return null;
                }

                int noun = -1;
                int article = -1;
                foreach(string word in UnparsedInput)
                {
                    if(word == ParsedInput[0])
                    {
                        noun = UnparsedInput.IndexOf(word);
                        break;
                    }

                    if ((word ==  "a" ||
                        word == "an" ||
                        word == "the") &&
                        article < 0)
                    {
                        article = UnparsedInput.IndexOf(word);
                    }
                }

                if (UnparsedInput[0] != ParsedInput[0] && 
                    UnparsedInput[0] != "a" &&
                    UnparsedInput[0] != "an" &&
                    UnparsedInput[0] != "the")
                {   
                    if (article > 0)
                    {
                        if(article == 1)
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("I don't know the word: " + "'" + UnparsedInput[0] + "'");
                            return null;
                        }
                        string errorphrase = null;
                        for (int i = 0; i < article; i++)
                        { 
                            errorphrase += (UnparsedInput[i] + " ");
                        }
                        Globals.WindowFrame.DisplayTextToFlowDoc("I don't know what " + "'" + errorphrase.Trim() + "' refers to.");
                        return null;
                    }

                    else
                    {
                        if (noun == 1)
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("I don't know the word: " + "'" + UnparsedInput[0] + "'");
                            return null;
                        }
                        string errorphrase = null;
                        for (int i = 0; i < noun; i++)
                        {
                            errorphrase += (UnparsedInput[i] + " ");
                        }
                        Globals.WindowFrame.DisplayTextToFlowDoc("I don't know what " + "'" + errorphrase.Trim() + "'" + " refers to.");
                        return null;
                    }
                }

                if (UnparsedInput[0] == "a" || UnparsedInput[0] == "an" || UnparsedInput[0] == "the" || UnparsedInput[0] == ParsedInput[0])
                {
                    if (article >= 0)
                    { 
                        if ((noun - article) == 2)
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("I don't know the word: " + "'" + UnparsedInput[1] + "'");
                            return null;
                        }

                        else
                        {
                            string errorphrase = null;
                            for (int i = article + 1; i < noun; i++)
                            {
                                errorphrase += (UnparsedInput[i] + " ");
                            }
                            Globals.WindowFrame.DisplayTextToFlowDoc("I don't know what: " + "'" + errorphrase.Trim() + "'" + " refers to.");
                            return null;
                        }
                    }
                    if (UnparsedInput[UnparsedInput.Count - 1] != ParsedInput[ParsedInput.Count - 1])
                    {
                        if (noun + 1 == UnparsedInput.Count-1)
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("I don't know the word: " + "'" + UnparsedInput[noun+1] + "'");
                            return null;
                        }

                        else
                        {
                            string errorphrase = null;
                            for (int i = noun + 1; i < UnparsedInput.Count; i++)
                            {
                                errorphrase += (UnparsedInput[i] + " ");
                            }
                            Globals.WindowFrame.DisplayTextToFlowDoc("I don't know what " + "'" + errorphrase.Trim() + "'" + " refers to.");
                            return null;
                        }
                        
                    }

                    else
                    {
                        return ParsedInput;
                    }
                }   
            }

            if (format[0] == "verb")
            {
                if (UnparsedInput[0] == ParsedInput[0])
                {
                    if (format.Count == 1)
                    {
                        if (UnparsedInput[UnparsedInput.Count - 1] != ParsedInput[ParsedInput.Count - 1])
                        { 
                            string errorphrase = null;
                            foreach (string word in UnparsedInput)
                            {
                                errorphrase += (word + " ");
                            }
                            Globals.WindowFrame.DisplayTextToFlowDoc("You can't " + Convert.ToString(errorphrase));
                            return null;
                        }

                        else
                        {
                            return ParsedInput;
                        }
                    }

                    if (format.Count == 2)
                    {
                        if (format[1] == "noun")
                        {
                            int noun = -1;
                            int article = -1;
                            int preposition = -1;
                            foreach (string word in UnparsedInput)
                            {
                                if (word == ParsedInput[1])
                                {
                                    noun = UnparsedInput.IndexOf(word);
                                    break;
                                }

                                if ((word == "a" ||
                                    word == "an" ||
                                    word == "the") &&
                                    article < 0)
                                {
                                    article = UnparsedInput.IndexOf(word);
                                }

                                if((word == "at" ||
                                    word == "into" ||
                                    word == "to" ) &&
                                    preposition <0)
                                {
                                    preposition = UnparsedInput.IndexOf(word);
                                }
                            }

                            if( article > noun || preposition > noun || (article > 0 && article < preposition && article < noun))
                            {
                                Globals.WindowFrame.DisplayTextToFlowDoc("That doesn't make sense. Please check your word order.");
                                return null;
                            }
                            
                            if ((preposition == 1 && article == 2 && noun == 3) || (preposition == 1 && noun == 2) || (article == 1 && noun == 2) || noun == 1 )
                            {
                                string errorphrase = null;
                                for (int i = UnparsedInput.IndexOf(ParsedInput[1]); i < UnparsedInput.Count - 1; i++)
                                {
                                    errorphrase += (UnparsedInput[i] + " ");
                                }
                                if (errorphrase != null)
                                {
                                    Globals.WindowFrame.DisplayTextToFlowDoc("I don't know what: " + "'" + errorphrase.Trim() + "'" + " refers to.");
                                    Globals.WindowFrame.DisplayTextToFlowDoc("But I'll do the first part anyway.");
                                }
                                return ParsedInput;
                            }
                            Globals.WindowFrame.DisplayTextToFlowDoc("Write your actions better.");
                            return null; 
                        }

                        else
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("That doesn't make sense. Please check your word order.");
                            return null;
                        }
                    }

                    else
                    {
                        if (format[1] == "noun" && format[2] == "noun")
                        {
                            return ParsedInput;
                        }

                        else
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("That doesn't make sense. Please check your word order.");
                            return null;
                        }
                    }
                }

                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("That doesn't make sense. Please check your word order.");
                    return null;
                }
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("I don't know any of those words...");
                return null;
            }
            
        }
    }
}
