
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace EV2HttpExtension.Models
{
    public class DefaultHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            #region All_Headers

            // A unique identifier for the current operation, Ev2 generated. All extensions must log this request id in their traces and return this value in the response headers to facilitate debugging.
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-ms-request-id",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                },
                Required = true
            });


            // Set to application/json. This header is not required in responses that do not have any content.
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Content-Type",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                },
            });

            // Set to application/json. This header is not required in responses that do not have any content.
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Date",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                },
                Example = new OpenApiDate(DateTime.Now)
            });

            // Set to the delay that the client should use when checking for the status of the operation. This value is an integer and represents the seconds.
            // If Retry-After is not specified, the default AsyncPollInterval specified by the extension at registration time will be used.
                        operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Retry-After",
                In = ParameterLocation.Header,
                Required = false,
                Example = new OpenApiInteger(0),
                Schema = new OpenApiSchema
                {
                    Type = "integer"
                },
            });

            #endregion

            #region Put_Method_Headers

            if (string.Equals(context.ApiDescription.HttpMethod, HttpMethod.Put.Method, StringComparison.InvariantCultureIgnoreCase))
            {
                // Only accept from the first PUT call, an Endpoint of Extension, which will be used in subsequence calls.
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Location",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    },
                    Example = new OpenApiString(""),
                });

                // Only accept from the first PUT call, a piece of data which will be set in subsequence call Request Header. Size limit is 1K.
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "x-ms-usercallbackdata",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    },
                    Example = new OpenApiString("")
                });

                #endregion
            }
        }
    }
}