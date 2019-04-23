using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Components
{
    public static class Urls
    {
        public static string CompanyList = "/company/list";
        public static string CompanyAdd = "/company/add";
        public static string CompanyEditSimple = "/company/edit/";
        public static string CompanyEditFull = "/company/detail/";
        public static string CompanyContactAdd = "/company-contact/add/"; 

        public static string ContactList = "/contact/list";
        public static string ContactAdd = "/contact/add";
        public static string ContactEditSimple = "/contact/edit/";
        public static string ContactEditFull = "/contact/detail/";

        public static string ParameterList = "/parameter/list";
        public static string ParameterAdd = "/parameter/add";
        public static string ParameterEdit = "/parameter/edit/";
    }
}
