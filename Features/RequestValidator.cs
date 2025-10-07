using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using Features;


public class RequestValidator
{
    public Response ValidateRequest(Request request)
    {
        List<string> issues = new();
        string[] allowedMethod = { "create", "update", "read", "delete", "echo"};

        if (request == null)
            return new Response { Status = "6 Error", Body = "Invalid Request" };
        
        // Missing and Illegal Method
        if (string.IsNullOrEmpty(request.Method))
            issues.Add("missing method"); 
        else if (!allowedMethod.Contains(request.Method.ToLower()))
            issues.Add("illegal method");
        
        
        if (string.IsNullOrEmpty(request.Date))
            issues.Add("missing date");
        else if (!long.TryParse(request.Date, out _))
            issues.Add("illegal date"); 
        
     
        
        if (string.IsNullOrEmpty(request.Path))
            issues.Add("missing path");

        if (request.Method is "create" or "update" or "echo")
        {
            if (string.IsNullOrEmpty(request.Body))
            {
                issues.Add("missing body");
            }
            else if (request.Method is "create" or "update")
                try
                {
                    JsonDocument.Parse(request.Body);
                }
                catch
                {
                    issues.Add("illegal body");
                }
        }
        
        if (issues.Count > 0)
        {
            return new Response
            {
                Status = "4 " + string.Join(",", issues),
                Body = ""
            };
        }

        return new Response { Status = "1 Ok", Body = "" };
    }
}