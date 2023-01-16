using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PCVM.Web.Helpers
{
    public static class SelectListItemExtention
    {
        public static List<SelectListItem> ToSelectionList<T>(this List<T> t)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            List<SelectListItem> SelectionList = new List<SelectListItem>();
            foreach(var item in t)
            {
                var obj = new SelectListItem();
                Type ty = item.GetType();
                if (browserLang.ToLower() == "en-us")
                {
                    PropertyInfo propName = ty.GetProperty("NameEn");
                    obj.Text= propName.GetValue(item).ToString();
                    PropertyInfo propvalue = ty.GetProperty("ID");
                    obj.Value = propvalue.GetValue(item).ToString();
                    

                }
                else

                {
                    PropertyInfo prop = ty.GetProperty("NameAr");
                    obj.Text = prop.GetValue(item).ToString();
                    PropertyInfo propvalue = ty.GetProperty("ID");
                    obj.Value = propvalue.GetValue(item).ToString();
                }
                
                SelectionList.Add(obj);
            }
           
            return SelectionList;

        }
    }
}
