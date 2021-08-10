using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse(int statusCode) : base(400, "Validation errors occured")
        {
        }

        public IEnumerable<ApiValidationError> Errors { get; set; }
    }

    public class ApiValidationError
    {
        public string Property { get; set; }
        public string[] Errors { get; set; }
    }
}
