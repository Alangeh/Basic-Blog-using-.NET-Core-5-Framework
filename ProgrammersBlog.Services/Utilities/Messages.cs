using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionsTimes.Services.Utilities
{
    public static class Messages
    {
        // Messages.Category.NotFound()
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Could not find any categories.";
                return "This Category cannot be found.";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} category has been successfully added.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} category has been successfully updated.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} category has been successfully deleted.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} category has been deleted from the database.";
            }
        }

        public static class Article
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Could not find articles.";
                return "This article was not found.";
            }
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} article has been added successfully.";
            }

            public static string Update(string articleTitle)
            {
                return $"{articleTitle} article has been updated successfully.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} article has been delted successfully.";
            }
            public static string HardDelete(string articleTitle)
            {
                return $"{articleTitle} article has been deleted from the database.";
            }
        }
    }
}
