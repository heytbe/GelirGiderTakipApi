using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dto
{
    public class ErrorDto
    {
        public List<string> Erros { get; set; } = new List<string>();
        public bool IsShow { get; set; }

        public ErrorDto() 
        {
            Erros = new List<string>();
        }

        public ErrorDto(List<string> erros, bool ısShow)
        {
            Erros = erros;
            IsShow = ısShow;    
        }

        public ErrorDto(string ErrorMessage,bool isShow)
        {
            Erros.Add(ErrorMessage);
            IsShow = isShow;
        }
    }
}
