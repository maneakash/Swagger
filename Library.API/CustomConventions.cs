using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Sample.API
{
    public static class CustomConventions
    {
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        public static void MethodPrefix_Goes_here([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
        { }
    }
}
