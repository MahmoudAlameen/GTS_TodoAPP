using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.DTOs
{
    public class BaseResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// generic Result
    /// </summary>
    /// <typeparam name="T"></typeparam>    
    public class ServiceResult<T> : BaseResult
    {
        public T Model  { get; set; }
    }

    public class ServiceResultList<T> : BaseResult
    {
        public List<T> list { get; set; }
        public int TotalPages { get; set; }
    }
}
