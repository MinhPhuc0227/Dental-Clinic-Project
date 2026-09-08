using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DTO.Common
{
    // Dành cho các phương thức không trả về dữ liệu (Thêm, Sửa, Xóa)
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public static Result Success(string message) => new Result { IsSuccess = true, Message = message };
        public static Result Failure(string message) => new Result { IsSuccess = false, Message = message };
    }

    // Dành cho các phương thức trả về dữ liệu (Get, List, Login)
    public class Result<T> : Result
    {
        public T? Data { get; set; }
        public static Result<T> Success(T data, string message = "Success") => new Result<T> { IsSuccess = true, Message = message, Data = data };
        public new static Result<T> Failure(string message) => new Result<T> { IsSuccess = false, Message = message, Data = default };
    }
}
