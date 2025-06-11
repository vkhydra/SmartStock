using System;

namespace SmartStock.Application.DTOs
{
    public class Result<TSuccess, TError>
    {
        public TSuccess ?Value { get; }
        public TError ?Error { get; }
        public bool IsSuccess { get; }

        private Result(TSuccess value)
        {
            IsSuccess = true;
            Value = value;
            Error = default;
        }

        private Result(TError error)
        {
            IsSuccess = false;
            Error = error;
            Value = default;
        }

        public static Result<TSuccess, TError> Success(TSuccess value) => new(value);
        public static Result<TSuccess, TError> Failure(TError error) => new(error);
    }
}