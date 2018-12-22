using System.Collections.Generic;
using System.Linq;

namespace CCSuccessiveRefinement
{
    public class Args
    {
        private Dictionary<char, ArgumentMarshaler> marshalers;
        private HashSet<char> argsFound;
        private IEnumerator<string> currentArgument;

        public Args(string schema, string[] args)
        {
            marshalers = new Dictionary<char, ArgumentMarshaler>();
            argsFound = new HashSet<char>();

            parseSchema(schema);
            parseArgumentStrings(args.ToList());
        }


        private void parseSchema(string schema)
        {
            foreach (string element in schema.Split(','))
            {
                if (element.Length > 0)
                {
                    parseSchemaElement(element.Trim());
                }
            }
        }

        private void parseSchemaElement(string element)
        {
            char elementId = element[0];
            string elementTail = element.Substring(1);
            validateSchemaElement(elementId);
            if (elementTail.Length == 0)
                marshalers.Add(elementId, new BooleanArgumentMarshaler());
            else if (elementTail.Equals("*"))
                marshalers.Add(elementId, new StringArgumentMarshaler());
            else if (elementTail.Equals("#"))
                marshalers.Add(elementId, new IntegerArgumentMarshaler());
            else if (elementTail.Equals("##"))
                marshalers.Add(elementId, new DoubleArgumentMarshaler());
            else if (elementTail.Equals("[*]"))
                marshalers.Add(elementId, new StringArrayArgumentMarshaler());
            else
                throw new ArgsException(ErrorCode.INVALID_ARGUMENT_FORMAT, elementId, elementTail);
        }

        private void validateSchemaElement(char elementId)
        {
            if (!char.IsLetter(elementId))
                    throw new ArgsException(ErrorCode.INVALID_ARGUMENT_NAME, elementId, null);
        }

        private void parseArgumentStrings(List<string> argsList)
        {
            //TODO: Figure out how to properly do this section in C#
            currentArgument = argsList.GetEnumerator();
            currentArgument.MoveNext();
            
            do
            {
                string argsString = currentArgument.Current;
                if (!argsString.StartsWith('-'))
                {
                    break;
                }
                else
                {
                    parseArgumentCharacters(argsString.Substring(1));
                }
            }
            while (currentArgument.MoveNext());
        }

        private void parseArgumentCharacters(string argsChars)
        {
            for (int i = 0; i < argsChars.Length; i++)
            {
                parseArgumentCharacter(argsChars[i]);
            }
        }

        private void parseArgumentCharacter(char argChar)
        {
            ArgumentMarshaler m = marshalers[argChar];
            if (m == null)
            {
                throw new ArgsException(ErrorCode.UNEXPECTED_ARGUMENT, argChar, null);
            }
            else
            {
                argsFound.Add(argChar);
                try
                {
                    m.Set(currentArgument);
                }
                catch (ArgsException e)
                {
                    e.ErrorArgumentId = argChar;
                    throw e;
                }
            }
        }

        public bool Has(char arg)
        {
            return argsFound.Contains(arg);
        }

        public bool nextArgument()
        {
            return currentArgument.MoveNext();
        }

        public bool GetBoolean(char arg)
        {
            return BooleanArgumentMarshaler.GetValue(marshalers[arg]);
        }

        public string GetString(char arg)
        {
            return StringArgumentMarshaler.GetValue(marshalers[arg]);
        }

        public int GetInt(char arg)
        {
            return IntegerArgumentMarshaler.GetValue(marshalers[arg]);
        }

        public double GetDouble(char arg)
        {
            return DoubleArgumentMarshaler.GetValue(marshalers[arg]);
        }

        public int GetStringArray(char arg)
        {
            return StringArrayArgumentMarshaler.GetValue(marshalers[arg]);
        }
    }
}