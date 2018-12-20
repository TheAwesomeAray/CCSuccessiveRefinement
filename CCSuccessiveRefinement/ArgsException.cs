using System;

namespace CCSuccessiveRefinement
{
    public class ArgsException : Exception
    {
        public char ErrorArgumentId { get; set; }
        public string ErrorParameter { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public ArgsException() { }

        public ArgsException(string message) : base(message)
        { }

        public ArgsException(ErrorCode errorCode)
        {
            ErrorCode = errorCode;
        }

        public ArgsException(ErrorCode errorCode, string errorParameter)
        {
            ErrorCode = errorCode;
            ErrorParameter = errorParameter;
        }

        public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParameter)
        {
            ErrorCode = errorCode;
            ErrorArgumentId = errorArgumentId;
            ErrorParameter = errorParameter;
        }

        public string ErrorMessage()
        {
            switch (ErrorCode)
            {
                case ErrorCode.OK:
                    return "TILT: Should not get here.";
                case ErrorCode.UNEXPECTED_ARGUMENT:
                    return $"Argument {ErrorArgumentId} unexpected";
                case ErrorCode.MISSING_STRING:
                    return $"Could not find string paramter for {ErrorArgumentId}";
                case ErrorCode.INVALID_INTEGER:
                    return $"Argument {ErrorArgumentId} expects an integer but was {ErrorParameter}";
                case ErrorCode.MISSING_INTEGER:
                    return $"Could not find integer paramter for {ErrorArgumentId}";
                case ErrorCode.INVALID_DOUBLE:
                    return $"Argument {ErrorArgumentId} expects a double but was {ErrorParameter}";
                case ErrorCode.MISSING_DOUBLE:
                    return $"Could not find double parameter for {ErrorArgumentId}";
                case ErrorCode.INVALID_ARGUMENT_NAME:
                    return $"{ErrorArgumentId} is not valid argument name";
                case ErrorCode.INVALID_ARGUMENT_FORMAT:
                    return $"{ErrorParameter} is not a valid argument format";
            }

            return "";

        }
    }
}
