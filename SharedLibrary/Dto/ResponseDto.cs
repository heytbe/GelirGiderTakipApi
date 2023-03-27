using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Dto
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int statusCode { get; set; }
        [JsonIgnore]
        public bool isSuccessFull { get; set; }
        public ErrorDto errorDto { get; set; }

        public static ResponseDto<T> Success(T data,int Code)
        {
            return new ResponseDto<T>()
            {
                Data= data,
                statusCode = Code,
                isSuccessFull = true,
            };
        }

        public static ResponseDto<T> Success(int Code)
        {
            return new ResponseDto<T>()
            {
                Data = default,
                statusCode = Code,
                isSuccessFull = true,
            };
        }

        public static ResponseDto<T> Fail(ErrorDto error,int Code)
        {
            return new ResponseDto<T>()
            {
                errorDto= error,
                statusCode = Code,
                isSuccessFull = false,
            };
        }

        public static ResponseDto<T> Fail(string ErrorMessage,int Code,bool statusCode)
        {
            var errors = new ErrorDto(ErrorMessage, statusCode);
            return new ResponseDto<T>()
            {
                errorDto = errors,
                statusCode = Code,
                isSuccessFull = false
            };
        }
    }
}
