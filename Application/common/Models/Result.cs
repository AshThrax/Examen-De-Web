using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class Result
    {
        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }
        internal Result(bool suceeded, IEnumerable<string> errors)
        {
            Succeeded = suceeded;
            Errors= errors.ToArray();
        }

        public static Result Success() 
        {
            return new Result(true, new string[] { });
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}
